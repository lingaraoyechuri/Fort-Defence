using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;
    public int currentHealth;
    public bool eDeath;
    public static Health SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void SetMaxHealth(int health )
	{
		slider.maxValue = health;
		slider.value = health;
		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(int health)
	{
        Debug.Log("Test3");
		slider.value = health;
        currentHealth = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

    public int GetCurrentHealth()
    {
        Debug.Log("test2");

            return currentHealth;
    }
}
