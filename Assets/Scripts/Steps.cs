using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steps : MonoBehaviour
{
    public int startSteps = 15;
    public int currentSteps = 0;

    [SerializeField] private Text stepsText;
    void Start()
    {
        currentSteps = startSteps;
        stepsText.text = currentSteps.ToString();
    }

    public void Step()
    {
        currentSteps -= 1;
        
        
        if (currentSteps <= 0)
        {
            currentSteps = 0;

            Debug.Log("Game over");
        }

        stepsText.text = currentSteps.ToString();
    }
}
