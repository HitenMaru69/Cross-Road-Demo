using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EventHandler PlayerHit;
    public bool isPlayerDie;

    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] TextMeshProUGUI score_Txt;
    [SerializeField] TextMeshProUGUI gameOver_ScoreTxt;
    [SerializeField] SoundManager soundManager;
    
    private int currentScore = 0;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            score_Txt.text = "Score : " + currentScore; 
        }
    }


    private void Awake()
    {
       instance = this;
       
    }

    private void OnEnable()
    {
        PlayerHit += OnPlayerDie;
    }



    private void Start()
    {
        gameOverCanvas.enabled = false;
        score_Txt.text = "Score : " + currentScore;
        isPlayerDie = false;
    }


    #region Event Invoke
    public void CallPlayerHitEvent()
    {
        PlayerHit?.Invoke(this, EventArgs.Empty);
    }

    #endregion


    #region UI 


    public void Restart_BU()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }

    public void Home_BU()
    {
        SceneManager.LoadScene("HomeScreen");
        Time.timeScale = 1;
    }

    private void OnPlayerDie(object sender, EventArgs e)
    {
        gameOver_ScoreTxt.text = "Score : " + currentScore;
        gameOverCanvas.enabled = true;
        isPlayerDie=true;
        Time.timeScale = 0;
    }

    #endregion

    private void OnDisable()
    {
        PlayerHit -= OnPlayerDie;   
    }
}
