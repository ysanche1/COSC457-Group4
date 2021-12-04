using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffects : MonoBehaviour
{
    private GameObject manaBar;
    private GameObject dropZone;
    private GameObject plot1, plot2, plot3, plot4;
    private Text noMana;

    public void Start()
    {
        plot1 = GameObject.FindGameObjectWithTag("PlotStats1");
        plot2 = GameObject.FindGameObjectWithTag("PlotStats2");
        plot3 = GameObject.FindGameObjectWithTag("PlotStats3");
        plot4 = GameObject.FindGameObjectWithTag("PlotStats4");
        noMana = GameObject.Find("no_mana").GetComponent<Text>();
    }

    public void doCardAction(GameObject card)
    {
        string type = card.tag;
        dropZone = card.GetComponent<DragDrop>().dropZone;
        manaBar = card.GetComponent<DragDrop>().manaBar;
        switch(type) {
            case "+3AddCard":
                if (IsPlayable(card,.2))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.2);
                    increasePlot(dropZone.tag, 3);
                    Destroy(card);
                }
                break;
            case "+5AddCard":
                if (IsPlayable(card, .3))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.3);
                    increasePlot(dropZone.tag, 5);
                    Destroy(card);
                }
                break;
            case "+10AddCard":
                if (IsPlayable(card, .5))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.5);
                    increasePlot(dropZone.tag, 10);
                    Destroy(card);
                }
                break;
            case "X2MultiCard":
                if (IsPlayable(card, .4))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.4);
                    multiplyPlot(dropZone.tag, 2);
                    Destroy(card);
                }
                break;
            case "X3MultiCard":
                if (IsPlayable(card, .6))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.6);
                    multiplyPlot(dropZone.tag, 3);
                    Destroy(card);
                }
                break;
            case "X4MultiCard":
                if (IsPlayable(card, .8))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.8);
                    multiplyPlot(dropZone.tag, 4);
                    Destroy(card);
                }
                break;
            case "X10MultiCard":
                if (IsPlayable(card, 1))
                {
                    manaBar.GetComponent<Mana>().reduceMana(1);
                    multiplyPlot(dropZone.tag, 10);
                    Destroy(card);
                }
                break;
            case "PestCard":
                if (IsPlayable(card, .1))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.1);
                    increasePlot(dropZone.tag, -10);
                    Destroy(card);
                }
                break;
            case "+10weatherCard":
                if (IsPlayable(card, .5))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.5);
                    //increasePlot("PlotStats1", 10);
                    //increasePlot("PlotStats2", 10);
                    //increasePlot("PlotStats3", 10);
                    //increasePlot("PlotStats4", 10);
                    weatherAddCard(10);
                    Destroy(card);
                }
                break;
            case "X2weatherCard":
                if (IsPlayable(card, .5))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.5);
                    //increasePlot("PlotStats1", 10);
                    //increasePlot("PlotStats2", 10);
                    //increasePlot("PlotStats3", 10);
                    //increasePlot("PlotStats4", 10);
                    weatherMultiCard(3);
                    Destroy(card);
                }
              
                break;
        }
       
    }

    public void weatherAddCard(int increaseValue)
    {
        plot1.GetComponent<PlotStats1>().IncreaseTotal(increaseValue);
        plot2.GetComponent<PlotStats2>().IncreaseTotal(increaseValue);
        plot3.GetComponent<PlotStats3>().IncreaseTotal(increaseValue);
        plot4.GetComponent<PlotStats4>().IncreaseTotal(increaseValue);

    }
    public void weatherMultiCard(int multiValue)
    {
        plot1.GetComponent<PlotStats1>().multiplyTotal(multiValue);
        plot2.GetComponent<PlotStats2>().multiplyTotal(multiValue);
        plot3.GetComponent<PlotStats3>().multiplyTotal(multiValue);
        plot4.GetComponent<PlotStats4>().multiplyTotal(multiValue);

    }

    public void increasePlot(string plotTag, int increaseVal)
    {
        Debug.Log(plotTag);
        switch (plotTag)
        {
            case "PlotStats1":
                Debug.Log(increaseVal);
                dropZone.GetComponent<PlotStats1>().IncreaseTotal(increaseVal);
                break;
            case "PlotStats2":
                Debug.Log(increaseVal);
                dropZone.GetComponent<PlotStats2>().IncreaseTotal(increaseVal);
                break;
            case "PlotStats3":
                Debug.Log(increaseVal);
                dropZone.GetComponent<PlotStats3>().IncreaseTotal(increaseVal);
                break;
            case "PlotStats4":
                Debug.Log(increaseVal);
                dropZone.GetComponent<PlotStats4>().IncreaseTotal(increaseVal);
                break;

        }
    }

    public void multiplyPlot(string plotTag, int multVal)
    {
        Debug.Log(plotTag);
        switch (plotTag)
        {
            case "PlotStats1":
                Debug.Log(multVal);
                dropZone.GetComponent<PlotStats1>().multiplyTotal(multVal);
                break;
            case "PlotStats2":
                Debug.Log(multVal);
                dropZone.GetComponent<PlotStats2>().multiplyTotal(multVal);
                break;
            case "PlotStats3":
                Debug.Log(multVal);
                dropZone.GetComponent<PlotStats3>().multiplyTotal(multVal);
                break;
            case "PlotStats4":
                Debug.Log(multVal);
                dropZone.GetComponent<PlotStats4>().multiplyTotal(multVal);
                break;

        }
    }
    public bool IsPlayable(GameObject card, double manaCost)
    {
    
        if (manaBar.GetComponent<Mana>().currMana < manaCost)
        {
            card.GetComponent<DragDrop>().returnToHand();
            StartCoroutine(wait(1));
            

            return false;
        }
        else
        {
            return true;
        }
           
    }
    IEnumerator wait(int time)
    {
        noMana.text = "Insuficent Mana";
        yield return new WaitForSeconds(time);
        noMana.text = "";
    }


}
