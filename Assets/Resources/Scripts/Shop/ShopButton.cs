using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    /// <summary>
    /// This class controlls the shop
    /// buttons. It will change the button
    /// text from Purchase to Equip if owned.
    /// </summary>

    [SerializeField] string itemName;
    [SerializeField] int price;

    private GameObject itemImage;
    private Color itemCol;

    private GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = transform.Find("BG").Find("Item").gameObject;
        itemCol = itemImage.GetComponent<Image>().color;

        button = transform.Find("Button").gameObject;
    }

    /// Update the button if the item is
    /// already owned by the player.
    void Update()
    {
        if (itemName.Contains("Shirt"))
        {
            if (PlayerController.getInventory().getShirts().Contains(itemCol))
            {
                button.GetComponentInChildren<Text>().text = "Equip";
            } else
            {
                button.GetComponentInChildren<Text>().text = "Purchase";
            }
        }
        else
        {

            if (itemName.Contains("Pants"))
            {
                if (PlayerController.getInventory().getPants().Contains(itemCol))
                {
                    button.GetComponentInChildren<Text>().text = "Equip";
                }
                else
                {
                    button.GetComponentInChildren<Text>().text = "Purchase";
                }
            }
        }
    }

    ///  This will allow us to purchase clothing
    ///  and add it to our players inventory or
    ///  it will allow us to equip a specific
    ///  clothing if we own the clothing already.
    public void purchaseOrEquip()
    {
        if (button.GetComponentInChildren<Text>().text.Contains("Purchase"))
        {
            if (itemName.Contains("Shirt"))
            {
                if (PlayerController.getInventory().getMoney() >= price)
                {
                    PlayerController.getInventory().addShirt(itemCol);
                    PlayerController.getInventory().addMoney(-price);
                }
            }
            else
            {
                if (itemName.Contains("Pants"))
                {
                    if (PlayerController.getInventory().getMoney() >= price)
                    {
                        PlayerController.getInventory().addPants(itemCol);
                        PlayerController.getInventory().addMoney(-price);
                    }
                }
            }
        } else
        {
            if (itemName.Contains("Shirt"))
            {
                PlayerController.equipShirt(itemCol);
            }
            else
            {
                if (itemName.Contains("Pants"))
                {
                    PlayerController.equipPants(itemCol);
                }
            }
        }
    }
}
