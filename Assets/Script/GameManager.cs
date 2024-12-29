using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public EventHandler PlayerHit;

    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] TextMeshProUGUI score_Txt;

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
    }


    public void CallPlayerHitEvent()
    {
        PlayerHit?.Invoke(this, EventArgs.Empty);
    }


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
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
    }

    #endregion
}
