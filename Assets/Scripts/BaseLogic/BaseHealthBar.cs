using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;


public class BaseHealthBar : MonoBehaviour
{
    public Slider BaseHealthSlider;
    public float MaxBaseHealth = 3f;
    public float health;
    
    void Start()
    {
        health = MaxBaseHealth;
    }

   
    void Update()
    {
        if(BaseHealthSlider.value != health)
        {
            BaseHealthSlider.value = health;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            health -= 1f;
        }

        if(health <= 0f)
        {
            
        }
    }
    public void TakeDMG(float dmgg)
    {
        health -= dmgg;
    }
}

