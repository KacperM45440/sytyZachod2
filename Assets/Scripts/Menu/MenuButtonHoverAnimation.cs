using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtonHoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float additionalRotation = 5f;
    [SerializeField] private float rotationSpeed = 0.8f;

    private Button buttonRef;
    private Vector3 rotationDefault;
    private Vector3 rotationTarget;
    private void Start()
    {
        buttonRef = GetComponent<Button>();

        rotationDefault = rectTransform.localEulerAngles;

        float z = NormalizeAngle(rotationDefault.z);
        rotationTarget = new Vector3(rotationDefault.x, rotationDefault.y, -z);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (buttonRef.interactable)
        {
            rectTransform.DOKill();
            rectTransform.DOLocalRotate(rotationTarget, rotationSpeed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (buttonRef.interactable)
        {
            rectTransform.DOKill();
            rectTransform.DOLocalRotate(rotationDefault, 0.5f).SetEase(Ease.OutBack);
        }
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
