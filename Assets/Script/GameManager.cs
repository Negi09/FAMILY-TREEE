using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public List<GameObject> lives;

    private MISCLANNEOUS m;
    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        m = MISCLANNEOUS.instance;
    }
    private void Update()
    {
        m.back();
        
    }

    int i = 0;
    public void live()
    {

        lives[i].SetActive(false);
        i += 1;
        if (i == 3)
        {
            restart();
        }

    }


    public void restart()
    {
        Debug.Log("RESTART");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Loadlevel()
    {
        Debug.Log("NEXT LEVEL");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

    
   
 

    /*public void OnApplicationPause(bool pause)
    {
        Time.timeScale = 0;
    }
}*/


