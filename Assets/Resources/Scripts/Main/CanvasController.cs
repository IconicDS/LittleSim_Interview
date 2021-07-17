using System;
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
    private float transitionSpeed = 0.75F;

    private GameObject menu;

    private static GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        transCircle = transform.Find("Circle").gameObject;

        menu = transform.Find("Menu").gameObject;

        shop = transform.Find("Shop").gameObject;

        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
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

        updateTransition();
    }


    public void updateTransition()
    {
        /// The 'transition' variable will
        /// start transition animation between
        /// scenes.
        if (transition)
        {
            /// We want to start filling the image
            /// until it is full. Once the screen
            /// is completely black we will switch
            /// scenes.
            transFill += Time.deltaTime * transitionSpeed;

            if (transFill >= 1.5F)
            {
                transition = false;
            }
        }
        else
        {
            if (transFill > 0)
            {
                transFill -= Time.deltaTime * transitionSpeed;
            }
        }

        transCircle.GetComponent<Image>().fillAmount = transFill;
    }

    /// This will start the animation for the
    /// scene transition.
    public static void runTransition()
    {
        CanvasController.transition = true;
    }

    /// This is to check if the screen is fully
    /// black and will allow the scene to switch.
    public static bool isScreenBlack()
    {
        return CanvasController.transFill > 1;
    }

    /// This is to check if the screen is empty
    /// and we can allow the user to start walking
    /// again.
    public static bool isScreenEmpty()
    {
        return CanvasController.transFill <= 0;
    }

    public static void openShop()
    {
        shop.SetActive(true);
    }
}
