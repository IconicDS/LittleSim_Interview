using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// This class is a controller class
    /// for the camera. This will allow
    /// the camera to follow the player when
    /// we need it to.
    /// </summary>

    [SerializeField] bool followPlayer;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
        }

        if(followPlayer)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        } else
        {
            transform.position = new Vector3(0, 0, -10);
        }
    }
}
