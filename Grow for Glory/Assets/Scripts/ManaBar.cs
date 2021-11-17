using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    private Image barImage;

    private float currFill;
    private float currMana;
    private float maxMana;

    public float MaxMana { get => maxMana; set => maxMana = value; }
    public float CurrMana
    {
        get
        {
            return currMana;
        }
        set
        {
            if (value >= maxMana)
            {
                currMana = maxMana;
            }
            else if (value < 0)
            {
                currMana = 0;
            }
            else
            {
                currMana = value;
            }
        }
    }

    private void Awake()
    {
        barImage = transform.Find("MB_Bar").GetComponent<Image>();
        barImage.fillAmount = 1.0f;
    }

    public void InitializeMana(float currentMana, float maximumMana)
    {
        CurrMana = currentMana;
        MaxMana = maximumMana;
    }
}
