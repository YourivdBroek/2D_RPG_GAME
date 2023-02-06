using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private ClassScriptableObject currentClass;

    //public Inventory itemInventory;

    //public Item currentItem, placeHolderItem;

    //private int inventorySize = 15;
    private float horizontal, vertical;

    private void Awake()
    {

        //allSlots = new Transform[inventorySize];
        //for(int i = 0; i < inventorySize; i++)
        //{
        //    GameObject obj = inventorySlot.gameObject;
        //    Instantiate(obj, inventoryBackground);
        //    allSlots[i] = obj.transform;
        //}

        //itemInventory.SetSlots(allSlots);
    }

    private void Update()
    {
        //Debug.Log(currentClass.currentStats.strength);
        horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 15;
        vertical = Input.GetAxis("Vertical") * Time.deltaTime * 15;
    }

    private void FixedUpdate()
    {
        transform.Translate(horizontal, vertical, 0);
    }

    private void IncreaseStrenght()
    {
        currentClass.currentStats.strength += 1;
    }
}
