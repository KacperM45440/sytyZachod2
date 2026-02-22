using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnMag : MonoBehaviour
{
    [HideInInspector] public Vector3 originalRotation;

    [SerializeField] private GameObject magazinePrefab;
    [SerializeField] private Transform magazineParent;

    private GunScript gunScriptRef;

    private void Start()
    {
        // Zapisz i przekaz obrot tak, aby pociski znajdowaly sie w dobrym miejscu w cylindrze
        originalRotation = transform.localEulerAngles;
    }

    public void Initialize(GunScript gunScript)
    {
        gunScriptRef = gunScript;
    }

    public GameObject NewMagazine()
    {
        // Stworz nowy magazynek z prefabu, a nastepnie doklej go do cylindra
        GameObject currentMagazine = Instantiate(magazinePrefab);
        currentMagazine.transform.SetPositionAndRotation(transform.position, transform.rotation);
        currentMagazine.transform.parent = magazineParent;
        //transform.position += new Vector3(0, 0, -0.1f);
        currentMagazine.transform.localScale = new Vector3(100, 100, 1);
        return currentMagazine;
    }

    //Funkcja uruchamiana przez animatorRef, animacja "Rotate Full" 
    public void FinishReloadAnimation()
    {
        gunScriptRef.FinishReload();
    }
}
