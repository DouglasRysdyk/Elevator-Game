using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopElevator : MonoBehaviour
{
    public ElevatorController elevatorController; 

    private void OnCollisionEnter2D(Collision2D other) 
    {
        //Make sure we're interacting with the player.  
        if (other.collider.tag == "Player")
        {
            elevatorController.elevatorSpeed = 0; 
        }
    }
}

//Collision video for reference -- https://www.youtube.com/watch?v=gAB64vfbrhI 


