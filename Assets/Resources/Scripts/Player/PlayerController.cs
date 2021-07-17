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

    private static PlayerInventory inventory;

    private Rigidbody2D r2d;

    private Animator anim;

    private static Color shirtColor;
    private static Color pantsColor;
    private static GameObject shirt;
    private static GameObject pants;

    [SerializeField] float walkingSpeed = 2.0F;
    private float horizontalMovement = 0.0F;
    private float verticalMovement = 0.0F;

    void Start()
    {
        /// We want to initialize all of the components
        /// needed to run the Player controller
        /// properly here since this is the first
        /// function called.

        inventory = new PlayerInventory();
        shirt = transform.Find("Shirt").gameObject;
        pants = transform.Find("Pants").gameObject;

        r2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        shirtColor = Color.red;
        pantsColor = Color.blue;

        /// I want the original Player game
        /// object to stay alive no matter what
        /// scene is currently loaded.
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        /// First we want to detect when the player is trying
        /// to move and feed that data to our pre-defined
        /// variables that will allow movement.
        /// 
        /// We don't want the player to move while the screen
        /// transitions is happening. So we will lock the players
        /// location where they are until the screen is empty.

        if (CanvasController.isScreenEmpty())
        {
            horizontalMovement = Input.GetAxis("Horizontal") * (walkingSpeed);
            verticalMovement = Input.GetAxis("Vertical") * (walkingSpeed);
        } else
        {
            horizontalMovement = 0;
            verticalMovement = 0;
        }
    }

    private void FixedUpdate()
    {
        /// This is where we want to write the
        /// code that will allow the player to move.

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

    /// This will give us away to equip different
    /// colored clothing. We can also do a similar
    /// thing to change the design on the shirt
    /// with different sprites.
    public static void setShirtColor(Color col)
    {
        shirtColor = col;
    }

    public static void setPantsColor(Color col)
    {
        pantsColor = col;
    }

    public static Color getShirtColor()
    {
        return shirtColor;
    }

    public static Color getPantsColor()
    {
        return pantsColor;
    }

    public static PlayerInventory getInventory()
    {
        return inventory;
    }

    public static void equipShirt(Color c)
    {
        if(getInventory().getShirts().Contains(c))
        {
            shirt.GetComponent<SpriteRenderer>().color = c;
        }
    }

    public static void equipPants(Color c)
    {
        if (getInventory().getPants().Contains(c))
        {
            pants.GetComponent<SpriteRenderer>().color = c;
        }
    }
}
