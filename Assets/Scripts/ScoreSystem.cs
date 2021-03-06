using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] public TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    private float score;
    private bool shouldCount = true;
    
    void Update()
    {
        if(!shouldCount) { return; }

        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void StartScoreCounting()
    {
        shouldCount = true;
    }
    public int StopScoreCounting()
    {
        shouldCount = false;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }
}
