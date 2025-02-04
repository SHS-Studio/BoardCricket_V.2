using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum WhosTurn
{
    NONE,
    RED,
    BLUE
}
public class GameManager : MonoBehaviour
{
    RollDice RD;
    public GameObject[] WIN;
    public GameObject[] LOOSE;
    public GameObject[] Pawn;
    public Transform[] Grids;
    public GameObject[] m_runs;
    public WhosTurn W_T;
    public int R_Pos;
    public int B_Pos = 12;
    public int R_BALL = 30, B_BALL = 30;
    public bool TurnOver = false;
    public int R_RUN = 0, B_RUN = 0;
    public int R_WICKET = 10, B_WICKET = 10;
    public Text[] WICKET;
    public Text[] Ball;
    public Text[] Run;
    public Text R_Timer;
    public Text B_Timer;
    public float m_Timer = 10f;
    public float R_TurnTimer = 10f;
    public float B_TurnTimer = 10f;


    private void Awake()
    {
        wiatonstar();


    }
    // Start is called before the first frame update
    void Start()
    {
        RD = GameObject.FindObjectOfType<RollDice>();
        W_T = WhosTurn.RED;
        Pawn[0].transform.position = Grids[R_Pos].transform.position;
        Pawn[1].transform.position = Grids[B_Pos].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        OVER_UP();
        WINNING_LOOSING();
        //Run[0].text = R_RUN.ToString();
        //Run[1].text = B_RUN.ToString();
        //WICKET[0].text = R_WICKET.ToString();
        //WICKET[1].text = B_WICKET.ToString();
        //Ball[0].text = R_BALL.ToString();
        //Ball[1].text = B_BALL.ToString();
        //R_Timer.text = R_TurnTimer.ToString("00");
        //B_Timer.text = B_TurnTimer.ToString("00");
        //COLOR_BLINK();
        if (m_Timer <= 0)
        {
            m_Timer = 100;
        }
        StartCoroutine(Turn_Timer());
        ChangePawn_TimeEnds();
    }

    public IEnumerator wiatonstar()
    {
        yield return new WaitForSeconds(5);
    }

    public void OnClick()
    {
        //deBUG.log("okz");
        RD.Isrotating = false;
        RD.GetDiceCount();
        MovePawn();
        //Scoring();
        Check_Change_Turn();
        TurnOver = false;
        RD.Isrotating = true;
        RD.bIsUnderChecking = true;
        Delay();
        StopCoroutine(Turn_Timer());


    }

    public void Check_Change_Turn()
    {
        if (W_T == WhosTurn.RED && !TurnOver && R_TurnTimer > 0)
        {
            W_T = WhosTurn.BLUE;
            TurnOver = true;
            R_BALL -= 1;
        }
        else if (W_T == WhosTurn.BLUE && !TurnOver)
        {
            W_T = WhosTurn.RED;
            TurnOver = true;
            B_BALL -= 1;
        }
    }

    public void MovePawn()
    {

        switch (W_T)
        {
            case WhosTurn.RED:


                R_Pos += RD.Dicecount;
                if (R_Pos > Grids.Length)
                {
                    R_Pos = R_Pos % Grids.Length;
                }
                Pawn[0].transform.position = Grids[R_Pos].transform.position;

                break;

            case WhosTurn.BLUE:

                B_Pos += RD.Dicecount;
                if (B_Pos > Grids.Length)
                {
                    B_Pos = B_Pos % Grids.Length;
                }
                Pawn[1].transform.position = Grids[B_Pos].transform.position;

                break;
        }
    }

    public void OVER_UP()
    {
        if (R_BALL == 0 && B_BALL == 0)
        {
            W_T = WhosTurn.NONE;
        }
    }

