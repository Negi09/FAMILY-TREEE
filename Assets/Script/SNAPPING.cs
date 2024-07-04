using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SNAPPING : MonoBehaviour
{
    [SerializeField]private  List<Transform> SnapPoints;
    [SerializeField]private  List<MOVEMENT> movable_items;
    public List<Text> helpingtext;
    [SerializeField] private Animation coincoll, hammercoll;
    int drop = 0;
    //[SerializeField]private Animation anim;
    [SerializeField]ParticleSystem wcon;
    float snaprange = .5f;
    private GameManager gm;
    [HideInInspector]public int cont;
    private void Start()
    {
        cont = movable_items.Count;
        gm=GameManager.instance;
        Debug.Log(movable_items.Count);

         
        
        foreach (MOVEMENT mv in movable_items)
        {
            mv.dragended = ondragended;
        }
    }

    public void ondragended(MOVEMENT movable)
    {
        float closestdistance = -1f;
        
        Transform closestsnappoint = null;
        int movableindex = movable_items.IndexOf(movable);
       
        foreach (Transform snappoint in SnapPoints)
        {
            bool snappoccupency = snapoccupied(snappoint);
            int snapindex = SnapPoints.IndexOf(snappoint);
            if (!snappoccupency)
            {
                if (snapindex == movableindex)
                {
                    
                    float currentdistance = Vector2.Distance(movable.transform.localPosition, snappoint.transform.localPosition);
                                                        
                    if (closestsnappoint == null || currentdistance < closestdistance)  //calculating the distance
                    {
                       
                        closestsnappoint = snappoint;
                        closestdistance = currentdistance;
                        
                        Debug.Log(drop);
                        Debug.Log("Placed");
                    }
                }
            }


            else
            {
                
                Debug.Log("Error ! NO SPACE FOUND");
            }


        }
        if (closestsnappoint != null && closestdistance <= snaprange) // dropping in snaplocation
        {         
           Vector3 newposition= closestsnappoint.localPosition;
            helpingtext[movableindex].enabled = false;     // disabling  the helping statements 
            if (!(helpingtext[movableindex].enabled = false))
            {
            
                drop += 1;
                Debug.Log("drop counted");
                Debug.Log(drop);
                print("statement   enabled h ..!");
            }

            movable.transform.localPosition = newposition;      
            movable.recordposition();
            Debug.Log(movable_items.Count);
         
            
        }
        else      // sending back to original position if snappoint is occupied
        {                     
            movable.transform.localPosition = movable.original;
            gm.live();
        }
        if (drop == cont)
        {
            Debug.Log("time for confetti to play.!!!");
            wcon.Play();//winning confetti 
            coincoll.Play();
            hammercoll.Play();
            
            Invoke("delayinload", 2f);//gm.loadlevel();
        }
    }
   
    public bool snapoccupied(Transform snappoint)  // checking whether snappoint is occupied or not ....
    {
        foreach(MOVEMENT mv in movable_items)
        {
            if (mv.transform.localPosition == snappoint.localPosition)
            {
                return true;
            }
           
        }
        return false;
    }

    
    void delayinload() // for  using invoke 
    {
        gm.Loadlevel();
    }
    





}
