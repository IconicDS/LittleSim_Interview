using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    /// <summary>
    /// This class is to controll the Game Object
    /// labeled Canvas. I want this to stay alive
    /// throughout all of the scenes we are in.
    ///</summary>

    private GameObject transCircle;
    private static bool transition;
    private static float transFill;
    private float transitionSpeed = 0.5F;

    private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        transCircle = transform.Find("Circle").gameObject;

        menu = transform.Find("Menu").gameObject;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        /// We want to hide the menu when we are
        /// not on the main menu screen
        if(SceneManager.GetActiveScene().name.Equals("StartScene"))
        {
            menu.SetActive(true);
        } else
        {
            menu.SetActive(false);
        }

        /// The 'transition' variable will
        /// start transition animation between
        /// scenes.
        if(transition)
        {
            /// We want to start filling the image
            /// until it is full. Once the screen
            /// is completely black we will switch
            /// scenes.
            transFill += Time.deltaTime * transitionSpeed;

            if(transFill >= 1.5F)
            {
                transition = false;
            }
        } else
        {
            if(transFill > 0)
            {
                transFill -= Time.deltaTime * transitionSpeed;
            }
        }

        transCircle.GetComponent<Image>().fillAmount = transFill;
    }

    public static void runTransition()
    {
        CanvasController.transition = true;
    }

    public static bool isScreenBlack()
    {
        return CanvasController.transFill > 1;
    }

    public static bool isScreenEmpty()
    {
        return CanvasController.transFill <= 0;
    }
}
