using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetSplatBehaviour : TargetBehaviour
{
    [SerializeField] private GameObject splatPrefab;
    private Transform enemiesTransform;

    protected override void Start()
    {
        base.Start();
        //To powinno pobraæ element Enemies transform z gameControllera, aby nie korzystaæ z Find
        enemiesTransform = GameObject.Find("Enemies").transform;
    }

    public override void OnClick()
    {
        if (gun.readyToFire)
        {
            GameObject newSplat = Instantiate(splatPrefab, transform.position, Quaternion.identity, enemiesTransform);
            base.OnClick();
        }
    }
}
