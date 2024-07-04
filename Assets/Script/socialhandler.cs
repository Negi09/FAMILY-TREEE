using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class socialhandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void handle(string Url)
    {
        Application.OpenURL( Url);
    }
}
