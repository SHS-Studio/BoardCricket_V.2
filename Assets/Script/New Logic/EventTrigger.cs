//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using Unity.VisualScripting.Antlr3.Runtime.Misc;
//using UnityEngine.UI;

//using UnityEngine;
//using TMPro;
//using UnityEngine.PlayerLoop;
//using static UnityEngine.EventSystems.EventTrigger;

//public enum Player
//{
//    NONE,
//    Player1,
//    Player2
//}
//public class EventTrigger : MonoBehaviour
//{
//    public DiceRoller diceRoller;
//    public GetValue getValue;
//   // Player CurrentPlayer;

//    public GameObject p1turnlght,  p2turnlght;

//    public GameObject[] Pawn;
//    public GameObject selectedPawn = null;

//    int totalGrids;
//    public int currentGrid;
//    public GameObject[] grid;
    
//    // P1 & P2 Position
//    public int[] p1Pos;
//    public int[] p2Pos;
//    int steps;

//    // Turn Timer
//    public float p1Playerturntime, p2Playerturntime;

//    // player turn
//    public bool p1Turn;
//    public bool p2Turn;

//    // Raycast Option
//    float rayDistance = 100f;
//    public LayerMask ignorelayer;
  
//    // Score Update
//    public int p1ball=30 , p2ball= 30;
//    public int p1run , p2run;
//    public int p1witcket = 10 , p2witcket = 10;

//    public TMP_Text p1runtxt, p2runtxt, p1witckettxt, p2witckettxt, p1balltxt, p2balltxt, p1timertxt, p2timertxt;

//    public int destination;

//    public float Turnender;

//    //
//    public GameObject P1victoryScreen, P2victoryScreen,Draw;
    
    

//    public void Start()
//    {
//        //CurrentPlayer = Player.Player1;
//        UpdatePawnPositions();
//    }

//    public void Update()
//    {
//        Checkturn();
//        Changelight();
//        TurntimerMechanism();
//       // Checkball(); 
//        CastRay();
//        UIupdate();
//      //  missturn();
//        CheckWinloss();
//    }

//    public void OnClick()
//    {
//       // Checkturn();
//        diceRoller.Isrotating = true;
//    }

//    public void TurntimerMechanism()
//    {
//        switch (CurrentPlayer)
//        {
//            case Player.Player1:

//                if (p1Turn)
//                {
//                    p1Playerturntime -= Time.deltaTime;
//                    if (p1Playerturntime < 0)
//                    {
//                      //  Checkball();
//                        p1Playerturntime = 10;
//                        ChangeTurn();
                       
//                    }

//                }

//                break;

//            case Player.Player2:
                
//                if (p2Turn)
//                {
//                    p2Playerturntime -= Time.deltaTime;
//                    if (p2Playerturntime < 0)
//                    {
//                      //  Checkball();
//                        p2Playerturntime = 10;
//                        ChangeTurn();
                       
//                    }
//                }
               
//                break;

//        }
      
//    }

//    public void ChangeTurn()
//    {
//        switch (CurrentPlayer)
//        {
//            case Player.Player1:

//                CurrentPlayer = Player.Player2;
//                break;

//            case Player.Player2:

//                CurrentPlayer = Player.Player1;
//                break;

//        }
//    }

//    public void Checkturn()
//    {
//        switch (CurrentPlayer)
//        {
//            case Player.Player1:

//                p1Turn = true;
//                p2Turn = false;
//                break;

//            case Player.Player2:
//                p2Turn = true;
//                p1Turn = false;
//                break;
//        }
//    }

//    public void CastRay()
//    {
//        if (Input.GetMouseButtonDown(0)) // Detect left mouse click
//        {
//            intercatpawn();
//        }
//    }

//    public void intercatpawn()
//    {
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Create a ray from the camera to mouse position
//        RaycastHit hit;

//        if (Physics.Raycast(ray, out hit, rayDistance,ignorelayer))
//        {
         

//            // Perform any action on the selected object
//            SelectPawn(hit.collider.gameObject);
//             getValue = hit.collider.gameObject.GetComponent<GetValue>();
//        }
//    }

//    void SelectPawn(GameObject pawn)
//    {
//        if ((CurrentPlayer == Player.Player1 && (pawn == Pawn[0] || pawn == Pawn[1])) ||
//            (CurrentPlayer == Player.Player2 && (pawn == Pawn[2] || pawn == Pawn[3])))
//        {
//            selectedPawn = pawn;
//            movepawn(selectedPawn);


//           // Debug.Log($"Selected Pawn: {pawn.name}");
//        }
//    }

//    public void movepawn(GameObject pawn)
//    {
//        int index = System.Array.IndexOf(Pawn, selectedPawn);
//        if (index == -1) return; // Invalid selection

//        if (diceRoller.movepawn)
//        {
//            if (CurrentPlayer == Player.Player1)
//            {
//                p1ball -= 1;
//                steps = diceRoller.Dicecount;
//                destination = p1Pos[index] + steps;
//                StartCoroutine(MovePawnStepByStep(selectedPawn, p1Pos[index], destination));
//                p1Pos[index] = (p1Pos[index] + steps) % grid.Length;

