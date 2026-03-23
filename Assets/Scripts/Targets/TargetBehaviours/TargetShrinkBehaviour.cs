using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShrinkBehaviour : TargetBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private float scaleShrink = 0.85f;
    
    private Transform spriteTransform;
    private Transform parentTransform;

    protected override void Start()
    {
        base.Start();
        parentTransform = transform.parent;
        spriteTransform = targetRendererRef.transform;
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
            //@Kacper: Jeœli chcesz, aby ten target nie zwalnia³ po strzelaniu w niego
            //to trzeba tutaj zmieniæ DOScale na spriteTransform zamiast transform. Tylko pamiêtaj, aby jednoczeœnie zmieniæ Collidera rozmiar
            transform.DOScale(transform.localScale * scaleShrink, 0.3f).SetEase(Ease.OutBack)
                .SetLink(parentTransform.gameObject);
            spriteTransform.DORotate(new Vector3(0, 0, spriteTransform.eulerAngles.z + (i * 360)), 0.3f, RotateMode.FastBeyond360)
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
