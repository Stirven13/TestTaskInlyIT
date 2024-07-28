using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHP = 100;
    private float hp;
    public float HP
    {
        get { return hp; }
        private set
        {
            float oldHP = hp;
            hp = Mathf.Clamp(value, 0, maxHP);
            if (oldHP != hp)
            {
                OnHealthChanged?.Invoke(hp / maxHP);
            }
        }
    }

    public event Action<float> OnHealthChanged;

    private LevelLoader levelLoader;

    void Start()
    {
        HP = maxHP;
        levelLoader = FindObjectOfType<LevelLoader>();
        if (levelLoader == null)
        {
            Debug.LogError("LevelLoader not found.");
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            levelLoader.RestartLevel();
        }
    }

    public void Heal(float amount)
    {
        HP += amount;
    }
}