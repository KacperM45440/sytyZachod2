using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    public Transform targetDestroyQueue;
    public GunScript gunScriptRef;

    [SerializeField] private SpawnTarget spawnTargetRef;
    [SerializeField] private Animator charactersAnimatorRef;
    [SerializeField] private TMP_Text dialogueTextRef;
    [SerializeField] private GameObject prefabDialogueTarget;
    [SerializeField] private Transform targetsParent;
    [SerializeField] private Transform spawnSpotTarget;
    [SerializeField] private float textAppearSpeed = 0.02f;

    private List<string> dialogue = new();
    private bool firstDialogue = true;

    private void Start()
    {
        dialogueTextRef.text = "";
    }

    public void DisplayDialogue(List<string> newDialogue)
    {
        if (newDialogue.Count == 0 || newDialogue == null)
        {
            FinishDialogue();
            return;
        }

        dialogue = newDialogue;
        if (firstDialogue)
        {
            firstDialogue = false;
        }
        else
        {
            charactersAnimatorRef.SetTrigger("MoveIn");
        }
        StartCoroutine(WaitThenShowText());
    }

    private IEnumerator WaitThenShowText()
    {
        yield return new WaitForSeconds(1.5f);
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if(dialogue.Count == 0)
        {
            FinishDialogue();
            return;
        }
        dialogueTextRef.text = dialogue[0];

        StartCoroutine(TextAppearAnimation());
    }


    private IEnumerator TextAppearAnimation()
    {
        string fullText = dialogue[0];

        for (int i = 0; i <= fullText.Length; i++)
        {
            dialogueTextRef.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(textAppearSpeed);
        }
        dialogue.RemoveAt(0);
        yield return new WaitForSeconds(0.5f);
        TextFinishAppearing();
    }

    private void TextFinishAppearing()
    {
        GameObject newTarget = Instantiate(prefabDialogueTarget, spawnSpotTarget.position, transform.rotation, targetsParent);
        newTarget.GetComponentInChildren<TargetDialogueButtonBehaviour>().InitializeDialogueTarget(this);
    }

    private void FinishDialogue()
    {
        charactersAnimatorRef.SetTrigger("MoveOut");
        dialogueTextRef.text = "";
        spawnTargetRef.StartRound();
    }
}
