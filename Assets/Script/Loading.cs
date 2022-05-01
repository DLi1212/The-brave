using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject UI1;
    [SerializeField] GameObject Tutorial;
    [SerializeField] GameObject ON;
    [SerializeField] GameObject OFF;
    [SerializeField] GameObject scrollText;
    [SerializeField] Text text;
    [SerializeField] Slider slider;
    [SerializeField] Text tipText;
    [SerializeField] string[] tips;
    [SerializeField] CanvasGroup canvas;

    private AudioSource audioSource;
    float progress = 0;
    float total_time = 9f;
    float time = 0;
    int tipCount;
    bool loadingNextLevel = false;


    private void Start()
    {
        ON.SetActive(false);
        OFF.SetActive(true);
        UI.SetActive(false);
        UI1.SetActive(true);
        Tutorial.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }


    public void LoadNextLeaver()
    {
        UI.SetActive(true);
        UI1.SetActive(false);
        StartCoroutine(Tips());
        loadingNextLevel = true;
    }

    public void on()
    {
        audioSource.Pause();
        ON.SetActive(true);
        OFF.SetActive(false);
    }

    public void exit()
    {
        Application.Quit();
    }
    public void tutorial()
    {
        Tutorial.SetActive(true);
    }

    public void back()
    {
        Tutorial.SetActive(false);
    }
    public void off()
    {
        audioSource.UnPause();
        ON.SetActive(false);
        OFF.SetActive(true);
    }
    void Update()
    {
        if (loadingNextLevel == true)
        {
            time += Time.deltaTime;
            progress = time / total_time;
            if (progress >= 1)
            {
                scrollText.SetActive(true);
                return;
            }
            slider.value = progress;

        }
    }


    IEnumerator Tips()
    {
        while (true)
        {
            tipCount = Random.Range(0, tips.Length);
            tipText.text = tips[tipCount];
            while (UI.activeInHierarchy)
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
