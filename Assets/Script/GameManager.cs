using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event EventHandler PlayerHit;

    private void Awake()
    {
        instance = this; 
    }


    public void CallPlayerHitEvent()
    {
        PlayerHit?.Invoke(this, EventArgs.Empty);
    }
}
