using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffects : MonoBehaviour
{
    private GameObject manaBar;
    private GameObject dropZone;
    private GameObject plot1, plot2, plot3, plot4;
    public GameObject Button;
    private Text noMana;
    private Text noEffect;


    public void Start()
    {
        plot1 = GameObject.FindGameObjectWithTag("PlotStats1");
        plot2 = GameObject.FindGameObjectWithTag("PlotStats2");
        plot3 = GameObject.FindGameObjectWithTag("PlotStats3");
        plot4 = GameObject.FindGameObjectWithTag("PlotStats4");
        Button = GameObject.Find("Draw_button");
        noMana = GameObject.Find("no_mana").GetComponent<Text>();
        noEffect = GameObject.Find("No_Effect").GetComponent<Text>();
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
                    FindObjectOfType<AudioManager>().Play("add card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
                    Destroy(card);
                }
                break;
            case "+5AddCard":
                if (IsPlayable(card, .3))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.3);
                    increasePlot(dropZone.tag, 5);
                    FindObjectOfType<AudioManager>().Play("add card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
                    Destroy(card);
                }
                break;
            case "+10AddCard":
                if (IsPlayable(card, .5))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.5);
                    increasePlot(dropZone.tag, 10);
                    FindObjectOfType<AudioManager>().Play("add card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
                    Destroy(card);
                }
                break;
            case "X2MultiCard":
                if (IsPlayable(card, .4) && CanMulti(dropZone, card))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.4);
                    multiplyPlot(dropZone.tag, 2);
                    FindObjectOfType<AudioManager>().Play("multi card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
                    Destroy(card);
                }
                break;
            case "X3MultiCard":
                if (IsPlayable(card, .6) && CanMulti(dropZone, card))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.6);
                    multiplyPlot(dropZone.tag, 3);
                    FindObjectOfType<AudioManager>().Play("multi card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
                    Destroy(card);
                }
                break;
            case "X4MultiCard":
                if (IsPlayable(card, .8) && CanMulti(dropZone, card))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.8);
                    multiplyPlot(dropZone.tag, 4);
                    FindObjectOfType<AudioManager>().Play("multi card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
                    Destroy(card);
                }
                break;
            case "X10MultiCard":
                if (IsPlayable(card, 1) && CanMulti(dropZone, card))
                {
                    manaBar.GetComponent<Mana>().reduceMana(1);
                    multiplyPlot(dropZone.tag, 10);
                    FindObjectOfType<AudioManager>().Play("multi card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
                    Destroy(card);
                }
                break;
            case "PestCard":
                if (IsPlayable(card, .1))
                {
                    manaBar.GetComponent<Mana>().reduceMana(.1);
                    increasePlot(dropZone.tag, -10);
                    FindObjectOfType<AudioManager>().Play("pest card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
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
                    FindObjectOfType<AudioManager>().Play("weather card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
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
                    FindObjectOfType<AudioManager>().Play("weather card play");
                    Button.GetComponent<Draw_button>().RemoveCardInHand();
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
    
        if ((float)manaBar.GetComponent<Mana>().currMana < (float)manaCost)
        {
            card.GetComponent<DragDrop>().returnToHand();
            StartCoroutine(noManaWait(1));
            return false;
        }
        else
        {
            return true;
        }
           
    }

    public bool CanMulti(GameObject plot, GameObject card)
    {
        if (plot.tag.Equals("PlotStats1"))
        {
            if (plot.GetComponent<PlotStats1>().plotScore <= 0)
            {
                card.GetComponent<DragDrop>().returnToHand();
                StartCoroutine(noEffectWait(1));
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (plot.tag.Equals("PlotStats2"))
        {
            if (plot.GetComponent<PlotStats2>().plotScore <= 0)
            {
                card.GetComponent<DragDrop>().returnToHand();
                StartCoroutine(noEffectWait(1));
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (plot.tag.Equals("PlotStats3"))
        {
            if (plot.GetComponent<PlotStats3>().plotScore <= 0)
            {
                card.GetComponent<DragDrop>().returnToHand();
                StartCoroutine(noEffectWait(1));
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (plot.tag.Equals("PlotStats4"))
        {
            if (plot.GetComponent<PlotStats4>().plotScore <= 0)
            {
                card.GetComponent<DragDrop>().returnToHand();
                StartCoroutine(noEffectWait(1));
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            card.GetComponent<DragDrop>().returnToHand();
            StartCoroutine(noEffectWait(1));
            return false;
        }

    }
    IEnumerator noManaWait(int time)
    {
        noMana.text = "Insuficent Mana";
        yield return new WaitForSeconds(time);
        noMana.text = "";
    }

    IEnumerator noEffectWait(int time)
    {
        noEffect.text = "No Effect";
        yield return new WaitForSeconds(time);
        noEffect.text = "";
    }



}
