using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShrinkBehaviour : TargetBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private float scaleShrink = 0.85f;
    private Transform parentTransform;

    protected override void Start()
    {
        base.Start();
        parentTransform = transform.parent;
    }

    public override void OnClick()
    {
        if (!gun.readyToFire)
        {
            return;
        }

        if (health > 1)
        {
            health--;
            parentTransform.localScale *= scaleShrink;
            gun.ShotFired();
        }
        else
        {
            base.OnClick();
        }
    }
}
