using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private TMP_Text result;
    void Start()
    {
        ScoreData scoreData = FindObjectOfType<ScoreData>();
        float timeLeft = scoreData.timeLeftOnStage;

        if (timeLeft > 0)
        {
            int seconds = (int)Math.Ceiling(timeLeft);
            result.text = $"You lose... You had {seconds / 60}:{seconds % 60} left to win.";
        }
        else
        {
            result.text = "Congradulations! You did it!";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}
