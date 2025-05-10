using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void PauseBack()
    {
        Time.timeScale = 1;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    
    public void CantSelect()
    {
        Bank.canSelectBank = false;
    }
    
    public void CanSelect()
    {
        Bank.canSelectBank = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
