using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private static int totalScore = 10;

    public static int TotalScore { get => totalScore; set => totalScore = value; }

    public static void ChangeScore(int score)
    {
        TotalScore += score;
        UI_Manager.instance.UpdateScore(TotalScore);
    }
}
