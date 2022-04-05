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

    public float SecondaryAttackRange;
    public int SecondaryAttackDamage;
    public float SecondaryCooldown;

    public AudioClip[] HitSound;
    public AudioClip[] MissSound;

    private float _lastTime;
    private EnemyScript _thisEnemy;
    private AudioSource _audioSource;
    private WeaponSource _weaponSource;
    private System.Random _random = new System.Random();

    void Start()
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

    public void PrimaryAttack()
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

                    Debug.Log(_thisEnemy.HealthPoints);

                    _audioSource.clip = HitSound[_random.Next(0, HitSound.Length)];
                    _audioSource.Play();

                    Debug.Log("Did Hit");
                }
                else
                {
                    _audioSource.clip = MissSound[_random.Next(0, MissSound.Length)];
                    _audioSource.Play();
                    Debug.Log("Did not Hit");
                }
            }
            else
            {
                Debug.DrawRay(transform.position, _weaponSource.transform.TransformDirection(Vector3.forward) * 1000, Color.white, 5);
                Debug.Log("Did not Hit");

                _audioSource.clip = MissSound[_random.Next(0, MissSound.Length)];
                _audioSource.Play();
            }
        }
        else
        {
            CooldownTrigger();
        }
    }

    public void SecondaryAttack()
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
}
