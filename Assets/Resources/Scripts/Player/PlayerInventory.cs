using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    /// <summary>
    /// This class will hold all the information
    /// on what the player is currently holding
    /// and what clothes or items they own.
    /// </summary>

    private List<Color> ownedShirts;
    private List<Color> ownedPants;

    private int money;

    public PlayerInventory()
    {
        ownedShirts = new List<Color>();
        ownedPants = new List<Color>();

        /// We want to make sure the player owns the
        /// defualt clothes when the game starts up.
        ownedShirts.Add(Color.red);
        ownedPants.Add(Color.blue);

        money = 520;
    }

    public void addShirt(Color c)
    {
        ownedShirts.Add(c);
    }

    public void addPants(Color c)
    {
        ownedPants.Add(c);
    }

    public List<Color> getShirts()
    {
        return ownedShirts;
    }

    public List<Color> getPants()
    {
        return ownedPants;
    }

    public void addMoney(int i)
    {
        money += i;
    }

    public int getMoney()
    {
        return money;
    }
}
