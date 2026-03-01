using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;

public class SpawnTarget : MonoBehaviour
{
    public GunScript gunScriptRef;
    public WinCheck winCheckerRef;
    public Transform targetDestroyQueue;

    [SerializeField] private DialogueController dialogueControllerRef;
    [SerializeField] private Transform targetsContainer;
    [SerializeField] private Animator popupAnimator;
    [SerializeField] private Animator fadeAnimator;

    [Header("Level Specific Variables")]
    [SerializeField] private int currentLevel;

    [Header("Target Prefabs")]
    [SerializeField] private List<GameObject> targets = new();

    // Prefab celu i animacje przypisywane sa w edytorze 
    [HideInInspector] public int targetAmount;
    [HideInInspector] public float currentLevelSpeed;

    private AudioSource bellSourceRef;
    private GameObject newTarget;
    private LevelData chosenLevel;
    private Vector2 targetPosition;
    private bool versusShown = false;
    private int roundNumber;
    // Przejscie przez animacje rund zajmuje (okolo) siedem sekund, wiec tyle czeka program
    private int roundPopupCooldown = 3;

    void Start()
    {
        bellSourceRef = GetComponent<AudioSource>();

        InitialiseLevel();
    }

    public void InitialiseLevel()
    {
        // Za³aduj dane celów z poziomu, nadaj odpowiednia im predkosc a nastepnie rozpocznij proces tworzenia celów w grze
        chosenLevel = new();
        ChooseLevel();

        targetAmount = chosenLevel.finishedTable.Count;
        winCheckerRef.SetMaxScore();

        // Animacja rundy
        fadeAnimator.SetTrigger("fade_out");
        StartCoroutine(WaitToStartDialogue());
    }

    private IEnumerator WaitToStartDialogue()
    {
        yield return new WaitForSeconds(2);
        PlayDialogue();
    }

    private void ChooseLevel()
    {
        switch (currentLevel)
        {
            case 0:
                chosenLevel.Level0();
                break;
            case 1:
                chosenLevel.Level1();
                break;
            case 2:
                chosenLevel.Level2();
                break;
            case 3:
                chosenLevel.Level3();
                break;
            case 4:
                chosenLevel.Level4();
                break;
            case 5:
                chosenLevel.Level5();
                break;
            default:
                chosenLevel.Level0();
                break;
        }
    }

    private void PlayDialogue()
    {
        string playerPrefKey = "dialoguePlayed" + roundNumber;
        if(PlayerPrefs.GetInt(playerPrefKey, 0) == 1)
        {
            dialogueControllerRef.MoveCharacters(false);
            StartRound();
            return;
        }
        //PlayerPrefs.SetInt(playerPrefKey, 1); //ODBLOKUJ TO ABY TEKST NIE POWTARA£ SIÊ CO KA¯DE PODEJŒCIE
        PlayerPrefs.Save();
        switch (roundNumber)
        {
            case 0:
                dialogueControllerRef.DisplayDialogue(chosenLevel.dialogueIntro, false);
                break;
            case 1:
                dialogueControllerRef.DisplayDialogue(chosenLevel.dialogueMiddle, false);
                break;
            case 2:
                if (winCheckerRef.PlayerHasEnoughPoints())
                {
                    dialogueControllerRef.DisplayDialogue(chosenLevel.dialogueOutro, true);
                }
                else
                {
                    StartRound();
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator ShowVersusPopup()
    {
        popupAnimator.GetComponent<Image>().enabled = true;
        popupAnimator.SetTrigger("versus");
        yield return new WaitForSeconds(2);
        if (!gunScriptRef.isGunFull())
        {
            gunScriptRef.ReloadGun();
        }
        yield return new WaitForSeconds(2);
        StartRound();
    }

    public void StartRound() //Odpalane z Dialogue controllera
    {
        if (versusShown == false)
        {
            versusShown = true;
            StartCoroutine(ShowVersusPopup());
            return;
        }
        switch (roundNumber)
        {
            case 0:
                fadeAnimator.SetTrigger("fade_in");
                popupAnimator.SetTrigger("round1");
                bellSourceRef.PlayDelayed(0.75f);
                currentLevelSpeed = chosenLevel.levelSpeed;
                StartCoroutine(TargetSpawnerCoroutine());
                break;
            case 1:
                fadeAnimator.SetTrigger("fade_in");
                popupAnimator.SetTrigger("round2");
                bellSourceRef.PlayDelayed(0.25f);
                currentLevelSpeed = chosenLevel.levelSpeedBoosted;
                StartCoroutine(TargetSpawnerCoroutine());
                break;
            case 2:
                WinCheck.Instance.Checker();
                break;
            default:
                break;
        }
        StartCoroutine(FadeOut());
    }

    private IEnumerator TargetSpawnerCoroutine()
    {
        yield return new WaitForSeconds(roundPopupCooldown);
        for (int i = 0; i < targetAmount; i++)
        {
            // Pozycja celu okreslana jest recznie poprzez wpis do tabeli znajdujacej sie w klasie LevelData.cs
            // Stworz cel: numer prefabu (animacji), pozycja, obrot
            targetPosition = chosenLevel.finishedTable[i].spawnLocation;
            newTarget = Instantiate(targets[(int)chosenLevel.finishedTable[i].targetType], targetPosition, Quaternion.identity, targetsContainer);
            newTarget.transform.position = new Vector3(newTarget.transform.position.x, newTarget.transform.position.y, targetsContainer.position.z);
            TargetBehaviour targetScript = newTarget.GetComponentInChildren<TargetBehaviour>();
            targetScript.InitializeTarget(this, chosenLevel.finishedTable[i].animation);
            targetScript.targetParent = targetsContainer;

            // Dodanie przerwy pomiedzy tworzeniem celow umozliwia sekwencyjnie ulozyc poziomy
            yield return new WaitForSeconds(chosenLevel.finishedTable[i].delay);
        }
        // Runda konczy sie kiedy wszystkie cele sie pojawia oraz wszystkie znikna
        yield return new WaitUntil(() => targetsContainer.childCount.Equals(2));

        roundNumber++;
        PlayDialogue();
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2);
        if (!fadeAnimator.GetCurrentAnimatorStateInfo(0).IsName("fade_out"))
        {
            fadeAnimator.SetTrigger("fade_out");
        }
    }
}