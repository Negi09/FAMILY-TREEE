using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
     public  GameObject coin, hammer;
    void Start()
    {
        DontDestroyOnLoad(coin);
        DontDestroyOnLoad(hammer);
    }

    
}
