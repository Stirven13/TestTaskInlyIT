using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHP = 100;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void TakeDamage(float damage)
    {
        HP = Mathf.Clamp(HP - damage, 0, maxHP);
        if (HP == 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void Heal(float amount)
    {
        HP = Mathf.Clamp(HP + amount, 0, maxHP);
    }
}
