using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// This is the main player controller.
    /// Here we want to calculate movement
    /// and all other properties for the main
    /// player.
    /// </summary>

    private Rigidbody2D r2d;

    private Animator anim;

    [SerializeField] float walkingSpeed = 2.0F;
    private float horizontalMovement = 0.0F;
    private float verticalMovement = 0.0F;

    void Start()
    {
        /// We want to initialize all of the components
        /// needed to run the Player controller
        /// properly here since this is the first
        /// function called.
        
        r2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        /// First we want to detect when the player is trying
        /// to move and feed that data to our pre-defined
        /// variables that will allow movement
        
        horizontalMovement = Input.GetAxis("Horizontal") * (walkingSpeed);
        verticalMovement = Input.GetAxis("Vertical") * (walkingSpeed);
    }

    private void FixedUpdate()
    {
        /// This is where we want to write the
        /// code that will allow the player to move

        r2d.MovePosition(new Vector2(transform.position.x + (horizontalMovement * Time.deltaTime), transform.position.y + (verticalMovement * Time.deltaTime)));
    }

    private void LateUpdate()
    {
        /// This is where we want to handle all
        /// of the animation calls.

        /// We want to check the horizontal and
        /// vertical movement variables to determine
        /// what animation state the play should be in.
        
        if(horizontalMovement == 0 && verticalMovement == 0)
        {
            anim.Play("Idle");
        }

        /// I casted all of the variables
        /// to an integer to provide for
        /// smoother transitions between
        /// animations.
        
        if ((int)verticalMovement > 0)
        {
            anim.Play("MoveUp");
        }
        else
        {
            if ((int)verticalMovement < 0)
            {
                anim.Play("MoveDown");
            } else
            {
                /// If the user is moving the player
                /// diagonally we want the up or down
                /// animation to be drawn before the
                /// left or right movement.
                
                if((int)horizontalMovement < 0)
                {
                    anim.Play("MoveLeft");
                }
                else
                {
                    if ((int)horizontalMovement > 0)
                    {
                        anim.Play("MoveRight");
                    }
                }
            }
        }
    }
}
