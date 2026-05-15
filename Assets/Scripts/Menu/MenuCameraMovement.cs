using DG.Tweening;
using UnityEngine;

public class MenuCameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 lookAtPoint = Vector3.zero;
    [SerializeField] private float angle = 5f;
    [SerializeField] private float degreesPerSecond = 2f;

    private Vector3 startOffset;
    private float currentAngle;

    private void Start()
    {
        startOffset = transform.position - lookAtPoint;
        SetAngle(0f);

        float initialDuration = angle / degreesPerSecond;

        DOTween
            .To(() => currentAngle, SetAngle, -angle, initialDuration)
            .SetEase(Ease.InOutSine)
            .OnComplete(StartLoop);
    }

    private void StartLoop()
    {
        float loopDuration = (angle * 2f) / degreesPerSecond;

        DOTween
            .To(() => currentAngle, SetAngle, angle, loopDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void SetAngle(float value)
    {
        currentAngle = value;
        transform.position = lookAtPoint + Quaternion.Euler(0f, currentAngle, 0f) * startOffset;
        transform.LookAt(lookAtPoint);
    }
}
