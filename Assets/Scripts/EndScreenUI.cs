using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private TMP_Text result;
    [SerializeField] private GameObject badPlushies;
    [SerializeField] private GameObject goodPlushies;
    void Start()
    {
        ScoreData scoreData = FindObjectOfType<ScoreData>();
        float timeLeft = scoreData.timeLeftOnStage;

        if (timeLeft > 0)
        {
            int totalSeconds = (int)Math.Ceiling(timeLeft);
            totalSeconds = 180 - totalSeconds;
            int secs = totalSeconds % 60;
            string extraZero = secs < 10 ? "0" : "";
            result.text = $"Fantastic work! You lasted {totalSeconds / 60}:{extraZero}{secs} in the plushie cleaning frenzy. Can you push it even further?";
            UpdatePlushyGraphics(false);
        }
        else
        {
            result.text = "Clean sweep! Every plushie sparkles thanks to you. The plushie kingdom salutes your greatness!";
            UpdatePlushyGraphics(true);
        }
    }

    private void UpdatePlushyGraphics(bool good)
    {
        badPlushies.SetActive(!good);
        goodPlushies.SetActive(good);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}
