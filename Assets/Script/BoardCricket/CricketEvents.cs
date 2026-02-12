using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketEvents : MonoBehaviour
{
    public PlayerPieces playerPieces;
    public BluePiece bluePiece;
    public RedPiece redPiece;
    public int P1score, P2score;
    public int P1witcket, P2witcket;
    public int P1ball, P2ball;
    // Start is called before the first frame update
    void Start()
    {
        playerPieces = GameObject.FindObjectOfType<PlayerPieces>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Triggerevents()
    {
        if (playerPieces.Currentplayers == Players.Blue)
        {
            bluePiece.DetectGridvalue();
            P1score += bluePiece.grid.Score;
            P1witcket -= bluePiece.grid.Witcket;
            OneventtriggerOut(bluePiece);
            P1ball -= 1;
            P1ball += bluePiece.grid.Extra;
        }

        if (playerPieces.Currentplayers == Players.Red)
        {
            redPiece.DetectGridvalue();
            P2score += bluePiece.grid.Score;
            P2witcket -= bluePiece.grid.Witcket;
            OneventtriggerOut(redPiece);
            P2ball -= 1;
            P2ball += bluePiece.grid.Extra;
        }
     
    }

    public void OneventtriggerOut(PlayerPieces curntplyr)
    {
        if (bluePiece.grid.Out)
        {
            playerPieces.Returnttoinitialpos(curntplyr);
        }
        if (redPiece.grid.Out)
        {
            playerPieces.Returnttoinitialpos(curntplyr);
        }
    }
}
