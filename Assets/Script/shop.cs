using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public static int ID;
    public static string type;
    public static int itemHeld;
    public static string description;
    public static Sprite icon;

    [SerializeField] GameObject text;
    [SerializeField] GameObject ShopUI;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject productHolder;

    [SerializeField] Button Button;
    [SerializeField] Text Text0;
    public static int cost0 = 1;
    public static int num0 = 99;

    [SerializeField] Button Button1;
    [SerializeField] Text Text1;
    public static int cost1 = 2;
    public static int num1 = 99;

    [SerializeField] Button Button2;
    [SerializeField] Text Text2;
    public static int cost2 = 3;
    public static int num2 = 99;

    [SerializeField] Button Button3;
    [SerializeField] Text Text3;
    public static int cost3 = 6;
    public static int num3 = 1;

    [SerializeField] Button Button4;
    [SerializeField] Text Text4;
    public static int cost4 = 6;
    public static int num4 = 1;

    private int allProducts;
    private GameObject[] product;
    private bool inTrigger = false;
    public bool isOpen = false;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        allProducts = 9;
        product = new GameObject[allProducts];
        for (int i = 0; i < allProducts; i++)
        {
            product[i] = productHolder.transform.GetChild(i).gameObject;
        }
        ShopUI.SetActive(false);
        text.SetActive(false);

        Text0.text = num0.ToString();
        Text1.text = num1.ToString();
        Text2.text = num2.ToString();
        Text3.text = num3.ToString();
        Text4.text = num4.ToString();
        Button.onClick.AddListener(Button_buyListen);
        Button1.onClick.AddListener(Button_buy01Listen);
        Button2.onClick.AddListener(Button_buy02Listen);
        Button3.onClick.AddListener(Button_buy03Listen);
        Button4.onClick.AddListener(Button_buy04Listen);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && inTrigger == true)
        {
            isOpen = !isOpen;
        }
        if (isOpen == true)
        {
            ShopUI.SetActive(true);
        }
        else
        {
            ShopUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ShopUI.SetActive(false);
        text.SetActive(false);
        inTrigger = false;
        isOpen = false;
    }
    void Button_buyListen()
    {
        if (cost0 <= PlayerController.instance.coins && num0 > 0)
        {
            PlayerController.instance.coins -= cost0;
            num0--;
            Text0.text = num0.ToString();
            ID = product[0].GetComponent<Product>().ID;
            type = product[0].GetComponent<Product>().type;
            itemHeld = product[0].GetComponent<Product>().itemHeld;
            description = product[0].GetComponent<Product>().description;
            icon = product[0].GetComponent<Product>().icon;
            inventory.Purchase(ID,type, description,icon,itemHeld);
            audioSource.Play();
        }
    }
    void Button_buy01Listen()
    {
        if (cost1 <= PlayerController.instance.coins && num1 > 0)
        {
            PlayerController.instance.coins -= cost1;
            num1--;
            Text1.text = num1.ToString();
            ID = product[1].GetComponent<Product>().ID;
            type = product[1].GetComponent<Product>().type;
            itemHeld = product[1].GetComponent<Product>().itemHeld;
            description = product[1].GetComponent<Product>().description;
            icon = product[1].GetComponent<Product>().icon;
            inventory.Purchase(ID, type, description, icon, itemHeld);
            audioSource.Play();
        }
    }
    void Button_buy02Listen()
    {
        if (cost2 <= PlayerController.instance.coins && num2 > 0)
        {
            PlayerController.instance.coins -= cost2;
            num2--;
            Text2.text = num2.ToString();
            ID = product[2].GetComponent<Product>().ID;
            type = product[2].GetComponent<Product>().type;
            itemHeld = product[2].GetComponent<Product>().itemHeld;
            description = product[2].GetComponent<Product>().description;
            icon = product[2].GetComponent<Product>().icon;
            inventory.Purchase(ID, type, description, icon, itemHeld);
            audioSource.Play();
        }
    }
    void Button_buy03Listen()
    {
        if (cost3 <= PlayerController.instance.coins && num3 > 0)
        {
            PlayerController.instance.coins -= cost3;
            num3--;
            Text3.text = num3.ToString();
            ID = product[3].GetComponent<Product>().ID;
            type = product[3].GetComponent<Product>().type;
            itemHeld = product[3].GetComponent<Product>().itemHeld;
            description = product[3].GetComponent<Product>().description;
            icon = product[3].GetComponent<Product>().icon;
            inventory.Purchase(ID, type, description, icon, itemHeld);
            audioSource.Play();
        }
    }
    void Button_buy04Listen()
    {
        if (cost4 <= PlayerController.instance.coins && num4 > 0)
        {
            PlayerController.instance.coins -= cost4;
            num4--;
            Text4.text = num4.ToString();
            ID = product[4].GetComponent<Product>().ID;
            type = product[4].GetComponent<Product>().type;
            itemHeld = product[4].GetComponent<Product>().itemHeld;
            description = product[4].GetComponent<Product>().description;
            icon = product[4].GetComponent<Product>().icon;
            inventory.Purchase(ID, type, description, icon, itemHeld);
            audioSource.Play();
        }
    }
}
