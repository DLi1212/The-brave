using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] AudioClip button;
    public bool empty;
    public int ID;
    public int itemHeld;
    public string type;
    public string description;
    public Sprite icon;

    private AudioSource audioSource;

    public GameObject Num;
    public GameObject Icon1;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
    }

    public void UpdateSlot()
    {
        Icon1.GetComponent<Image>().sprite = icon;
        Num.GetComponent<Text>().text = itemHeld.ToString();
    }

    public void UseItem()
    {
        if(itemHeld>0 && type != "keyPieces")
        {
            itemHeld = itemHeld - 1;
            Num.GetComponent<Text>().text = itemHeld.ToString();
            ItemUsage();
            audioSource.PlayOneShot(button);
        }
        if (itemHeld == 0)
        {
            Num.SetActive(false);
            Icon1.SetActive(false);
            icon = null;
            type = null;
            description = null;
            empty = true;
        }
    }
    public void ItemUsage()
    {
        // health item
        if (type == "health")
        {
            if (description == "Apple")
            {
                if (PlayerController.instance.playerHealth >= 95)
                {
                    PlayerController.instance.playerHealth = 100;
                }
                else
                {
                    PlayerController.instance.playerHealth += 5;
                }
            }
            if (description == "Meat")
            {
                if (PlayerController.instance.playerHealth >= 90)
                {
                    PlayerController.instance.playerHealth = 100;
                }
                else
                {
                    PlayerController.instance.playerHealth += 10;
                }
            }
            if (description == "Potion")
            {
                if (PlayerController.instance.playerHealth >= 85)
                {
                    PlayerController.instance.playerHealth = 100;
                }
                else
                {
                    PlayerController.instance.playerHealth += 15;
                }
            }
        }
        if (type == "attack")
        {
            if (description == "Sword")
            {
                PlayerAttack.weaponDamage = 10;
            }
        }
        if (type == "move")
        {
            if (description == "Shoes")
            {
                PlayerController.instance.runSpeed = 6;
                PlayerController.instance.walkSpeed = 4;
            }
        }
    }
}
