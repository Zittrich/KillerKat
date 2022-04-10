using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitality : EnemyScript
{
    public bool IsBlocking;
    [HideInInspector] public float blockingFactor = 0;

    public void TakeDamage(float dmgAmount)
    {
        HealthPoints -= IsBlocking ? dmgAmount * blockingFactor : dmgAmount;

        if (HealthPoints <= 0)
            Death();
    }
}
