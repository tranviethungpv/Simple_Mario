using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    private int score1;
    private int score2;
    public Text scoreCoin;
    public Text scoreTannenzafen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void IncrementScoreCoin()
    {
        score1++;
        scoreCoin.text = score1.ToString();
    }
    public void IncrementScoreTannenzafen()
    {
        score2++;
        scoreTannenzafen.text = score2.ToString();
    }
}
