using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetFastBehaviour : TargetBehaviour
{
    private ParticleSystem particlesRef;

    protected override void Start()
    {
        base.Start();
        particlesRef = GetComponentInChildren<ParticleSystem>();
    }

    private void OnDisable()
    {
        particlesRef.transform.parent = targetParent;
        particlesRef.Stop();
    }
}