    //public void Scoring()
    //{
    //    // PLAYER - RED
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[0].transform.position)
    //    {
    //        R_RUN += 1;
    //        Run[0].text = R_RUN.ToString();
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[0].transform.position)
    //    {
    //        B_RUN += 1;
    //        Run[1].text = B_RUN.ToString();
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[1].transform.position)
    //    {
    //        R_RUN += 2;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[1].transform.position)
    //    {
    //        B_RUN += 2;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[2].transform.position)
    //    {
    //        R_WICKET -= 1;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[2].transform.position)
    //    {
    //        B_WICKET -= 1;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[3].transform.position)
    //    {
    //        R_RUN += 6;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[3].transform.position)
    //    {
    //        B_RUN += 6;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[4].transform.position)
    //    {
    //        R_RUN += 4;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[4].transform.position)
    //    {
    //        B_RUN += 4;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[5].transform.position)
    //    {
    //        R_RUN += 2;

    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[5].transform.position)
    //    {
    //        B_RUN += 2;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[6].transform.position)
    //    {
    //        R_WICKET -= 1;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[6].transform.position)
    //    {
    //        B_WICKET -= 1;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[7].transform.position)
    //    {
    //        R_RUN += 6;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[7].transform.position)
    //    {
    //        B_RUN += 6;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[8].transform.position)
    //    {
    //        R_RUN += 1;

    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[8].transform.position)
    //    {
    //        B_RUN += 1;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[9].transform.position)
    //    {
    //        R_RUN += 6;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[9].transform.position)
    //    {
    //        B_RUN += 6;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[10].transform.position)
    //    {
    //        R_RUN += 1;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[10].transform.position)
    //    {
    //        B_RUN += 1;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[11].transform.position)
    //    {
    //        R_WICKET -= 1;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[11].transform.position)
    //    {
    //        B_WICKET -= 1;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[12].transform.position)
    //    {
    //        R_RUN += 2;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[12].transform.position)
    //    {
    //        B_RUN += 2;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[13].transform.position)
    //    {
    //        R_WICKET -=1;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[13].transform.position)
    //    {
    //        B_WICKET -= 1;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[14].transform.position)
    //    {
    //        R_RUN += 2;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[14].transform.position)
    //    {
    //        B_RUN += 2;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[15].transform.position)
    //    {
    //        R_RUN += 1;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[15].transform.position)
    //    {
    //        B_RUN += 1;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[16].transform.position)
    //    {
    //        R_RUN += 4;
    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[16].transform.position)
    //    {
    //        B_RUN += 4;
    //    }
    //    if (W_T == WhosTurn.RED && Pawn[0].transform.position == m_runs[17].transform.position)
    //    {

    //        R_RUN += 6;

    //    }
    //    else if (W_T == WhosTurn.BLUE && Pawn[1].transform.position == m_runs[17].transform.position)
    //    {
    //        B_RUN += 6;
    //    }
    //}

    public void WINNING_LOOSING()
    {
        if (R_RUN > B_RUN && R_BALL == 0 && B_BALL == 0)
        {
            Destroy(Pawn[1]);
            WIN[0].SetActive(true);
        }
        else if (B_RUN > R_RUN && R_BALL == 0 && B_BALL == 0)
        {
            Destroy(Pawn[0]);
            WIN[1].SetActive(true);
        }

        if (R_WICKET > 1 && B_WICKET == 0)
        {
            Destroy(Pawn[1]);
            WIN[0].SetActive(true);
        }
        else if (B_WICKET > 1 && R_WICKET == 0)
        {
            Destroy(Pawn[0]);
            WIN[1].SetActive(true);
        }
    }

    public void COLOR_BLINK()
    {
        if (W_T == WhosTurn.RED)
        {
            Pawn[1].GetComponent<MeshRenderer>().material.color = Color.blue;
            m_Timer -= 1;
            if (m_Timer >= 50)
            {
                Pawn[0].GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else
            {
                Pawn[0].GetComponent<MeshRenderer>().material.color = Color.yellow;
            }


        }
        else if (W_T == WhosTurn.BLUE)
        {
            Pawn[0].GetComponent<MeshRenderer>().material.color = Color.red;
            m_Timer -= 1;
            if (m_Timer >= 50)
            {
                Pawn[1].GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            else
            {
                Pawn[1].GetComponent<MeshRenderer>().material.color = Color.yellow;
            }

        }
    }

    void Delay()
    {
        StartCoroutine(waitforturn());
    }

    public IEnumerator waitforturn()
    {
        Debug.Log("Done");
        yield return new WaitForSeconds(1.5f);
        RD.bIsUnderChecking = false;
        Debug.Log("After 5");

    }

    public IEnumerator Turn_Timer()
    {
        if (W_T == WhosTurn.RED && !TurnOver)
        {
            R_TurnTimer -= Time.deltaTime;
        }
        else 
        {
            R_TurnTimer = 10;
        }

        if (W_T == WhosTurn.BLUE && !TurnOver)
        {
            B_TurnTimer -= Time.deltaTime;
        }
        else
        {
            B_TurnTimer = 10;
        }

        yield return null;
    }

    public void ChangePawn_TimeEnds()
    {
        if (W_T == WhosTurn.RED && R_TurnTimer <= 0 && !TurnOver)
        {
            W_T = WhosTurn.BLUE;
            TurnOver = true;
            R_BALL -= 1;
        }
        else if (W_T == WhosTurn.RED && R_TurnTimer > 0 && TurnOver)
        {
            W_T = WhosTurn.RED;
            TurnOver = false;
        }


        if (W_T == WhosTurn.BLUE && B_TurnTimer <= 0 && !TurnOver)
        {
            
            W_T = WhosTurn.RED;
            TurnOver = true;
            B_BALL -= 1;
        }
        if (W_T == WhosTurn.BLUE && B_TurnTimer > 0 && TurnOver)
        {
            W_T = WhosTurn.BLUE;
            TurnOver = false;
        }
    }

   
}
