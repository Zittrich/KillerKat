using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public int selectedLoadout;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
