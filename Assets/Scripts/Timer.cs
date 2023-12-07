using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool engaged;
    private float timer = 0f;
    [SerializeField] private TextMeshProUGUI tmp;

    void Update()
    {
        if (engaged)
            RecordTime();
    }

    void RecordTime()
    {
        timer += Time.deltaTime;
        tmp.text = FormatTime(timer);
    }

    string FormatTime(float timeInSeconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        return $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
    }
}
