using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MOVEMENT: MonoBehaviour
{
    Vector3 startpoint, StartPosition; 
    bool drag;
    [HideInInspector] public Vector3 original;
    public delegate void dragendeddelegate(MOVEMENT movable_items);
    public dragendeddelegate dragended;
    
    
    public static MOVEMENT instance;

    private void Awake()
    {
        instance = this;
    }

    
    private void Start()
    {
        recordposition();
       // Debug.Log("movement start");
    }

    public void recordposition()
    {
        original = gameObject.transform.position;
    }
    private void OnMouseDown()
    {
        drag = true;
        Vector3 startposition = gameObject.transform.position;
        startpoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        // Debug.Log("MOUSE DOWN");
    }
    private void OnMouseDrag()
    { if (drag)
        {
            Vector3 currposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, startpoint.z);
            Vector3 currpoint = Camera.main.ScreenToWorldPoint(currposition);
            
            transform.position = currpoint;
           // Debug.Log("WORKING UNDER DRAG ....");

            // transform.localPosition = startpoint + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - StartPosition);  

        }
        //Debug.Log("DRAG");
        
    }

    private void OnMouseUp()
    {
        drag = false;
        dragended(this);
        //idchk(this);
       // Debug.Log("MOUSE UP");
        
    }
    

   

}
