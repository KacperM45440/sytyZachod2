using UnityEngine;
using DG.Tweening;

public class BananaSplatEffect : MonoBehaviour
{
    [SerializeField] private Vector2 splatRange = new Vector2(1f, 0.5f);
    [SerializeField] private float scaleTo = 1f;
    [SerializeField] private float timeToSplat = 0.3f;
    [SerializeField] private float timeToDisappear = 2f;
    private SpriteRenderer rendererRef;
    private void Start()
    {
        rendererRef = GetComponentInChildren<SpriteRenderer>();

        Splat();
    }
    //wybiera losowy punkt w zasiêgu
    //porusza siê w jego stronê jednoczeœnie powiêkszaj¹c
    //natychmiast po zatrzymaniu siê zaczyna zmniejszaæ siê jego opacity
    //jak osi¹gnie zero jest usuwany
    private void Splat()
    {
        rendererRef.flipX = Random.value > 0.5f;
        rendererRef.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));
        rendererRef.transform.localScale = Vector3.zero;
        Vector2 targetLocation = new Vector2(Random.Range(-splatRange.x, splatRange.x), Random.Range(-splatRange.y, splatRange.y));

        rendererRef.transform.DOMove(targetLocation, timeToSplat / 2);
        rendererRef.transform.DOScale(scaleTo, timeToSplat).SetEase(Ease.OutBack).OnComplete(() =>
            rendererRef.DOFade(0f, timeToDisappear).SetEase(Ease.InQuint).OnComplete(() =>
                Destroy(gameObject)));
    }
}
