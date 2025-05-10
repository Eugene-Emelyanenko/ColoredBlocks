using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public int currentScore = 0;
    private int _maxScore;

    [SerializeField] private Steps steps;
    [SerializeField] private BankGenerator bankGenerator;
    [SerializeField] private BallGenerator ballGenerator;
    [SerializeField] private Camera camera;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private GameObject leaderBoard;

    private int lastScoreToTriggerFunction = 0;
    void Start()
    {
        leaderBoard.SetActive(false);
        _maxScore = PlayerPrefs.GetInt("maxScore", 0);
        bestScoreText.text = _maxScore.ToString();
        scoreText.text = currentScore.ToString();
    }


    public void IncreaseScore()
    {
        currentScore++;

        scoreText.text = currentScore.ToString();

        if (currentScore > _maxScore)
        {
            _maxScore = currentScore;
            
            PlayerPrefs.SetInt("maxScore", _maxScore);
            
            bestScoreText.text = _maxScore.ToString();
        }
        
        if(currentScore >= 210)
            GameOver();
    }
    
    void Update()
    {
        if (currentScore >= lastScoreToTriggerFunction + 30 && currentScore <= 180)
        {
            steps.currentSteps += 15;
            lastScoreToTriggerFunction = currentScore;
            camera.transform.position = new Vector3(camera.transform.position.x,  camera.transform.position.y - 4f,
                camera.transform.position.z);
            if(camera.transform.position.y < -19.25f)
                camera.transform.position = new Vector3(camera.transform.position.x,  -19.25f,
                    camera.transform.position.z);
            ballGenerator.UnlockMore();
            bankGenerator.UnlockMore();
        }
        
        if(steps.currentSteps == 0)
            leaderBoard.SetActive(true);
    }

    public void GameOver()
    {
        currentScore += steps.currentSteps;
        leaderBoard.SetActive(true);
    }
}
