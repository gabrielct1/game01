using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.Services.CloudSave;
using UnityEngine.UIElements;
using Unity.VisualScripting;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highestScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public CloudSave cloudSave;

    private void Start() {
        cloudSave = GetComponent<CloudSave>();
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd) {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenMenu() {
        SceneManager.LoadSceneAsync(1);
    }

    public void GameOver() {
        if (PlayerPrefs.GetInt("highestScore", 0) < playerScore) {
            PlayerPrefs.SetInt("highestScore", playerScore);
            cloudSave.SaveData(playerScore);
        }
        gameOverScreen.SetActive(true);    
    }
}
