using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text timerText;
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;
        string seconds = (t % 60).ToString("f0");
        timerText.text = seconds;
    }
}
