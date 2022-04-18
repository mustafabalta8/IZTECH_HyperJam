using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMananger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip succesSFX;
    [SerializeField] private AudioClip failSFX;
    [SerializeField] private AudioClip throwingSFX;
    [SerializeField] private AudioClip bombSFX;
    [SerializeField] private AudioClip beepSFX;
    [SerializeField] private AudioClip fitilSFX;

    public static SoundMananger instance;
    private void Awake()
    {
        Singelton();
    }
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySuccessSound()
    {
        StopSound();
        audioSource.PlayOneShot(succesSFX);
    }
    public void PlayFailSound()
    {
        audioSource.PlayOneShot(failSFX);
    }
    public void PlayThrowSound()
    {
        StopSound();
        audioSource.PlayOneShot(throwingSFX);
    }
    public void PlayBombSound()
    {
        StopSound();
        audioSource.PlayOneShot(bombSFX);
    }
    public void PlayBeepSound()
    {
        audioSource.PlayOneShot(beepSFX);
    }
    public void StopSound()
    {
        audioSource.Stop();
    }
}
