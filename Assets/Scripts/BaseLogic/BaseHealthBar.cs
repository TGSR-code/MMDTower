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
    public float MaxBaseHealth;
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

       

        
    }
    public void TakeDMG(float dmgg)
    {
        health -= dmgg;

        BaseHealthSlider.value = health;

    }
}

