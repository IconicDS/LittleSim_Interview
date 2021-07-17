using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperController : MonoBehaviour
{

    /// <summary>
    /// This class is the main controller
    /// for the shopkeeper charachter.
    /// This will allow the player to interact
    /// with the shopkeeper and open up the shop
    /// UI.
    /// </summary>

    private GameObject eButton;
    private bool canTalk;

    string[] convoStarter = {
        "Hello wanderer. Do you have items to sell?",
        "It's been a while! What're you looking for today?",
        "I just got a bunch of inventory yesterday! You picked a great time to stop by.",
        "Oh, it's you again...",
        "How many clothes do you go through?",
        "Hello! Would you like to check out our new items we have?",
    }; 
    
    // Start is called before the first frame update
    void Start()
    {
        eButton = transform.Find("EButton").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (ChatBoxController.isChatOpen())
        {
            canTalk = false;
        }

        /// We want to make sure that when the player
        /// is close enough they can see what button to
        /// press to talk to the shopkeeper.
        if (canTalk)
        {
            eButton.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                string randMessage = convoStarter[(int)Random.Range(0, convoStarter.Length)];
                ChatBoxController.showChatBox("Shopkeeper", randMessage, openShop);
            }
        } else
        {
            eButton.SetActive(false);
        }
    }

    /// This will let the shopkeeper know when
    /// the player is close enough to start a
    /// conversation with the shopkeeper.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTalk = true;
    }

    /// This will let the shopkeeper know when
    /// the player leaves the area and can no
    /// longer talk to the shopkeeper.
    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
    }

    private int openShop()
    {
        CanvasController.openShop();
        return 0;
    }
}
