using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    private TargetBehaviour targetParent;
    void Start()
    {
        targetParent = GetComponentInParent<TargetBehaviour>();
    }

    protected virtual void OnMouseDown()
    {
        targetParent.OnClick();
    }
}

//Micha³ - kolejnym krokiem jest zrobiæ wariant tego, który nie przekazuje informacji o strzale, a liczy siê jako miss