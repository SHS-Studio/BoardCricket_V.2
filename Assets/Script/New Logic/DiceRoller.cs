using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public GameObject Dice;
    public int Dicecount;
  
    int rot;
   
    public bool Isrotating = false;
    public bool movepawn;
   
    public float DiceTimer;
    public float resetDiceTimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        diceRotatedMechanism();
        StopDiceRotation();
    }

    public void diceRotatedMechanism()
    {
        if (Isrotating)
        {
            rot = Random.Range(1, 3);
            switch (rot)
            {
                case 1:

                    Dice.transform.Rotate(Vector3.forward * 90f);

                    break;

                case 2:

                    Dice.transform.Rotate(Vector3.right * 90);

                    break;

                   

            }
        }
       
    }

    public void StopDiceRotation()
    {
      
       if (Isrotating)
       {
            DiceTimer -= Time.deltaTime;
            if (DiceTimer <= 0)
            {
                Isrotating = false;
                GetDiceCount();
                movepawn = true;
                DiceTimer = resetDiceTimer;
            }
         
       }
      
    }

    public void GetDiceCount()
    {
        if (Vector3.Dot(transform.forward, -Vector3.forward) >= 1)
        {
            Dicecount = 1;
        }
        if (Vector3.Dot(-transform.forward, -Vector3.forward) >= 1)
        {
            Dicecount = 6;
        }
        if (Vector3.Dot(transform.right, -Vector3.forward) >= 1)
        {
            Dicecount = 5;
        }
        if (Vector3.Dot(-transform.right, -Vector3.forward) >= 1)
        {
            Dicecount = 2;
        }
        if (Vector3.Dot(transform.up, -Vector3.forward) >= 1)
        {
            Dicecount = 4;
        }
        if (Vector3.Dot(-transform.up, -Vector3.forward) >= 1)
        {
            Dicecount = 3;
        }
    }
}
