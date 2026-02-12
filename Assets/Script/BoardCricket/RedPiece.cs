using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RedPiece : PlayerPieces
{
    public Grid grid;
    public int p2startPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnMouseDown()
    {
        cricketEvents.redPiece = gameObject.GetComponent<RedPiece>();
        Currentplayers = Players.Red;
        p2startPos = (p2startPos + numberofstepstomove) % gridholder.pathpoint.Length;
        PawnMove(p2startPos);
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
