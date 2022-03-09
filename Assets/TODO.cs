using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TODO : MonoBehaviour {} 
//TODO 
/*
Good example of Update and FixedUpdate connection:
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && moveUpOnJump == true)
        {
            print("Move up");
            moveUpOnJump = false; 
        } 
        else if ((Input.GetKeyDown(KeyCode.Space)) && moveUpOnJump == false)
        {
            print("Move down");
            moveUpOnJump = true; 
        }
    }

    void FixedUpdate()
    { 
        if (moveUpOnJump == true)
        {
            rb2D.AddForce(new Vector2(0f, -40f) * Time.deltaTime, ForceMode2D.Impulse); //Can Time.deltaTime for a slightly different effect 
        } 
        else if (moveUpOnJump == false)
        {
            rb2D.AddForce(new Vector2(0f, 40f) * Time.deltaTime, ForceMode2D.Impulse); //Can Time.deltaTime for a slightly different effect 
        }
    }




- I need to see where the center of the elevator is in comparison to the center of the floor.  
- There needs to be a range of value from close to far.  
- When near a floor I need to check constantly.  
- The two centers aren't going to be 0 but they're going to have matching Y positions.  
  - If the elevator center is > or < the floor center do something.  
  - If the elevator center is >= and <= to something close to the floor center then do something else.  



- Make the elevator's velocity increment or decrment to == the maxSpeed 
- Change camera for mobile portrait mode: 
  - https://www.youtube.com/watch?v=Yt3Gvi9ZzbU 
  - https://www.youtube.com/watch?v=Y-OZOHwJc1w 
- Add sources for how to put a camera over a camera 
- Design and fix speed system [16] 
  - I know how to figure out direction.  Maybe use >= and <= like handlePosition >= 2 && <= 3.  Maybe this can, like... add 2 speed instead of the normal 1 as an example.  
  - What about zero?  Maybe handlePosition >= -1 && <= 1 and the elevator just outright stops?  Like maxSpeed = 0; or maxSpeed = .5.  
  - Then maybe handlePosition >= -.5 && <= .5 and the elevator outright stops?  This is maybe better as a barrier from just outright stopping by accident.  
- Do the floor signalling thing [16] 
  - Remake the floors as a prefab.  
  - Highlight floor(s) red 
  - When the elevator is near the floor, turn the floor green.
  - When the elevator is right in the center turn is bright green.  
    - This "center" should be cariable.  
  - NOTE: The green goes from darker shades to brighter shades.  
- Design variations and some levels [1] 
- Design half circle controls [2] 
- Figure out how to make more levels [2] 
- Design extra features [1] 
  - Hard stop penalties.  
  - "Watch your step" penalties.  
  - Moving elevator from side to side.  
  - Clicking stuff on screen?  
  - Different elevator types (rocket elevator)? 
  - Different levels to play?  

- I'll reuse the same level and just load different assets in.  



- Add camera: 
  - I don't want to keep the elevator directly in the center of the screen.  
  - I need the controls to always be visible.  
    - Maybe attach them to the UI?  I dunno how else to do this.  
      - UI drag and drop tutorial? -- https://www.youtube.com/watch?v=BGr-7GZJNXg 
  - Sources: 
    - Best -- https://www.youtube.com/watch?v=2jTY11Am0Ig 
    - https://www.youtube.com/watch?v=D9RF41cp9UE 
    - https://www.youtube.com/watch?v=MFQhpwc6cKE 
    - https://www.youtube.com/watch?v=_QnPY6hw8pA 
    - https://www.youtube.com/watch?v=xxshfe3yzqA 
- For the elevator Controls: 
  - Try attaching the "handle" to a circle.  This gives me kind of an anchor for the handle so I'm not conceptualizing moving the handle around empty space.  
  - Rotate the entire circle to rotate the handle.  
  - Likely still need to get the angle it starts at and, I dunno like, subtract that from where it's headed in order to determine whether the player wants it to go up or down.  
  - How would this look animated?  My more specific concern is with turn the whole image, which is not what I want.  
  - I may need to play test how the Controls look and feel.  
    - In my head I was imaging it'd be realistic.  Where you put your hand (finger) on the lever and move it.  This is also intuitive.  However it may feel way better if you can just drag your finger from side to side.  

- Controls image references -- https://www.google.com/search?q=vintage+elevator+controls&client=firefox-b-1-d&sxsrf=AOaemvKOjA-hKBASCS0l9kckf_x-nqtphg:1636316806280&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjGrOmPi4f0AhX1l3IEHevmBhgQ_AUoAnoECAEQBA&biw=1920&bih=937 

- TouchScript: I may want this since it's a mobile game -- https://assetstore.unity.com/packages/tools/input-management/touchscript-7394#releases

- Has Hearthstone in the thumbnail.  Probably one of the resources I was looking for -- https://www.youtube.com/watch?v=aPXvoWVabPY 

- Maybe AddImpulse is just wrong.  What exactly am I trying to do?  
- Increase to a max speed and then decrease on the way down.  
  - Weirdly put this is also true in reverse.  
*/

//Resources: 
/*
- Car speedometer for the dial lever -- https://www.youtube.com/watch?v=3xSYkFdQiZ0
  - Back up -- https://www.youtube.com/watch?v=7EaEBerzkOg 
- Progress bar -- https://www.youtube.com/watch?v=J1ng1zA3-Pk 
- Instantiate stuff -- https://www.youtube.com/watch?v=E7gmylDS1C4 
*/


