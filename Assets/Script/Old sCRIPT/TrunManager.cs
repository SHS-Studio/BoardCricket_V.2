using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunManager : MonoBehaviour
{
    DiceRoller m_diceroller;
    public Transform[] Grids;
   
    public GameObject[] Pawn;

    public int P1_pos;
    public int P2_pos ;

    public bool isTurnOver;
    public bool Ismoving;
    float m_Timer;

    int steps;
    int totalGrids;
    public  int currentGrid;
    // Enum for the players
    public enum Player
    {
        NONE,
        Player1,
        Player2
    }

  
    public Player currentPlayer;


    public float timeLimit = 5f;
    public float timer;


    void Start()
    {
        m_diceroller = GameObject.FindObjectOfType<DiceRoller>();

        currentPlayer = Player.Player1;
        timer = timeLimit;

        Pawn[0].transform.position = Grids[P1_pos].transform.position;
        Pawn[1].transform.position = Grids[P2_pos].transform.position;

     

    }

    // Update is called once per frame
    void Update()
    {
        ChangeTurn();
        COLOR_BLINK();
    }

    public void MovePlayer()
    {
        Ismoving = true;
        if (currentPlayer == Player.Player1)
        {
            steps = m_diceroller.Dicecount;
            StartCoroutine(MovePawnStepByStep(Pawn[0], P1_pos, P1_pos + steps));
            P1_pos = (P1_pos += steps) % Grids.Length;
          
        }

        if (currentPlayer == Player.Player2)
        {
            steps = m_diceroller.Dicecount;
            StartCoroutine(MovePawnStepByStep(Pawn[1], P2_pos, P2_pos + steps));
            P2_pos = (P2_pos += steps) % Grids.Length;
          
        }
       
    }
    private IEnumerator MovePawnStepByStep(GameObject pawn, int startPos, int targetPos)
    {
        totalGrids = Grids.Length;
        for (int i = startPos; i < targetPos; i++)
        {
            currentGrid = (i + 1) % totalGrids;
            if (i != targetPos)
            {
                pawn.transform.position = Grids[currentGrid].transform.position;
                yield return new WaitForSeconds(0.3f); // Pause between moves
            }
          
        }
    }
    public void EndTurn()
    {
        timer = timeLimit;
        if (currentPlayer == Player.Player1)
        {
            currentPlayer = Player.Player2;
            Debug.Log( currentPlayer );
        }
        else
        {
            currentPlayer = Player.Player1;
            Debug.Log(currentPlayer);
        }
     
    }
    public void OnRollDiceButtonClick()
    {
        //StartCoroutine(m_diceroller.RotateDiceForSeconds());
        StartCoroutine("WaitforDicecount");
          isTurnOver = false;

    }
    public void ChangeTurn()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            EndTurn();
        }
    }
    public void COLOR_BLINK()
    {
        
        if (m_Timer <= 0)
        {
            m_Timer = 100;
        }
        if (currentPlayer == Player.Player1 )
        {
            Pawn[0].GetComponent<SpriteRenderer>().color = Color.yellow;
            m_Timer -= 1;
            if (m_Timer >= 50)
            {
                Pawn[0].GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                Pawn[0].GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
        else if (currentPlayer == Player.Player2 )
        {
            Pawn[1].GetComponent<SpriteRenderer>().color = Color.blue;
            m_Timer -= 1;
            if (m_Timer >= 50)
            {
                Pawn[1].GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                Pawn[1].GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
    }

    public IEnumerator WaitforDicecount()
    {
        yield return new WaitForSeconds(5);
    }
}   