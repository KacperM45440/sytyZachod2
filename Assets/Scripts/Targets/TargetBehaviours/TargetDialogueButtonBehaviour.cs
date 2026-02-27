using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDialogueButtonBehaviour : TargetBehaviour
{
    private DialogueController dialogueControllerRef;

    protected override void Start()
    {
        base.Start();
    }

    public void InitializeDialogueTarget(DialogueController controllerRef)
    {
        dialogueControllerRef = controllerRef;
        gun = controllerRef.gunScriptRef;
        destroyQueue = controllerRef.targetDestroyQueue;
    }

    public override void OnClick()
    {
        if (gun.readyToFire)
        {
            gun.ShotFired();
            animatorRef.speed = 1;
            dialogueControllerRef.ShowNextLine();
            StartCoroutine(DestroyMe());
        }
    }

    public override void FinishedMovement()
    {
    }
}
