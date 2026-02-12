using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GetValue : MonoBehaviour
{
    public GridValue value;
    //public EventTrigger trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void CastRay()
    {
        Debug.Log("Casting Ray");
        // Define the ray starting position (from the GameObject's position)
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
            value = hit.collider.GetComponent<GridValue>();
            Debug.Log("Ray Casted");

        }
    }

 
}
