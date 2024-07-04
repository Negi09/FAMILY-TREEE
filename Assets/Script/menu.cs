using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI hammer;
    public TextMeshProUGUI coin;
    [HideInInspector] public  int crrLevel;
    
    private void Start()
    {
        if (PlayerPrefs.GetInt("onlyonce")==0)
        {
            PlayerPrefs.SetInt("onlyonce", 1);

            PlayerPrefs.SetInt("crrLevelPref", 1);

        }

         crrLevel = PlayerPrefs.GetInt("crrLevelPref");
    }
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void collect_win()
    {
        hammer.text += 10.ToString();
       
        coin.text += 20.ToString();

    }
   
}
