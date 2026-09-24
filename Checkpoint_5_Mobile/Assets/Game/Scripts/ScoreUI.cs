using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textScore;
    public event Action<int> OnScoreUpdate;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        textScore.text = "Score: " + score;
    }

    public void AddScore(int add)
    {
        score += add;
        OnScoreUpdate?.Invoke(score);
    }
}