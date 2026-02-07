using UnityEngine;

public class TargetHoleCollider : MonoBehaviour
{
    private TargetBehaviour targetParent;
    private GunScript gun;
    private void Start()
    {
        targetParent = GetComponentInParent<TargetBehaviour>();
        gun = targetParent.gun;
    }

    private void OnMouseDown()
    {
        gun.ShotFired();
        WinCheck.Instance.Missed();
    }
}
