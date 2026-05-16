using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;
using System;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    [HideInInspector] public Animator animatorRef;
    [HideInInspector] public bool readyToFire;

    [SerializeField] private DialogueController dialogueControllerRef;
    [SerializeField] private TransitionScript transitionScriptRef;
    [SerializeField] private GameObject cylinder;
    [SerializeField] private Sprite firedBullet;
    [SerializeField] private Transform destroyQueue;
    [SerializeField] private AudioSource shotSource;
    [SerializeField] private AudioSource reloadSource;
    [SerializeField] private AudioClip reloadFinished;
    [SerializeField] private AudioClip missSound;
    [SerializeField] private SpawnMag spawnMagRef;
    [SerializeField] private ParticleSystem dustParticleSystemRef;
    [SerializeField] private Animator playerGunAnimatorRef;
    [SerializeField] private int maxAmmo = 6;

    private GameObject currentBullet;
    private GameObject currentMagazine;
    private Transform cylinderBody;
    private Image spriteRef;
    private Vector3 cameraPos;
    private bool isReloading;
    private bool isTalking;
    private int currentAmmo;

    void Start()
    {
        cylinderBody = cylinder.transform.GetChild(0);
        animatorRef = cylinderBody.GetComponent<Animator>();

        spawnMagRef.Initialize(this);
        currentMagazine = spawnMagRef.NewMagazine();

        currentAmmo = maxAmmo;
        readyToFire = true;
    }

    void Update()
    {
        // Bron domyslnie przeladowywana jest w momencie wystrzelenia wszystkich posiadanych pociskow, natomiast mozna to zrobic recznie w dowolnym momencie
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(1))
        {
            ReloadGun();
        }
        // Zniszcz pociski, ktore wylecialy juz poza ekran
        if (destroyQueue.childCount > 0)
        {
            cameraPos = Camera.main.WorldToScreenPoint(destroyQueue.GetChild(destroyQueue.childCount - 1).transform.position);
            bool outOfBounds = !Screen.safeArea.Contains(cameraPos);
            if (outOfBounds)
            {
                Destroy(destroyQueue.GetChild(destroyQueue.childCount - 1).gameObject);
            }
        }
    }

    public void ShotFired(bool missed = false)
    {
        if (isTalking)
        {
            dialogueControllerRef.ShowNextLine();
            if (!isTalking)
            {
                return;
            }

            transitionScriptRef.ChooseCursor(cursorType.crosshairTalkOpen);
            StartCoroutine(ChangeBackTalkingCursor());
            return;
        }
        // Zaktualizuj przy wystrzale ilosc obecnie posiadanej amunicji.
        // Funckja ma charakter nadzorczy (samej broni), niszczeniem celu zajmuje sie juz jego klasa "TargetMovement"
        if (readyToFire)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dustParticleSystemRef.transform.position = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
            //dustParticleSystemRef.Play();

            shotSource.pitch = UnityEngine.Random.Range(0.99f, 1.10f);
            shotSource.PlayOneShot(shotSource.clip);
            currentAmmo--;
            animatorRef.SetTrigger("Rotate Single");
            playerGunAnimatorRef.SetTrigger("Shoot");
            DestroyBullet();
            if (currentAmmo <= 0)
            {
                ReloadGun();
                return;
            }
            if (missed)
            {
                shotSource.PlayOneShot(missSound);
            }
        }
    }

    private IEnumerator ChangeBackTalkingCursor()
    {
        yield return new WaitForSeconds(0.1f);
        if (isTalking)
        {
            transitionScriptRef.ChooseCursor(cursorType.crosshairTalk);
        }
    }

    public void ChangeToTalkMode()
    {
        isTalking = true;
        transitionScriptRef.ChooseCursor(cursorType.crosshairTalk);
    }

    public void StopTalking()
    {
        isTalking = false;
        transitionScriptRef.ChooseCursor(cursorType.crosshairShooting);
    }

    public void DestroyBullet()
    {
        // Pociski sa odpinane z magazynka po jednym, wylatuja za ekran a nastepnie sa niszczone.
        // Zmieniana im jest rowniez waga, kierunek odrzutu oraz obrazek w celu uatrakcyjnienia procesu przeladowania.
        currentBullet = currentMagazine.GetComponent<Transform>().GetChild(0).gameObject;
        currentBullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        currentBullet.transform.SetParent(destroyQueue);
        currentBullet.transform.position += new Vector3(0, 0, -1);

        currentBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-100, 100), 0));
        spriteRef = currentBullet.GetComponent<Image>();
        spriteRef.sprite = firedBullet;
    }
    public void ReloadGun()
    {
        // Jak w prawdziwym zyciu, podczas przeladowywania broni nie mozemy z niej jednoczesnie korzystac.
        // Blokujac mozliwosc strzalu unikamy sytuacji w ktorej przeladowujemy np. z 4 pociskami, i w trakcie trwania animacji przeladowania strzelamy dalej.
        // Dodajac pociski na koncu procesu zamiast na poczatku wizualnie sugeruje graczowi, ze jego bron jest juz gotowa do strzalu.
        if (!isReloading)
        {
            isReloading = true;
            readyToFire = false;
            if (currentAmmo > 0)
            {
                int x = currentMagazine.transform.childCount;
                for (int i = 0; i < x; i++)
                {
                    DestroyBullet();
                }
            }
            StartCoroutine(TimeOut());
            currentAmmo = maxAmmo;
        }
    }

    IEnumerator TimeOut()
    {
        // Zaczekaj na przeladowanie, nastepnie dodaj pociski na koncu przeladowania.       
        // Ponowna inicjalizacja magazynka; przeladowanie graficzne ma charakter wklejenie prefabu na nowo, wiec nie moze zostac odwolan do starych obiektow
        Destroy(currentMagazine);
        yield return new WaitUntil(() => currentMagazine.Equals(null));

        cylinderBody.localEulerAngles = spawnMagRef.originalRotation;
        animatorRef.SetTrigger("Full Rotate");
        reloadSource.Play();
    }

    public void FinishReload()
    {
        currentMagazine = spawnMagRef.NewMagazine();
        shotSource.PlayOneShot(reloadFinished);
        isReloading = false;
        readyToFire = true;
    }

    public bool isGunFull()
    {
        return currentAmmo.Equals(maxAmmo);
    }
}
