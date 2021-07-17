using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBoxController : MonoBehaviour
{
    /// <summary>
    /// This class controls everything the chat box
    /// needs to work and perform like it is supposed
    /// to.
    /// </summary>


    private static GameObject chatArrow;
    private static GameObject chat;
    private static GameObject who;
    private float chatShown;
    private float chatSpeed = 6;
    private string animChat = "";
    private static string whoIsChatting;
    private static string chatToShow = "";
    private static bool startChat;
    private static Func<int> runAfterChat;

    // Start is called before the first frame update
    void Start()
    {
        chatArrow = transform.Find("EndChat").gameObject;
        who = transform.Find("WhosTalking").gameObject;
        chat = transform.Find("Chat").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        /// We want to make sure that the chat box
        /// is only shown when we want it to be.
        GetComponent<Image>().raycastTarget = startChat;
        GetComponent<Image>().color = new Color(0, 0, 0, startChat ? 0.5F : 0F);
        who.SetActive(startChat);
        chat.SetActive(startChat);

        if (startChat)
        {
            /// This will allow the chat to move faster
            /// than the default speed if the message is
            /// long.
            float fasterChat = (float)chatToShow.Length / 2;
            if(fasterChat > chatSpeed)
            {
                chatSpeed = fasterChat;
            }

            who.GetComponent<Text>().text = whoIsChatting;

            chatShown += Time.deltaTime * chatSpeed;

            /// We want to make sure that we don't throw an
            /// error when the chatShown variable is longer
            /// than the chatToShow variable.
            if(animChat.Length < chatToShow.Length) {
                if (chatShown >= 1)
                {
                    int animLength = animChat.Length;
                    animChat += chatToShow.Substring(animLength, 1);
                    chatShown = 0;
                }
            }

            chat.GetComponent<Text>().text = animChat;

            /// After the chat box has been fully filled out
            /// we want to show the down arrow to let the user
            /// know that can press the arrow or the 'E' key
            /// to go to the next step.
            if(animChat.Length == chatToShow.Length)
            {
                chatArrow.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    clickArrow();
                }
            } else
            {
                chatArrow.SetActive(false);
            }
        }
        else
        {
            /// We want to reset all the variables when the
            /// chat box is hidden.
            chatShown = 0;
            animChat = "";
        }
    }

    /// Here we take in arguments of chat that will be shown
    /// in the chat box and a function that will be ran when
    /// the chat is over.
    public static void showChatBox(string name, string chat, Func<int> test)
    {
        whoIsChatting = name;
        runAfterChat = test;
        chatToShow = chat;
        startChat = true;
    }

    public static void hideChatBox()
    {
        who.GetComponent<Text>().text = "";
        chat.GetComponent<Text>().text = "";
        chatArrow.SetActive(false);
        startChat = false;
    }

    public void clickArrow()
    {
        hideChatBox();
        int i = runAfterChat();
    }

    public static bool isChatOpen()
    {
        return startChat;
    }
}
