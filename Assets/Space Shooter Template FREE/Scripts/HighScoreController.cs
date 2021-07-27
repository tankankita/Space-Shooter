using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class HighScoreController : MonoBehaviour
{

    public static HighScoreController instance;

    public long[] highScores = new long[10];

    public TextMeshProUGUI highScoreList;

    public TextMeshProUGUI topScore;


     void Start()
    {
        SetHighScoreText();    
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public bool IsHighScore(long value)
    {
        foreach(long score in highScores)
        {
            if(value > score)
            {
                return true;
            }
        }
        return false;
    }

    public bool AddHighScore(long value)
    {
        if(!IsHighScore(value))
        {
            return false;
        }

        for(int i = 0; i<10;i++)
        {
            if(value > highScores[i])
            {
                var highScoreList = highScores.ToList();
                highScoreList.Insert(i, value);
                highScoreList.Remove(10);
                highScores = highScoreList.ToArray<long>();

                break;

            }
        }
        SetHighScoreText();

        return true;
    }

    public void SetHighScoreText()
    {
        string formattedScores = "";
        string topFormattedScores = "";

        for (int i =0; i<10;i++)
        {
            if(i==0)
            {
                topFormattedScores += "1 : "+ highScores[0] + "\n";
            } else
            {
                formattedScores += (i + 1) + " : " + highScores[i] + "\n";
            }
           
        }
        highScoreList.text = formattedScores;
        topScore.text = topFormattedScores;
    }
}
