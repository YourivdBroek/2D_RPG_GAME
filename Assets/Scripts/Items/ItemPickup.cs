using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item currentItem;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.drawMode = SpriteDrawMode.Sliced;

        spriteRenderer.sprite = currentItem.image;
        Vector2 bounds = new Vector2(spriteRenderer.bounds.size.x, spriteRenderer.bounds.size.y);
        spriteRenderer.size = bounds;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InventoryManager.Instance.itemInventory.AddToInventory(currentItem);
        Destroy(gameObject);
    }
}
