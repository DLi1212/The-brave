using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] GameObject Text;
    [SerializeField] GameObject tip;
    [SerializeField] GameObject tip1;
    [SerializeField] GameObject gui1;
    [SerializeField] GameObject gui2;
    [SerializeField] GameObject loadingPage;
    [SerializeField] Text text;
    [SerializeField] Slider slider;
    [SerializeField] Text tipText;
    [SerializeField] string[] tips;
    [SerializeField] CanvasGroup canvas;
    [SerializeField] GameObject[] slot;

    private int allSlots;
    bool inTrigger = false;
    bool fullCollect = false;
    public bool isOpen1 = false;
    public bool isOpen2 = false;
    float progress = 0;
    float total_time = 9f;
    float time = 0;
    int tipCount;
    bool loadingNextLevel = false;

    // Start is called before the first frame update

    private void Start()
    {
        allSlots = 40;
        loadingPage.SetActive(false);
        tip.SetActive(false);
        tip1.SetActive(false);
        Text.SetActive(false);
        gui2.SetActive(false);
    }
    private void check()
    {
        for(int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().itemHeld == 4 && slot[i].GetComponent<Slot>().type == "keyPieces")
            {
                fullCollect = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && inTrigger == true)
        {
            GameObject.Find("SwordShieldCenturion").GetComponent<PlayerController>().enabled = false;
            Text.SetActive(false);
            tip.SetActive(true);
            isOpen1 = true;
        }

        if (loadingNextLevel == true)
        {
            time += Time.deltaTime;
            progress = time / total_time;
            if (progress >= 1)
            {
                GameObject.Find("SwordShieldCenturion").GetComponent<PlayerController>().enabled = true;
                SceneManager.LoadScene(2);
                return;
            }
            slider.value = progress;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Text.SetActive(true);
            inTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Text.SetActive(false);
        inTrigger = false;
    }

    public void Yes()
    {
        check();
        if( fullCollect == true)
        {
            tip.SetActive(false);
            loadingPage.SetActive(true);
            StartCoroutine(LoadLeaver());
            StartCoroutine(Tips());
            loadingNextLevel = true;
            isOpen1 = false;
            gui1.SetActive(false);
            gui2.SetActive(true);
        }
        else
        {
            isOpen1 = false;
            isOpen2 =  true;
            tip.SetActive(false);
            tip1.SetActive(true);
        }
    }
    public void No()
    {
        GameObject.Find("SwordShieldCenturion").GetComponent<PlayerController>().enabled = true;
        tip.SetActive(false);
        isOpen1 = false;
    }
    public void OK()
    {
        GameObject.Find("SwordShieldCenturion").GetComponent<PlayerController>().enabled = true;
        tip1.SetActive(false);
        isOpen2 = false;
    }
    IEnumerator LoadLeaver()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            string reminder = "";
            float f = slider.value;
            if (f < 1f)
            {
                reminder = "Loading...";
            }
            text.text = reminder;
        }
    }

    IEnumerator Tips()
    {
        while (true)
        {
            tipCount = Random.Range(0, tips.Length);
            tipText.text = tips[tipCount];
            while (loadingPage.activeInHierarchy)
            {
                yield return new WaitForSeconds(2f);

                LeanTween.alphaCanvas(canvas, 0, 0.5f);
                yield return new WaitForSeconds(0.5f);
                tipCount++;
                if (tipCount >= tips.Length)
                {
                    tipCount = 0;
                }

                tipText.text = tips[tipCount];
                LeanTween.alphaCanvas(canvas, 1, 0.5f);
            }
        }
    }

}
