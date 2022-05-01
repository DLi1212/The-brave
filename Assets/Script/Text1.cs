using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text1 : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] float charsPerSecond = 0.1f;
    private Text Text;
    private string words;
    private float timer;
    private int currentPos = 0;

    private void Awake()
    {
        Text = GetComponent<Text>();
    }
    void Start()
    {
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.1f, charsPerSecond);
        words = Text.text;
        Text.text = "";
    }
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {
                timer = 0;
                currentPos++;
                Text.text = words.Substring(0, currentPos);

                if (currentPos >= words.Length)
                {
                    isActive = false;
                    timer = 0;
                    currentPos = 0;
                    Text.text = words;
                }
            }

        }
    }
}
