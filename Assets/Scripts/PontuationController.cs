using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontuationController : MonoBehaviour
{
    public Text uiScoreText;
    public Text uiRecordText;
    public int score;

    void Update()
    {
        int currentRecord = PlayerPrefs.GetInt("Record");

        if (score > currentRecord)
        {
            PlayerPrefs.SetInt("Record", score);
        }

        uiScoreText.text = "Score: " + score;
        uiRecordText.text = "Record: " + currentRecord;
    }
}
