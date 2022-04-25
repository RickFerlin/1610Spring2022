using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public Button startButton;
    public GameObject titleScreen;
    public GameObject gameOverScreen;

    private void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        titleScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
