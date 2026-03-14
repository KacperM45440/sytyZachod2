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
    [SerializeField] private float textAppearSpeed;
    [SerializeField] private float fontSizeIncrease;
    [SerializeField] private float dialogueTargetSpawnVariation = 1f;

    private List<string> dialogue = new();
    private Vector2 shakyTextBounds = new Vector2(-1, -1);
    private bool charactersInView = true;
    private bool finalDialogue = false;
    private float defaultFontSize;

    private void Start()
    {
        dialogueTextRef.text = "";
        defaultFontSize = dialogueTextRef.fontSize;
    }

    private void LateUpdate()
    {
        if(dialogueTextRef.text.Length > 0)
        {
            dialogueTextRef.ForceMeshUpdate();
            TMP_TextInfo textInfo = dialogueTextRef.textInfo;
            for (int i = 0; i < textInfo.characterCount; i++)
            {
                if (i < shakyTextBounds.x || i >= shakyTextBounds.y) continue;
                TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible) continue;

                Vector3[] verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                float shakeAmount = 2f;
                float speed = 30f;

                float phase = charInfo.index * 0.5f;
                float offsetX = Mathf.Sin(Time.time * speed + phase) * shakeAmount;
                float offsetY = Mathf.Sin(Time.time * speed * 1.3f + phase) * shakeAmount;

                Vector3 shakeOffset = new Vector3(offsetX, offsetY, 0f);

                for (int j = 0; j < 4; j++)
                {
                    Vector3 originalPos = verts[charInfo.vertexIndex + j];
                    verts[charInfo.vertexIndex + j] = originalPos + shakeOffset;
                }
            }

            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                TMP_MeshInfo meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                dialogueTextRef.UpdateGeometry(meshInfo.mesh, i);
            }
        }
    }

    public void MoveCharacters(bool intoView)
    {
        if (intoView && !charactersInView)
        {
            charactersAnimatorRef.SetTrigger("MoveIn");
            charactersInView = true;
        }
        else if (!intoView && charactersInView)
        {
            charactersAnimatorRef.SetTrigger("MoveOut");
            charactersInView = false;
        }  
    }

    public void DisplayDialogue(List<string> newDialogue, bool lastDialogue)
    {
        finalDialogue = lastDialogue;
        if (newDialogue.Count == 0 || newDialogue == null)
        {
            FinishDialogue();
            return;
        }

        dialogue = newDialogue;
        MoveCharacters(true);

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

        charactersAnimatorRef.SetTrigger("StartTalking");
        StartCoroutine(TextAppearAnimation());
    }


    private IEnumerator TextAppearAnimation()
    {
        string fullText = dialogue[0];
        shakyTextBounds = new Vector2(-1, -1);
        dialogueTextRef.fontSize = defaultFontSize;

        int asteriskCount = 0;
        for (int i = 0; i < fullText.Length; i++)
        {
            switch (fullText[i])
            {
                case '*':
                    asteriskCount++;
                    switch (asteriskCount)
                    {
                        case 1:
                            shakyTextBounds = new Vector2(i, 255);
                            break;
                        case 2:
                            shakyTextBounds = new Vector2(shakyTextBounds.x, i);
                            break;
                        default:
                            Debug.LogError("Too many asterisks in dialogue line: " + fullText);
                            break;
                    }
                    fullText = fullText.Remove(i, 1);
                    i--;
                    continue;
                case '^':
                    dialogueTextRef.fontSize += fontSizeIncrease;

                    fullText = fullText.Remove(i, 1);
                    i--;
                    continue;
                default:
                    break;
            }
            dialogueTextRef.text = fullText.Substring(0, i + 1);
            yield return new WaitForSeconds(textAppearSpeed);
        }
        dialogue.RemoveAt(0);

        yield return new WaitForSeconds(0.5f);
        TextFinishAppearing();
    }

    private void TextFinishAppearing()
    {
        charactersAnimatorRef.SetTrigger("StopTalking");

        float a = dialogueTargetSpawnVariation;
        Vector3 spawnPosition = spawnSpotTarget.position + new Vector3(Random.Range(-a, a), Random.Range(-a, a));
        GameObject newTarget = Instantiate(prefabDialogueTarget, spawnPosition, transform.rotation, targetsParent);

        newTarget.GetComponentInChildren<TargetDialogueButtonBehaviour>().InitializeDialogueTarget(this);
    }

    private void FinishDialogue()
    {
        if(!finalDialogue)
        {
            MoveCharacters(false);
        }
        dialogueTextRef.text = "";
        spawnTargetRef.StartRound();
    }
}
