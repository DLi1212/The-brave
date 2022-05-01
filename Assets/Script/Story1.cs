using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Story1 : MonoBehaviour
{
    float speed = 60f;
    float textBegin = -855f;
    float textEnd = 944f;

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
        if (textTransform.localPosition.y > 934f)
        {
            Invoke("Scene", 3f);
        }
    }
    IEnumerator scrollText()
    {
        while (textTransform.localPosition.y < textEnd)
        {
            textTransform.Translate(Vector3.up * speed * Time.deltaTime);
            if (textTransform.localPosition.y > 934f)
            {
                break;
            }
            yield return null;
        }
    }
    void Scene()
    {
        SceneManager.LoadScene(0);
    }
}
