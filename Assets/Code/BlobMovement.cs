using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMovement : MonoBehaviour
{  
    private float movementSpeed = 2f;   //Set speed for blob, don't want this to be variable!
    private bool goingRight = true;     //Default animation is to the right, so assume that's where we're going!
    public Rigidbody2D body;

    public Animator animator;

    //Update called once per frame
    void Update()
    {
        //GetAxisRaw will return value in range -1 to 1 depending on input

        //For keyboard, it's mapped to 1 for right/d and -1 for left/a. 0 is default (no press)
        //Same applies to vertical for up/w and down/s
        float horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        float verticalMove = Input.GetAxisRaw("Vertical") * movementSpeed;

        body.velocity = new Vector2(horizontalMove, verticalMove);    

        //If we move blob to the right but we aren't facing right
        if (horizontalMove > 0 && !goingRight)
        {
            //flip blob!
            Flip();
        }
        //Otherwise if we move blob to the left but we aren't facing left
        else if (horizontalMove < 0 && goingRight)
        {
            //flip blob!
            Flip();
        }
        
        animator.SetFloat("isMovingHor", Mathf.Abs(horizontalMove));    //If horizontal/verticalMovement > 0, then we know we are moving so apply animation
        animator.SetFloat("isMovingVer", verticalMove);

    }

    private void Flip()
    {
        //Switch the way the player is labelled as facing.
        goingRight = !goingRight;

        //Get current state of the sprite and save it
        Vector3 currentScale = transform.localScale;
        //Multiple by *1 to flip it 
        currentScale.x *= -1;
        //Make this value the current state of the sprite
        transform.localScale = currentScale;
    }


}
