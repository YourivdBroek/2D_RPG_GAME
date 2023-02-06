using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item currentItem;

    private Image img;

    public void SetCurrentItem(Item item)
    {
        currentItem = item;
        ResetVisuals();
    }

    private void ResetVisuals()
    {
        Debug.Log("Visual should be reset");
        img = GetComponent<Image>();

        img.sprite = currentItem.image;
    }
}
