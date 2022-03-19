using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int totalScore = 0;
    public static Score instance;
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Singelton();
    }
    public void ChangeScore(int score)
    {
        totalScore += score;
        UI_Manager.instance.UpdateScore(totalScore);
    }
}
