using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private Text endScore;
    public void Start()
    {
        Debug.Log("final score: " + ScoreKeeper.score);
        endScore = GameObject.Find("endScore").GetComponent<Text>();
        endScore.text = "Final Score: " + ScoreKeeper.score;

    }
}
