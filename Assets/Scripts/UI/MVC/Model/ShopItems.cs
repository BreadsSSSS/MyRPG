using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems 
{
    public ShopController shopController;

    private static ShopItems shopItems = null;
    public static ShopItems ShopItemS
    {
        get {
            if (shopItems == null)
            {
                shopItems = new ShopItems();
            }
            return shopItems;
        }
    }

    
}
