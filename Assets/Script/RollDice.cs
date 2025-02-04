using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public GameObject Dice;
    GameManager GM;
    public int Dicecount;
    int rot;
    public bool Isrotating = false;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        StartCoroutine(RotateDice());
        Isrotating = true;


    }

    bool bIsOn = true;
    public bool bIsUnderChecking = false;

    // Update is called once per frame
    void Update()
    {
        if (bIsOn && !bIsUnderChecking)
        {
            bIsOn = false;
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
            StartCoroutine(ResetOn());

        }
    }

    IEnumerator ResetOn()
    {
        yield return new WaitForSeconds(0.3f);
        bIsOn = true;
    }

    public IEnumerator RotateDice()
    {
        while (true)
        {

            yield return new WaitForSeconds(60f);

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
