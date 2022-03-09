using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckElevatorPosition : MonoBehaviour
{
    private Vector2 theFloorCenter;
    private Vector2 theElevatorCenter; 
    private float distance; 

    private void Start()
    {
        theFloorCenter = GetComponent<Renderer>().bounds.center; 
    }

    private void Update()
    {
        theElevatorCenter = FindObjectOfType<ElevatorController>().elevatorCenter;  
        distance = Vector2.Distance(theFloorCenter, theElevatorCenter); 

        if (distance <= 0.03)
        {
            if (FindObjectOfType<ElevatorController>().elevatorSpeed <= 0.0)
            {
                //Testing, will replace with real code later.  
//                print("good"); 
            }
        }
        else if (distance <= .15)
        {
            if (FindObjectOfType<ElevatorController>().elevatorSpeed <= 0.0)
            {
                //Testing, will replace with real code later.  
//                print("close enough");
            }
        }
    }
}

//Get the elevator's position.  
//Use -- https://www.youtube.com/watch?v=ymq2AUckws0 
//Help? -- https://answers.unity.com/questions/246211/having-scripts-interact.html 

//Make sure the other object is the elevator specifically.  
//See how close the cneter of the elevator is to the center of the floor.  
//Maybe I can make a general margin for error 


