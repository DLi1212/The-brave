using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject slotHolder;
    public int pieces;
    private int num = 0;
    public bool isOpen;
    private int allSlots;
    private GameObject[] slot;

    void Start()
    {
        allSlots = 40;
        slot = new GameObject[allSlots];
        inventory.SetActive(false);
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if(slot[i].GetComponent<Slot>().itemHeld == 0)
            {
                slot[i].GetComponent<Slot>().empty = true;
                slot[i].GetComponent<Slot>().Num.SetActive(false);
                slot[i].GetComponent<Slot>().Icon1.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
        }
        
        if(isOpen == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
        pieces = num;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject pickedUp = other.gameObject;
            Item item = pickedUp.GetComponent<Item>();
            AddItem(pickedUp, item.ID, item.type, item.description, item.icon, item.itemHeld);
        }

    }
    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon, int itemHeld)
    {
        if (itemType == "keyPieces")
        {
           num++;
        }
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().description == "keyPieces" && itemDescription=="keyPieces" )
            {
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().itemHeld = itemHeld + slot[i].GetComponent<Slot>().itemHeld;
                itemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
        }
            for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().itemHeld= itemHeld;
                slot[i].GetComponent<Slot>().Num.SetActive(true);
                slot[i].GetComponent<Slot>().Icon1.SetActive(true);
                itemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
            else if (slot[i].GetComponent<Slot>().description == itemDescription)
            {
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().itemHeld = itemHeld + slot[i].GetComponent<Slot>().itemHeld;
                itemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
        }
    }
    public void Purchase(int ID, string type, string description, Sprite icon, int itemHeld)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                slot[i].GetComponent<Slot>().icon = icon;
                slot[i].GetComponent<Slot>().type = type;
                slot[i].GetComponent<Slot>().description = description;
                slot[i].GetComponent<Slot>().ID = ID;
                slot[i].GetComponent<Slot>().itemHeld = itemHeld;
                slot[i].GetComponent<Slot>().Num.SetActive(true);
                slot[i].GetComponent<Slot>().Icon1.SetActive(true);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
            if (slot[i].GetComponent<Slot>().description == description)
            {
                slot[i].GetComponent<Slot>().itemHeld = itemHeld + slot[i].GetComponent<Slot>().itemHeld;
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
        }     
    }

}
