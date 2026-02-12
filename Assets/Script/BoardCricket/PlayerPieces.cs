using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerPieces : MonoBehaviour
{
    public CricketEvents cricketEvents;
    public bool IsTeamblueturn;
    public bool IsTeamredturn;
    public int numberofstepstomove;

    public Gridholder gridholder;

   

    public void Awake()
    {
        gridholder =  GameObject.FindObjectOfType<Gridholder>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void PawnMove(int initialpos)
    {
        numberofstepstomove = 5;
        int targetpos = initialpos + numberofstepstomove;
        StartCoroutine(MovePawnstepBystep(initialpos, targetpos));
    }

    private IEnumerator MovePawnstepBystep(int startpos, int targetpos)
    {
        gridholder.totalgrid = gridholder.pathpoint.Length;
        for (int i = startpos; i < targetpos; i++)
        {
            gridholder.currentgrid = (i) % gridholder.totalgrid;
            if (i != targetpos)
            {

                transform.position = gridholder.pathpoint[gridholder.currentgrid].transform.position + new Vector3(0, 0, -5);
                yield return new WaitForSeconds(0.35f);
            }
        }
        cricketEvents.Triggerevents();
        movenow = false;
    }

  

}
