using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetSplatBehaviour : TargetBehaviour
{
    [SerializeField] private GameObject splatPrefab;

    public override void OnClick()
    {
        if (gun.readyToFire)
        {
            GameObject newSplat = Instantiate(splatPrefab, transform.position, Quaternion.identity, targetParent);
            base.OnClick();
        }
    }
}
