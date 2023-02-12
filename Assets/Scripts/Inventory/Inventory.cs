using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory
{
    public Item[] items;
    private Item placeHolderItem;

    //!Creates new inventory of inventorysize and fills it with emptyItem
    public Inventory(int inventorySize, Item emptyItem)
    {
        items = new Item[inventorySize];

        placeHolderItem = emptyItem;
        for(int i = 0; i < items.Length; i++)
        {
            items[i] = placeHolderItem;
        }
    }

    public void AddToInventory(Item item)
    {
        if (ContainsInArray(item) && item.stackable)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == item)
                {
                    items[i].currentAmount += item.currentAmount;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == placeHolderItem)
                {
                    items[i] = item;
                    InventoryManager.Instance.SetSlot(i, item);
                    break;
                }
            }
        }
        //!Checks if item already exists in Inventory and if it's stackable. If it is add the amount to the existing item, otherwise fills a new slot in inventory

        /*for(int i = 0; i < items.Length; i++)
        {
            if (items[i] != placeHolderItem && items[i].stackable && items[i] == item)
            {
                Debug.Log("same item");
                items[i].currentAmount += item.currentAmount;
                break;
            }
            else if (items[i] == placeHolderItem && !ContainsInArray(item))
            {
                items[i] = item;
                InventoryManager.Instance.SetSlot(i, item);
                Debug.Log("new item");
                break;
            }           
        }
        */
    }

    public void LogItems()
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] != placeHolderItem)
                Debug.Log(items[i].name);
            else
                Debug.Log("Item is null");
        }
    }

    public void RemoveFromInventory(Item item, int amount)
    {
        Item currentItem = item;
        //!Checks if there would be more than 0 of the current amount of the item and otherwise removes it.
        if(currentItem.stackable && currentItem.currentAmount - amount > 0)
        {
            currentItem.currentAmount -= amount;
        }
        else
        {
            for(int i = 0; i < items.Length; i++)
            {
                if(items[i] == currentItem)
                {
                    items[i] = placeHolderItem;
                    InventoryManager.Instance.ResetSlot(i);
                }
            }
        }
    }

    private bool ContainsInArray(Item item)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == item)
            {
                return true;
            }
        }

        return false;
    }
}
