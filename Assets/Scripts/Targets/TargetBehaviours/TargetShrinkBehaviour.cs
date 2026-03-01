using DG.Tweening;
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
            int i = Random.Range(0, 2) * 2 - 1;
            parentTransform.DOScale(parentTransform.localScale * scaleShrink, 0.3f).SetEase(Ease.OutBack)
                .SetLink(parentTransform.gameObject);
            parentTransform.DORotate(new Vector3(0, 0, parentTransform.eulerAngles.z + (i * 360f)), 0.3f, RotateMode.FastBeyond360)
                .SetEase(Ease.OutBack)
                .SetLink(parentTransform.gameObject);
            gun.ShotFired();
        }
        else
        {
            base.OnClick();
        }
    }
}
