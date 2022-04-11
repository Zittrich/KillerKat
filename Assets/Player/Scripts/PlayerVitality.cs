using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerVitality : EnemyScript
{
    public bool IsBlocking;
    [SerializeField] private SceneAsset DeathScreen;
    [HideInInspector] public float blockingFactor = 0;

    public void TakeDamage(float dmgAmount)
    {
        HealthPoints -= IsBlocking ? dmgAmount * blockingFactor : dmgAmount;

        if (HealthPoints <= 0)
        {
            Debug.Log("Death");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(DeathScreen.name);
        }


    }

}
