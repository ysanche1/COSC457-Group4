using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotStats2 : MonoBehaviour
{
    public int plotScore;
    public Text plotTotal;


    // Start is called before the first frame update
    void Start()
    {
        plotScore = 0;
        plotTotal = GameObject.Find("plot_total_2").GetComponent<Text>();
        plotTotal.text = "Plot Total: " + plotScore;
    }

    // Update is called once per frame
    void Update()
    {

        plotTotal.text = "Plot Total: " + plotScore;
    }
    public void IncreaseTotal(int increase)
    {
        plotScore = (plotScore + increase);
    }
}