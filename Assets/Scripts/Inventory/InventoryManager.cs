using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Inventory itemInventory;
    
    [SerializeField]
    private Item placeHolderItem, currentItem;

    private ItemPickup itemPickup;

    private int inventorySize = 15;

    [SerializeField]
    private Transform itemPickupObject;
    
    [SerializeField]
    private InventorySlot[] allSlots;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        itemInventory = new Inventory(inventorySize, placeHolderItem);

        //!For testing
        currentItem.currentAmount = 1;

        for(int i = 0; i < allSlots.Length; i++)
        {
            allSlots[i].SetCurrentItem(placeHolderItem);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            itemInventory.AddToInventory(currentItem);       
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            itemInventory.RemoveFromInventory(currentItem, 1);
        }

       for (int i = 0; i < itemInventory.items.Length; i++)
        {
            if (itemInventory.items[i] != null)
                Debug.Log("Item slot " + i + ": " + itemInventory.items[i].name);
            else
                Debug.Log("Item slot " + i + ": Null");
        }
       
    }

    public void SetSlot(int index, Item item)
    {
        allSlots[index].SetCurrentItem(item);
    }

    public void ResetSlot(int index)
    {
        allSlots[index].SetCurrentItem(placeHolderItem);
    }

    public void OnClick(InventorySlot slot)
    {
        if(slot.currentItem != placeHolderItem)
        {
            itemPickup = itemPickupObject.gameObject.GetComponent<ItemPickup>();
            itemPickup.currentItem = slot.currentItem;
            itemInventory.RemoveFromInventory(itemPickup.currentItem, 1);
            Instantiate(itemPickupObject, new Vector3(0, 0, 0), Quaternion.identity);
            //slot.SetCurrentItem(placeHolderItem);
        }
    }


}
