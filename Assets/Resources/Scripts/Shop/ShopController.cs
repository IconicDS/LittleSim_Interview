using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    /// <summary>
    /// This class will controll all of the
    /// components that the shop will need to
    /// update.
    ///
    /// We could automate the item arrangement
    /// and addition later on if we get more items.
    /// </summary>

    private GameObject coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = transform.Find("Coins").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        coins.GetComponentInChildren<Text>().text = "" + PlayerController.getInventory().getMoney();
    }
}
