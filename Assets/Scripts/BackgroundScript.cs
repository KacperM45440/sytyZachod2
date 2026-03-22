using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour
{
    [HideInInspector] public bool canPunch;

    [SerializeField] private CharacterSpritesChanger characterSpriteChangerRef;
    [SerializeField] private GunScript gunControllerRef;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private WinCheck winCheckRef;
    [SerializeField] private Slider finisherBar;
    [SerializeField] private Sprite enemyDeadSprite;
    [SerializeField] private Sprite enemyPunched1;
    [SerializeField] private Sprite enemyPunched2;
    [SerializeField] private Sprite enemyPunched3;
    [SerializeField] private AudioSource enemyDeathSound;
    [SerializeField] private AudioSource punchSoundSource;
    [SerializeField] private AudioClip punchSound1;
    [SerializeField] private AudioClip punchSound2;
    [SerializeField] private AudioClip punchSound3;

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
        characterSpriteChangerRef.ChangeEnemySprite(enemySpriteType.punched);

        int i;
        do
        {
            i = Random.Range(0, 3);
        }
        while (i.Equals(previousAnim));

        AudioClip punchSound = punchSound1;
        switch (i)
        {
            case 1:
                punchSound = punchSound2;
                break;
            case 2:
                punchSound = punchSound3;
                break;
        }
        punchSoundSource.PlayOneShot(punchSound);

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
        enemyAnimator.SetTrigger("dead");
        enemyDeathSound.Play();
        characterSpriteChangerRef.ChangeEnemySprite(enemySpriteType.dead);
    }

    private IEnumerator Timer()
    {
        // Odmierz 5 sekund etapu bonusowego, po tym czasie zablokuj mozliwosc bicia
        yield return new WaitForSeconds(5);
        canPunch = false;
    }
    private IEnumerator DrainBar()
    {
        // Zaktualizuj wizualnie stan poziomu bonusowego na pasku
        for (int i=0; i<5; i++)
        {
            yield return new WaitForSeconds(1);
            finisherBar.value -= 0.2f;
        }
    }
}
