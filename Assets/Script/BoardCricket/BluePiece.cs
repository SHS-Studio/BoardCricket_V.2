using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePiece : PlayerPieces
{
    public Grid grid;
    PlayerPieces playerPieces;
    public int p1startPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPieces = GameObject.FindObjectOfType<PlayerPieces>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnMouseDown()
    {
         IsTeamblueturn = true;
         p1startPos = (p1startPos + numberofstepstomove) % gridholder.pathpoint.Length;
         PawnMove(p1startPos);
    }
    public void DetectGridvalue()
    {
        Vector3 startPosition = transform.position;
        Vector3 direction = Vector3.forward; // Cast ray downward
        Debug.DrawRay(startPosition, direction * 10f, Color.red, 2f); // 10 units long, red, lasts 2 seconds

        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(startPosition, direction, out hit, Mathf.Infinity))
        {
            // Check if the hit object has a specific component (e.g., Collider)
            Collider detectedCollider = hit.collider;

            // You can also check for other components, e.g., Rigidbody
             grid = hit.collider.GetComponent<Grid>();
            Debug.Log("Ray Casted");

        }
    }

}
