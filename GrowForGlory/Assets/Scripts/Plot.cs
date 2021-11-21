using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{
    public int plotScore;
    public Text plotTotal;

    // Start is called before the first frame update
    void Start()
    {
        // from previous PlotStats1/2/3/4 scripts
        // sets the score of the plot to zero at the start
        plotScore = 0;
        // grabs the text compenet of the prot_total_1 game object
        plotTotal = GameObject.Find("plot_total_1").GetComponent<Text>();
        // sets the plot total text
        plotTotal.text = "Plot Total: " + plotScore;
    }

    // Update is called once per frame
    void Update()
    {
        // sets the plot total text to display the plot score
        plotTotal.text = "Plot Total: " + plotScore;
    }

    public void IncreaseTotal(int increase)
    {
        // increments the plot score by the entered amount 
        plotScore += increase;
    }
}
