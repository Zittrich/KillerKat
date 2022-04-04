using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int HealthPoints;
    public void Death()
    {
        Destroy(gameObject);
    }
}
