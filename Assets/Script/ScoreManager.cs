using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TrunManager m_turnmanager;


    public int Run;
    public int Wicket = 10;
    public int Over = 20;
    public float Ball = 120;

  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnCollisionEnter(Collision coll)
    {
        // Check if the object is already processed
        if (!m_turnmanager.Ismoving )
        {
            if (coll.gameObject.tag == "Six")
            {
                Run += 6;
            }
            else if (coll.gameObject.tag == "Four")
            {
                Run += 4;
            }
            else if (coll.gameObject.tag == "Short Run")
            {
                Run += 1;
            }
            else if (coll.gameObject.tag == "Leg By")
            {
                Run += 2;
            }
            else if (coll.gameObject.tag == "Out")
            {
                Wicket -= 1;
            }
            else if (coll.gameObject.tag == "Wide Ball")
            {
                // Handle wide ball if needed
            }
            else if (coll.gameObject.tag == "No Ball")
            {
                // Handle no ball if needed
            }
        }
    }

 
}
