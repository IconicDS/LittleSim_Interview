using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof (BoxCollider2D))]
public class SceneQueue : MonoBehaviour
{
    /// <summary>
    /// The Scene Queue class is to control
    /// scenes between transitions. Once
    /// a scene is queued it will automatically
    /// trigger when the screen is covered.
    /// </summary>

    private static string onQueue = "null";

    [SerializeField] string nextScene;
    [SerializeField] Vector3 playerPosition;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerPosition = new Vector3(0, 2.83F, 0);

        /// We only want to keep the game object
        /// with the name SceneQueue alive throughout
        /// every scene we enter. We do not want to
        /// carry over actual triggers.
        if (gameObject.name.Equals("SceneQueue"))
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static void queueScene(string s)
    {
        onQueue = s;
    }

    private void Update()
    {
        /// Here we check with the CanvasController
        /// class to see if the screen is covered so
        /// so we can switch to the queued scene.
        if (onQueue != "null" && onQueue != "")
        {
            if (CanvasController.isScreenBlack())
            {
                if (!SceneManager.GetActiveScene().name.Equals(nextScene))
                {
                    SceneManager.LoadScene(onQueue);
                    queueScene("null");
                }

                player.transform.position = playerPosition;
            }
        }
    }

    /// We will also use the scenes queue class to
    /// exit rooms and enter scenes through a
    /// box collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /// We want to make sure the transitions only
        /// starts when the Player object has entered
        /// the collider.
        if(collision.gameObject.name.Equals("Player"))
        {
            SceneQueue.queueScene(nextScene);
            CanvasController.runTransition();
        }
    }

    /// We will also allow a way for us to
    /// manually trigger a transition.
    public void performTransition()
    {
        SceneQueue.queueScene(nextScene);
        CanvasController.runTransition();
    }


    ///  This will close the window from the main menu.
    public void closeApplication()
    {
        Application.Quit(0);
    }
}
