using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float HealthPoints;
    public AudioClip DeathSound;
    public ParticleSystem Blood;

    private AudioSource _audioSource;

    protected void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public virtual void Death()
    {
        PlayDeathSound();

        Destroy(gameObject.GetComponentInParent<Transform>().gameObject);
        Destroy(gameObject);
    }

    public virtual void PlayDeathSound()
    {
        _audioSource.clip = DeathSound;
        _audioSource.Play();
    }
}
