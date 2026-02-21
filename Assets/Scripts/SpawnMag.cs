using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnMag : MonoBehaviour
{
    public Vector3 originalRotation;

    [SerializeField] private GameObject magazinePrefab;

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
        currentMagazine.transform.parent = transform;
        currentMagazine.transform.SetPositionAndRotation(transform.position, transform.rotation);
        currentMagazine.transform.localScale = new Vector3(1, 1, 1);
        return currentMagazine;
    }

    //Funkcja uruchamiana przez animatorRef, animacja "Rotate Full" 
    public void FinishReloadAnimation()
    {
        gunScriptRef.FinishReload();
    }
}
