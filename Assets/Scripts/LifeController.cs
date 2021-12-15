using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] private Sprite fullHeart, emptyHeart;
    [SerializeField] private Image[] hearts;

    [SerializeField] private int life, maxLife;

    void Start()
    {
        this.life = maxLife;
        UpdateLifes();
    }

    public bool IsDead()
    {
        if (life <= 0)
        {
            life = maxLife;
            UpdateLifes();
            return true;
        }
        else
        {
            return false;
        }
    }

    void UpdateLifes()
    {
        for (int i = 0; i < maxLife; i++)
        {
            if (i < life)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }


    public void LifeLost(int value)
    {
        life -= value;
        UpdateLifes();

        if(life < 0)
        {
            life = 0;
        }
    }
}
