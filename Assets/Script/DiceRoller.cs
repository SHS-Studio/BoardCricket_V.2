using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public TrunManager m_turnmanager;
    public GameObject Dice; // Reference to the dice GameObject
    private int rot; // For random rotation
    public int Dicecount;
    public float rotateTime = 2.0f; // Duration to rotate the dice
    public float rotateSpeed = 360f; // Speed of rotation (degrees per second)


    public bool isRotating;
 

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DiceRotationLogic()
    {

        rot = Random.Range(1, 3);
        switch (rot)
        {
            case 1:
                Dice.transform.Rotate(Vector3.forward * 90f);
                break;
            case 2:
                Dice.transform.Rotate(Vector3.right * 90f);
                break;
        }

        StartCoroutine(ResetOn());
        // isRotating = false;
    }

    IEnumerator ResetOn()
    {
        yield return new WaitForSeconds(0.5f); 
    
    }


    public IEnumerator RotateDiceForSeconds()
    {
        if (!isRotating)
        {

            float elapsedTime = 0f;

            while (elapsedTime < rotateTime)
            {
                elapsedTime += Time.deltaTime;
                isRotating = true;
                DiceRotationLogic();
               
                yield return null;
             
            }
            isRotating = false;
            GetDiceCount();
            m_turnmanager.MovePlayer();
            m_turnmanager.ismoving();
            m_turnmanager.EndTurn();
            m_turnmanager.isTurnOver = true;
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

