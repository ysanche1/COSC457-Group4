using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    private GameObject manaBar;
    private GameObject dropZone;
    private GameObject plot1, plot2, plot3, plot4;

    public void Start()
    {
        plot1 = GameObject.FindGameObjectWithTag("PlotStats1");
        plot2 = GameObject.FindGameObjectWithTag("PlotStats2");
        plot3 = GameObject.FindGameObjectWithTag("PlotStats3");
        plot4 = GameObject.FindGameObjectWithTag("PlotStats4");
    }

    public void doCardAction(GameObject card)
    {
        string type = card.tag;
        dropZone = card.GetComponent<DragDrop>().dropZone;
        manaBar = card.GetComponent<DragDrop>().manaBar;
        switch(type) {
            case "addCard":
                manaBar.GetComponent<Mana>().reduceMana(.3);
                increasePlot(dropZone.tag, 5);
                break;
            case "multCard":
                manaBar.GetComponent<Mana>().reduceMana(.6);
                multiplyPlot(dropZone.tag, 3);
                break;
            case "pestCard":
                manaBar.GetComponent<Mana>().reduceMana(.2);
                increasePlot(dropZone.tag, 1);
                break;
            case "weatherCard":
                manaBar.GetComponent<Mana>().reduceMana(.5);
                //increasePlot("PlotStats1", 10);
                //increasePlot("PlotStats2", 10);
                //increasePlot("PlotStats3", 10);
                //increasePlot("PlotStats4", 10);
                weatherCard();
                break;
        }
        Destroy(card);
    }

    public void weatherCard()
    {
        plot1.GetComponent<PlotStats1>().IncreaseTotal(10);
        plot2.GetComponent<PlotStats2>().IncreaseTotal(10);
        plot3.GetComponent<PlotStats3>().IncreaseTotal(10);
        plot4.GetComponent<PlotStats4>().IncreaseTotal(10);

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


}
