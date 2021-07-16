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

    [SerializeField] float walkingSpeed = 6.0F;
    private float horizontalMovement = 0.0F;
    private float verticalMovement = 0.0F;

    void Start()
    {
        /// We want to initialize all of the components
        /// needed to run the Player controller
        /// properly here since this is the first
        /// function called.
        
        r2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /// First we want to detect when the player is trying
        /// to move and feed that data to our pre-defined
        /// variables that will allow movement
        
        horizontalMovement = Input.GetAxis("Horizontal") * (walkingSpeed * Time.deltaTime);
        verticalMovement = Input.GetAxis("Vertical") * (walkingSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        /// This is where we want to write the
        /// code that will allow the player to move

        r2d.MovePosition(new Vector2(transform.position.x + horizontalMovement, transform.position.y + verticalMovement));
    }
}
