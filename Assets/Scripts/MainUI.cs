using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    GameManager gameManager;
    AudioSource audioSource;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }
    public void BackToMainMenu()
    {
        audioSource.Play();
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        scoreText.text = $"{GameData.Instance.playerName}'s score: {gameManager.Score}";
    }
}
