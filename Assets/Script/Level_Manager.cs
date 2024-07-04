using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI next_lvl;
    [SerializeField] private TextMeshProUGUI curr_lvl;
    [SerializeField] private TextMeshProUGUI pre_lvl;
    [SerializeField] private  GameObject Prev_Lvl;

    

    private void Start()
    {
        Lvl_Mng();
        prelvlchecker();
    }
    void Lvl_Mng()
    {
        int currentlevel = GetComponent<menu>().crrLevel;
        curr_lvl.text = currentlevel.ToString();
        Debug.Log(curr_lvl);
        next_lvl.text = (currentlevel + 1).ToString();
        Debug.Log(next_lvl);
        pre_lvl.text = (currentlevel - 1).ToString();
        Debug.Log(pre_lvl);
    }
        void prelvlchecker()
    {
        string txtvalue = pre_lvl.text;
        int textvalue = Int32.Parse(txtvalue);
        if ( textvalue>=1) 
        {
            Prev_Lvl.SetActive(true);
        }
        else
        {
            Prev_Lvl.SetActive(false);
        }
    }

}
