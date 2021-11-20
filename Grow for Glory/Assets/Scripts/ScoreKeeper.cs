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
        score = 0;
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        plot1 = GameObject.Find("Plot_1_area");
        plot2 = GameObject.Find("Plot_2_area");
        plot3 = GameObject.Find("Plot_3_area");
        plot4 = GameObject.Find("Plot_4_area");
    }

    // Update is called once per frame
    void Update()
    {
        plot1Score = plot1.GetComponent<PlotStats1>().plotScore;
        plot2Score = plot2.GetComponent<PlotStats2>().plotScore;
        plot3Score = plot3.GetComponent<PlotStats3>().plotScore;
        plot4Score = plot4.GetComponent<PlotStats4>().plotScore;

        score = plot1Score + plot2Score + plot3Score + plot4Score;
        ScoreText.text = "Current Score: " + score;
    }
}
