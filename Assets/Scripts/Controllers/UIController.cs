﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField] private Text scoreCounter;
    [SerializeField] private Text gameOverPopup;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdatedScores(int[] scores, int playerNumber)
    {
        scoreCounter.text = $"{scores[0]} : {scores[1]}";

        gameOverPopup.text = $"Player {playerNumber} win!";
        TurnGameOverPopup();
    }

    public void TurnGameOverPopup()
    {
        gameOverPopup.gameObject.SetActive(!gameOverPopup.gameObject.activeSelf);
    }

    //btns methods
    public void OnSinglePlayerBtn() { SceneManager.LoadScene(1); }
    public void OnMenuBtn() { SceneManager.LoadScene(0); }
}