using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    float speed = 70f;
    float textBegin = -1215f;
    float textEnd = 1218f;

    RectTransform textTransform;
    [SerializeField] TextMeshProUGUI text;
    private void Start()
    {
        textTransform = gameObject.GetComponent<RectTransform>();
        transform.localPosition = Vector3.up * textBegin;
        StartCoroutine(scrollText());
    }
    private void Update()
    {
        if (textTransform.localPosition.y > 1210f)
        {
            SceneManager.LoadScene(1);
        }
    }
    IEnumerator scrollText()
    {
        while(textTransform.localPosition.y < textEnd)
        {
            textTransform.Translate(Vector3.up * speed * Time.deltaTime);
            if(textTransform.localPosition.y > 1210f)
            {
                break;
            }
            
            yield return null;
        }     
    }
}
