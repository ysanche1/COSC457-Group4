using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreKeeper : MonoBehaviour
{
    public int score;
    public Text ScoreText;
    public GameObject plot1, plot2, plot3, plot4;
    int plot1Score, plot2Score, plot3Score, plot4Score;

    // Start is called before the first frame update
    void Start()
    {
        //sets total score to 0
        score = 0;
        //store text compent of the Score game object
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        //stores the plot 1 area game object
        plot1 = GameObject.Find("Plot1");
        //stores the plot 2 area game object
        plot2 = GameObject.Find("Plot2");
        //stores the plot 3 area game object
        plot3 = GameObject.Find("Plot3");
        //stores the plot 4 area game object
        plot4 = GameObject.Find("Plot4");
    }

    // Update is called once per frame
    void Update()
    {
        //grabs and store the value of each plot score
        plot1Score = plot1.GetComponent<PlotStats>().plotScore;
        plot2Score = plot2.GetComponent<PlotStats>().plotScore;
        plot3Score = plot3.GetComponent<PlotStats>().plotScore;
        plot4Score = plot4.GetComponent<PlotStats>().plotScore;
        //adds all the scores together
        score = plot1Score + plot2Score + plot3Score + plot4Score;
        //changes the current score text 
        ScoreText.text = "Current Score: " + score;
    }
}
