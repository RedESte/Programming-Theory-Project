using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{GameData.playerName}'s score: {gameManager.Score}";
    }
}
