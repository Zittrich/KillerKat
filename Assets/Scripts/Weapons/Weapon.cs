using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int LightAttackRange;
    public int LightAttackDamage;

    public int HeavyAttackRange;
    public int HeavyAttackDamage;

    public AudioClip HitSound;
    public AudioClip MissSound;

    private EnemyScript _thisEnemy;

    public void SimpleAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, LightAttackRange))
        {
            if (hit.transform.gameObject.GetComponent<EnemyScript>())
            {
                
                _thisEnemy = hit.transform.gameObject.GetComponent<EnemyScript>();
                _thisEnemy.HealthPoints -= LightAttackDamage;
                if (_thisEnemy.HealthPoints <= 0)
                    _thisEnemy.Death();

                Debug.Log(_thisEnemy.HealthPoints);
            }
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white,5);
            Debug.Log("Did not Hit");
        }
    }

    public void HardAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, HeavyAttackRange))
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
}
