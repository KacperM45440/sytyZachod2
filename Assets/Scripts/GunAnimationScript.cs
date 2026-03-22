using UnityEngine;

public class GunAnimationScript : MonoBehaviour
{
    private ParticleSystem particleSystemRef;
    private void Start()
    {
        particleSystemRef = GetComponentInChildren<ParticleSystem>();
    }

    //Triggered via animation event
    public void PlayParticles()
    {
        particleSystemRef.Play();
    }
}
