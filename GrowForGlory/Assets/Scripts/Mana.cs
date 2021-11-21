using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public GameObject manaBar;
    public GameObject manaText;
    private Image barImage;
    private double maxMana = 1.0;
    public double currMana;
    public Text manaTotal;

    void Awake()
    {
        manaText = GameObject.Find("Mana_Cost");
        //finds the manabar game object
        manaBar = GameObject.Find("newManaBar");
        //finds mana total text componet
        manaTotal = manaText.GetComponent<Text>();
        //sets current mana to max on awake
        currMana = maxMana;
        //gets the image of the mana bar
        barImage = manaBar.GetComponent<Image>();
        //fills the bar completely
        barImage.fillAmount = 1;
    }

    //method to reduce the total mana by a float cost
    public void reduceMana(double Cost)
    {
        if (currMana <= 0.0)
        {
            Debug.Log("No Mana");
        }
        else
        {
            currMana = (currMana - Cost);
            barImage.fillAmount = ((float)currMana);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //fills the bar to the current mana amount
        barImage.fillAmount = ((float)currMana);
        //Debug.Log(currMana);
        //gets an int equivalent of the current mana
        double mana = currMana * 10;
        //Debug.Log(mana);
        //changes the text bassed on the current mana
        string total = "Mana: " + mana;
        manaTotal.text = total;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
