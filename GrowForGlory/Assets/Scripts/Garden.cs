using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garden : MonoBehaviour
{
    // assigned in Inspector
    public Plot plot1, plot2, plot3, plot4;
    public GameObject dropZone1, dropZone2, dropZone3, dropZone4;
    public Text scoreText;
    public int score;


    // Start is called before the first frame update
    void Start()
    {
        //sets total score to 0
        score = 0;
        //store text compent of the Score game object
        scoreText = GameObject.Find("Score").GetComponent<Text>();
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

    }
}
