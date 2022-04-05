using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LoadoutManager : MonoBehaviour
{
    public Weapon[] LoadoutOptions;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SelectLoadoutOption(int optionID)
    {
        FindObjectOfType<GameHandler>().selectedLoadout = optionID;
    }
}
