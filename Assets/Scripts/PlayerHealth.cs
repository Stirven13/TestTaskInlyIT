using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Player player;

    Image healthBar;

    void Start()
    {
        healthBar = GetComponent<Image>();
        if (player != null)
        {
            player.OnHealthChanged += UpdateUI;
        }
    }

    void OnDestroy()
    {
        if (player != null)
        {
            player.OnHealthChanged -= UpdateUI;
        }
    }

    void UpdateUI(float healthPercent)
    {
        healthBar.fillAmount = healthPercent;
    }
}