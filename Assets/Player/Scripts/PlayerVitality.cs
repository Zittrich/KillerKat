using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitality : EnemyScript
{
    public bool IsBlocking;
    [HideInInspector] public float blockingFactor = 0;

    public void TakeDamage(int dmgAmount)
    {
        HealthPoints -= IsBlocking ? dmgAmount * blockingFactor : dmgAmount;
    }
}
