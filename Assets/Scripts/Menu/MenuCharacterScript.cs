using System.Collections;
using UnityEngine;

public class MenuCharacterScript : MonoBehaviour
{
    [SerializeField] private Transform handWithGunRef;
    [SerializeField] private float originalGunRotation = 70f;
    [SerializeField] private Vector2 specialAnimationTimeRange = new Vector2(8f, 16f);
    [SerializeField] private int numberOfSpecialAnimations = 2;

    private Animator animatorRef;

    private void Start()
    {
        animatorRef = GetComponent<Animator>();

        StartCoroutine(PlaySpecialAnimation());
    }

    private IEnumerator PlaySpecialAnimation()
    {
        float randomTime = Random.Range(specialAnimationTimeRange.x, specialAnimationTimeRange.y);
        yield return new WaitForSeconds(randomTime);

        int randomAnimation = Random.Range(0, numberOfSpecialAnimations) + 1;
        animatorRef.SetInteger("SpecialAnimation", randomAnimation);

        yield return null;
        animatorRef.SetInteger("SpecialAnimation", 0);

        StartCoroutine(PlaySpecialAnimation());
    }
}
