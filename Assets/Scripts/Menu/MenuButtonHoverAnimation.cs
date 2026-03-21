using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonHoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float additionalRotation = 5f;
    [SerializeField] private float rotationSpeed = 0.8f;

    private Vector3 rotationDefault;
    private Vector3 rotationTarget;
    private void Start()
    {
        rotationDefault = rectTransform.localEulerAngles;

        float z = NormalizeAngle(rotationDefault.z);
        rotationTarget = new Vector3(rotationDefault.x, rotationDefault.y, -z);

        Debug.Log("Default rotation: " + rotationDefault);
        Debug.Log("Target rotation: " + rotationTarget);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        rectTransform.DOKill();
        rectTransform.DOLocalRotate(rotationTarget, rotationSpeed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        rectTransform.DOKill();
        rectTransform.DOLocalRotate(rotationDefault, 0.5f).SetEase(Ease.OutBack);
    }


    private float NormalizeAngle(float angle)
    {
        if (angle > 180f)
        {
            angle -= 360f + additionalRotation;
        }
        else
        {
            angle += additionalRotation;
        }
        return angle;
    }

}
