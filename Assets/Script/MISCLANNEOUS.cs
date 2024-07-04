using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MISCLANNEOUS : MonoBehaviour
{
    // Start is called before the first frame update
    public static MISCLANNEOUS instance;
    [SerializeField] private  GameObject quit;
    private void Awake()
    {

        instance = this;  
    }
    public void back()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            int touch = 0;
            if (Input.GetKey(KeyCode.Escape))
            {
                touch += 1;
                if (touch == 1)
                {
                    SceneManager.LoadScene(0);
                }
                else if (touch > 1)
                {
                    quit.SetActive(true);
                }


            }
        }
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}

