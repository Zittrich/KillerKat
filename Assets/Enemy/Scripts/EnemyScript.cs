using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float HealthPoints;
    public AudioClip DeathSound;
    public ParticleSystem Blood;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void Death()
    {
        _audioSource.clip = DeathSound;
        _audioSource.Play();

        Destroy(gameObject);
    }
}
