using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  
    [SerializeField] AudioSource backGround;
    public AudioSource crash;

    private void OnEnable()
    {
        GameManager.instance.PlayerHit += OnPlayerDieSound;
    }



    private void Start()
    {
        PlayAudio(backGround);
    }

    public void PlayAudio(AudioSource audioSource)
    {
        audioSource.Play();
    }

    private void OnPlayerDieSound(object sender, EventArgs e)
    {
        PlayAudio(crash);
    }


    private void OnDisable()
    {
        GameManager.instance.PlayerHit -= OnPlayerDieSound;
    }


}
