using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotStats : MonoBehaviour
{
    public int plotScore;
    public Text plotTotal;

    // Start is called before the first frame update
    void Start()
    {
        // sets the score of the plot to zero at the start
        plotScore = 0;
        // grabs the text component of the plotTotal game object
        plotTotal = GameObject.Find("plotStats").GetComponent<Text>(); 
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
        // increments the plot score so by the entered amount 
        plotScore += increase;
    }
}
