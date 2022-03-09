using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [HideInInspector] public Vector2 elevatorCenter; 
    [HideInInspector] public float elevatorSpeed; 

    [SerializeField] private GameObject elevator; 
    [SerializeField] private float accelerationFactor = 1.0f;  
    [SerializeField] private float maxSpeed = 10.0f;
    
    private Rigidbody2D elevatorRigidbody2D; 
    private Vector2 mousePosition; 
    private bool isBeingHeld; 
    private float startHandlePosition, newHandlePosition, handleYAxis; 

    private void Awake() 
    {
        //Get the Rigidbody2D component from the ElevatorGameObject 
        elevatorRigidbody2D = elevator.GetComponent<Rigidbody2D>();

        handleYAxis = this.gameObject.transform.position.y; 
    }

    private void Update() 
    {
        elevatorCenter = GetComponent<Renderer>().bounds.center; 
        elevatorSpeed = elevatorRigidbody2D.velocity.magnitude; 

        if (isBeingHeld == true) 
        {
            mousePosition = Input.mousePosition; 
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); 

            newHandlePosition = mousePosition.x; 

            //Elevator handle bounds -- Should not be able to move greater than -5.5 or 5.5 
            if (mousePosition.x >= -2.5 && mousePosition.x <= 2.5) 
                this.gameObject.transform.position = new Vector2(mousePosition.x, handleYAxis); 
                //0 is the center of the screen so I need to get the circle's location and set it to the Y position.  
                //For prototyping purposes it'll be -4.  
        }

        ControlSpeed();
    }
    
    private void OnMouseDown() 
    {
        startHandlePosition = mousePosition.x - this.transform.localPosition.x; 
        isBeingHeld = true;
    }
    
    private void OnMouseUp() => isBeingHeld = false;

    private void ApplyEngineForce() 
    {
        int direction = 0; 

        if (newHandlePosition > startHandlePosition) 
            direction = -1;

        if (newHandlePosition < startHandlePosition) 
            direction = 1;
        
        Vector2 engineForceVector = new Vector2(0, direction * accelerationFactor);
        elevatorRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    private void ControlSpeed()
    {
        if (mousePosition.x > -.25 && mousePosition.x < .25) 
        {
            maxSpeed = 0; 
        }
        else if (mousePosition.x < -2 || mousePosition.x > 2) 
        {
            maxSpeed = 30; 
            ApplyEngineForce();
        }
        else if (mousePosition.x < -1.33 || mousePosition.x > 1.33) 
        {
            maxSpeed = 20; 
            ApplyEngineForce();
        }
        else if (mousePosition.x < -.625 || mousePosition.x > .625) 
        {
            maxSpeed = 10; 
            ApplyEngineForce();
        }        
        
        //Prevent the elevator from going above the speed limit.  
        if (elevatorSpeed > maxSpeed)
            elevatorRigidbody2D.velocity = elevatorRigidbody2D.velocity.normalized * maxSpeed;
    }
}

/*
Sources:
- For acceleration code foundation -- https://youtu.be/DVHcOS1E5OQ?t=159 
- For clicking and dragging code foundation -- https://www.youtube.com/watch?v=eUWmiV4jRgU 
- Capping max speed -- https://answers.unity.com/questions/265810/limiting-rigidbody-speed.html 
- UI drag and drop -- https://www.youtube.com/watch?v=BGr-7GZJNXg 

- Render multiple cameras -- https://www.youtube.com/watch?v=_kYiJtM8nMk 

- Awake VS Start: 
  - https://gamedevbeginner.com/start-vs-awake-in-unity/ 
  - https://stackoverflow.com/questions/34652036/awake-and-start 
- Awake is called even if an object in not enabled.  Start is called when an object is enabled.  

- C#'s switches don't like floats source -- https://social.msdn.microsoft.com/Forums/sqlserver/en-US/e3dc97a8-cd4b-4995-905e-0ab50060efe5/why-switch-case-cant-accept-floatingpoint-in-condition?forum=csharpgeneral 



Elevator Dial
- Set positions on a dial basically 
- Turn the dial and max speed increases 
- If speed is < maxSpeed raise it until it is == maxSpeed 
- Same logic in reverse.  Just check if it's greater than and what the maxSpeed should be.  Then lower to that number.  

https://stackoverflow.com/questions/904910/how-do-i-round-a-float-upwards-to-the-nearest-int-in-c
*/

        //Elevator speed controls.  
        //NEEDS TO BE DESIGNED DIFFERENTLY 
        //NOTE: I dunno how I plan on doing animation stuff yet, but maybe I could use this to control where the lever goes.  
        //Max and min are -2.4 and 2.5.  So make it -1.9 and 1.9 for now.  
        //Neater elevator controls.  Doesn't work for some C# reason relating to floats.  
        // switch(mousePosition.x)
        // {
        //     case > 1:
        //         print("1");
        //         break;

        //     default: 
        //         print("default");
        //         break; 
        // }
        /*
        Example from https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements 
        void DisplayMeasurement(int measurement)
        {
            switch (measurement)
            {
                case < 0:
                case > 100:
                    Console.WriteLine($"Measured value is {measurement}; out of an acceptable range.");
                    break;
        
                default:
                    Console.WriteLine($"Measured value is {measurement}.");
                    break;
            }
        }
        */


