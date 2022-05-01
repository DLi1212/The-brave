using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    [SerializeField] Slider slider;
    void Start()
    {
        int health = PlayerController.instance.playerMaxHealth;
        MaxHealth(health);
    }

    void Update()
    {
        int health2 = PlayerController.instance.playerHealth;
        healthText.text = PlayerController.instance.playerHealth + "/" + PlayerController.instance.playerMaxHealth;
        SetHealth(health2);
    }

    public void MaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f) ;
    }

    public void SetHealth(int health2)
    {
        slider.value = health2;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
}
