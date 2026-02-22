using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour
{
    [HideInInspector] public bool canPunch;

    [SerializeField] private GunScript gunControllerRef;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private WinCheck winCheckRef;
    [SerializeField] private Slider finisherBar;
    [SerializeField] private Sprite enemyDeadSprite;
    [SerializeField] private Sprite enemyPunched1;
    [SerializeField] private Sprite enemyPunched2;
    [SerializeField] private Sprite enemyPunched3;
    [SerializeField] private AudioSource enemyDeathSound;
    [SerializeField] private AudioSource punchSource1;
    [SerializeField] private AudioSource punchSource2;
    [SerializeField] private AudioSource punchSource3;

    private SpriteRenderer rendererRef;

    private bool dominated;
    private int previousAnim;

    void Start()
    {
        rendererRef = winCheckRef.enemySprite;
        dominated = false;
    }

    private void OnMouseDown()
    {
        // Jako ze mozna nie trafic celu, klikniecie w tlo powoduje wystrzelenie (i zmarnowanie) pocisku
        if (!dominated)
        {
            gunControllerRef.ShotFired();
            winCheckRef.Missed();
        }
        else
        {
            // W etapie bonusowym, z zalozenia mozna klikac nieskonczonosc razy, dlatego nie ma koniecznosci podpinania (i konfigurowania) go pod system strzelania
            if (canPunch)
            {
                EnemyPunched();              
            }
        }
    }


    // Przy uderzeniu, losowo wybierz animacje pobicia. Nie moze byc ona taka sama jak poprzednia
    public void EnemyPunched()
    {
        winCheckRef.DominationPunch();
        enemyAnimator.SetTrigger("hurt");

        int i;
        do
        {
            i = Random.Range(1, 4);
        }
        while (i.Equals(previousAnim));

        if (i.Equals(1))
        {
            rendererRef.sprite = enemyPunched1;
            punchSource1.Play();
        }
        else if (i.Equals(2))
        {
            rendererRef.sprite = enemyPunched2;
            punchSource2.Play();
        }
        else
        {
            rendererRef.sprite = enemyPunched3;
            punchSource3.Play();
        }
        previousAnim = i;

        rendererRef.flipX = Random.Range(0, 2) == 0;

        int j = Random.Range(1, 3);
        enemyAnimator.SetTrigger("recoil"+ j);
    }
    public void PunchOut()
    {
        // Zamiana broni na piesci, zaczecie odliczania czasu etapu bonusowego
        dominated = true;
        canPunch = true;
        StartCoroutine(Timer());
        StartCoroutine(DrainBar());
    }
    public void KillEnemy()
    {
        // Zagraj animacje zabicia przeciwnika
        enemyAnimator.SetTrigger("dead");
        enemyDeathSound.Play();
        rendererRef.sprite = enemyDeadSprite;
    }
    IEnumerator Timer()
    {
        // Odmierz 5 sekund etapu bonusowego, po tym czasie zablokuj mozliwosc bicia
        yield return new WaitForSeconds(5);
        canPunch = false;
    }
    IEnumerator DrainBar()
    {
        // Zaktualizuj wizualnie stan poziomu bonusowego na pasku
        for (int i=0; i<5; i++)
        {
            yield return new WaitForSeconds(1);
            finisherBar.value -= 0.2f;
        }
    }
}
