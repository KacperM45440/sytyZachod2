using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    [HideInInspector] public Animator animatorRef;
    [HideInInspector] public GunScript gun;
    [HideInInspector] public GameObject kontroler;
    [HideInInspector] public Transform destroyQueue;
    [HideInInspector] public float speed;
    [HideInInspector] public Transform targetParent;

    [SerializeField] private float speedModifier = 1f;
    [SerializeField] private AudioSource breakSource1;
    [SerializeField] private AudioSource breakSource2;
    [SerializeField] private GameObject shards;

    private SpawnTarget spawnTargetRef;
    private int life;
    private int i;
    private Animator shardAnimator;
    private animationStep[] animationSteps;

    protected virtual void Start()
    {
        animatorRef = GetComponent<Animator>();
        shardAnimator = shards.GetComponent<Animator>();
    }

    public void InitializeTarget(SpawnTarget spawnTarget, targetAnimation animation)
    {
        spawnTargetRef = spawnTarget;
        gun = spawnTargetRef.gunScriptRef;
        destroyQueue = spawnTargetRef.targetDestroyQueue;

        if (!AnimationDatabase.Animations.TryGetValue(animation, out animationSteps))
        {
            Debug.LogError($"Missing animation: {animation}");
            animationSteps = System.Array.Empty<animationStep>();
        }

        speed = spawnTarget.currentLevelSpeed;
        life = animationSteps.Length + 1;
    }

    public void FinishedMovement()
    {
        // W tym miejscu cel skoñczy³ siê pojawiaæ, wiêc zmienia prêdkoœæ na docelow¹ - zale¿n¹ od poziomu trudnoœci
        animatorRef.speed = speed * speedModifier;
        life--;
        if(life <= 0)
        {
            // Tutaj cel znika: nie zostal zestrzelony, nie liczy sie do puli punktow
            // Animacja niszczenia nie ma byc zalezna od poziomu trudnosci, zmieniamy prêdkoœæ na domyœln¹ przed zniknieciem
            animatorRef.speed = 1;
            StartCoroutine(Disappear());
            return;
        }

        int index = animationSteps.Length - life;
        animatorRef.SetTrigger(animationSteps[index].ToString());
    }

    public virtual void OnClick()
    {
        if (gun.readyToFire)
        {
            gun.ShotFired();
            // To samo co wyzej; zmieniamy prêdkoœæ na domyœln¹ przed zniszczeniem
            animatorRef.speed = 1;
            WinCheck.Instance.Clicked();
            life = 0;
            StartCoroutine(DestroyMe());
        }
    }


    // Tutaj wlaczana jest animacja znikniecia i zniszczenia (wygasniecia) celu. Funkcja odpowiadzialna za zestrzelenie jest wyzej
    IEnumerator Disappear()
    {
        animatorRef.SetTrigger("Disappear");
        float animationLength = animatorRef.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength/4);
        Destroy(transform.parent.gameObject);
    }

    // Cel zosta³ klikniêty, wiêc gra animacjê "zniszczenia" oraz wydaje z siebie dzwiek.
    // Po celu zostaja roztrzaskane fragmenty, ktore zmniejszaja sie a nastepnie znikaja.
    // Maja one podobna logike do luskach po pociskach, patrz: GunScript::80
    IEnumerator DestroyMe()
    {
        PlayShardsAnimation(shards, shardAnimator);

        transform.GetComponent<SpriteRenderer>().enabled = false;
        CircleCollider2D[] collidersInChildren = transform.GetComponentsInChildren<CircleCollider2D>();
        foreach (CircleCollider2D collider in collidersInChildren)
        {
            collider.enabled = false;
        }

        yield return null;
        Destroy(transform.parent.gameObject);
    }

    protected void PlayShardsAnimation(GameObject shardParent, Animator shardParentAnimator)
    {
        shardParent.transform.SetPositionAndRotation(transform.position, transform.rotation);
        shardParent.SetActive(true);

        i = Random.Range(1, 3);

        if (i.Equals(1))
        {
            breakSource1.Play();
        }
        else
        {
            breakSource2.Play();
        }
        shardParentAnimator.SetTrigger("shard_fade");
        shardParent.transform.parent = destroyQueue;

        int shardCount = shardParent.transform.childCount;
        for (int i = 0; i < shardCount; i++)
        {
            Rigidbody2D childRbRef = shardParent.transform.GetChild(i).GetComponent<Rigidbody2D>();
            childRbRef.bodyType = RigidbodyType2D.Dynamic;
            childRbRef.AddForce(new Vector2(Random.Range(-250, 250), 300));
        }
        shardParent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
