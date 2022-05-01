using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueDevil : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField] Text textLablel;
    [SerializeField] Text Text1;
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    [SerializeField] GameObject obj3;
    [SerializeField] float textSpeed;
    [SerializeField] TextAsset textFile;
    [SerializeField] int index;
    private bool isOpen = false;
    private bool isFinished;

    List<string> textList = new List<string>();
    private void Start()
    {
        obj1.SetActive(false);
        obj1.SetActive(false);
        obj3.SetActive(true);
        GetTextFormFile(textFile);
        isFinished = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && index == textList.Count)
        {
            GameObject.Find("SwordShieldCenturion").GetComponent<PlayerController>().enabled = true;
            obj1.SetActive(false);
            obj2.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.G) &&  isFinished)
        {
            StartCoroutine(SetTextUI());
        }
    }
    private void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isFinished)
        {
            StartCoroutine(SetTextUI());
            obj1.SetActive(true);
            obj2.SetActive(true);
            GameObject.Find("SwordShieldCenturion").GetComponent<PlayerController>().enabled = false;
            isOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            if (isOpen == true)
            {
                obj3.SetActive(false);
            }
        }
    }
    IEnumerator SetTextUI()
    {
        isFinished = false;
        textLablel.text = "";

        switch (textList[index].Trim().ToString())
        {
            case "A":
                Text1.text = "Devil";
                index++;
                break;
            case "B":
                Text1.text = "Knight";
                index++;
                break;
        }

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLablel.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }
        isFinished = true;
        index++;
    }
}