//            }

//            if (CurrentPlayer == Player.Player2)
//            {
//                p2ball -= 1;
//                steps = diceRoller.Dicecount;
//                destination = p2Pos[index - 2] + steps;
//                StartCoroutine(MovePawnStepByStep(selectedPawn, p2Pos[index - 2], destination));
//                p2Pos[index - 2] = (p2Pos[index - 2] + steps) % grid.Length;

//            }
//        }
//    }

//    private IEnumerator MovePawnStepByStep(GameObject pawn, int startPos, int targetPos)
//    {
//        totalGrids = grid.Length;
//        for (int i = startPos; i < targetPos; i++)
//        {
//            currentGrid = (i + 1) % totalGrids;
//            if (i != targetPos)
//            {
//                pawn.transform.position = grid[currentGrid].transform.position + new Vector3(0, 0, -5);
//                yield return new WaitForSeconds(0.3f); // Pause between moves

              
//            }

          
//        }
//        TriggerCricketevents();
  
//    }

//    private void UpdatePawnPositions()
//    {
//        Pawn[0].transform.position = grid[p1Pos[0]].transform.position + new Vector3(0, 0, -5);
//        Pawn[1].transform.position = grid[p1Pos[1]].transform.position + new Vector3 (0.6f,0,-5);


//        Pawn[2].transform.position = grid[p2Pos[0]].transform.position + new Vector3(0, 0, -5);
//        Pawn[3].transform.position = grid[p2Pos[1]].transform.position + new Vector3(0.5f, 00, -5); 
//    }

//    public void Checkball()
//    {
//        if (!p1Turn )
//        {
//            p1ball -= 1;
//        }

//        if (!p2Turn)
//        {
//            p2ball -= 1;
//        }
//    }

//    public void TriggerCricketevents()
//    {
//        getValue.CastRay();
//        if (getValue.value == null)
//        {
//            Debug.LogWarning("GridValue component not found under pawn!");
//            return;
//        }

//        switch (CurrentPlayer)
//        {
//            case Player.Player1:

//                p1run += getValue.value.Score;
//                p1witcket -= getValue.value.Witckets;
             

//                break;

//            case Player.Player2:


//                p2run += getValue.value.Score;
//                p2witcket -= getValue.value.Witckets;
              
//                break;
//        }
      
//    }

//    public void UIupdate()
//    {
//        switch (CurrentPlayer)
//        {
            
//            case Player.Player1:
//                p1runtxt.text = "Run =" + p1run.ToString();
//                p1witckettxt.text = "Witcket =" + p1witcket.ToString();
//                p1balltxt.text = "Ball =" + p1ball.ToString();
//                p1timertxt.text = "Timer :" + p1Playerturntime.ToString("00");
//                break;
//            case Player.Player2:
//                p2runtxt.text = "Run =" + p2run.ToString();
//                p2witckettxt.text = "Witcket =" + p2witcket.ToString();
//                p2balltxt.text = "Ball =" + p2ball.ToString();
//                p2timertxt.text = "Timer :" + p2Playerturntime.ToString("00");
//                break;
            
//        }
       

      


//    }

//    public void CheckWinloss()
//    {
//        if (p1ball == 0 && p2ball == 0 )
//        {
//            if (p1run > p2run)
//            {
//                P1victoryScreen.SetActive(true);
//            }
//            else if (p2run > p1run)
//            {
//                P2victoryScreen.SetActive(true);
//            }
//            else
//            {
//                Draw.SetActive(true);
//            }
         
//        }

//        if (p2witcket == 0 && p1witcket > 0 )
//        {
//            Debug.Log("p1 won");
//        }
//        else
//        {
//            Debug.Log("p2 won");
//        }
//    }

//     public void Changelight()
//    {
//        switch (CurrentPlayer)
//        {
//            case Player.Player1:
//                p1turnlght.SetActive(true);
//                p2turnlght.SetActive(false);
//                break;
//            case Player.Player2:
//                p1turnlght.SetActive(false);
//                p2turnlght.SetActive(true);
//                break;
//        }
//    }

//    public void missturn()
//    {
//        Turnender -= Time.deltaTime;
//        if (Turnender <= 0)
//        {
          
//            if (CurrentPlayer == Player.Player1)
//            {
//                p1ball -= 1;
//            }
//            else if (CurrentPlayer == Player.Player2)
//            {
//                p2ball -= 1;
//            }
//            ChangeTurn();
//            Turnender = 10;
//        }

//    }


//    public void Endturn()
//    {
//        switch (CurrentPlayer)
//        {
//            case Player.Player1:
//               // Checkball();
//                CurrentPlayer = Player.Player2;
//                p1Playerturntime = 10;
//                break;

//            case Player.Player2:
//              //  Checkball();
//                CurrentPlayer = Player.Player1;
//                p2Playerturntime = 10;
//                break;

//        }
//    }
//}
