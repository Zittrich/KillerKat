using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int ItemID;

    public float PrimaryAttackRange;
    public int PrimaryAttackDamage;
    public float PrimaryCooldown;
    public AudioClip[] PrimaryHitSound;
    public AudioClip[] PrimaryMissSound;

    public float SecondaryAttackRange;
    public int SecondaryAttackDamage;
    public float SecondaryCooldown;
    public AudioClip[] SecondaryHitSound;
    public AudioClip[] SecondaryMissSound;

    private float _lastTime;
    private EnemyScript _thisEnemy;
    private AudioSource _audioSource;
    private WeaponSource _weaponSource;
    private ParticleSystem _thisBlood;
    readonly System.Random _random = new System.Random();

    protected void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _lastTime = float.MinValue;

        try
        {
            _weaponSource = GetComponentInChildren<WeaponSource>();
        }
        catch (Exception weaponSourceNotDefined)
        {
            Debug.Log(weaponSourceNotDefined);
            throw;
        }
    }

    public virtual void PrimaryAttack()
    {
        if(_lastTime + PrimaryCooldown <= Time.time)
        {
            _lastTime = Time.time;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, _weaponSource.transform.TransformDirection(Vector3.forward), out hit,
                    PrimaryAttackRange))
            {
                if (hit.transform.gameObject.GetComponent<EnemyScript>())
                {

                    _thisEnemy = hit.transform.gameObject.GetComponent<EnemyScript>();

                    _thisEnemy.HealthPoints -= PrimaryAttackDamage;
                    if (_thisEnemy.HealthPoints <= 0)
                        _thisEnemy.Death();

                    PlaySound(PrimaryHitSound);

                    _thisBlood = Instantiate(_thisEnemy.Blood, hit.point, _thisEnemy.Blood.transform.rotation, hit.transform);
                    _thisBlood.Play();

                    Debug.Log(_thisEnemy.HealthPoints);
                    Debug.Log("Did Hit");
                }
                else
                {
                    PlaySound(PrimaryMissSound);
                    Debug.Log("Did not Hit");
                }
            }
            else
            {
                Debug.Log("Did not Hit");
                PlaySound(PrimaryMissSound);
            }
        }
        else
        {
            CooldownTrigger();
        }
    }

    public virtual void SecondaryAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, SecondaryAttackRange))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void CooldownTrigger()
    {
        Debug.Log(_lastTime + PrimaryCooldown - Time.time);
    }

    protected void PlaySound(AudioClip[] audioClip)
    {
        _audioSource.clip = audioClip[_random.Next(0, audioClip.Length)];
        _audioSource.Play();
    }
    protected void PlaySound(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}
