using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMananger : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip succesSFX;
    [SerializeField] AudioClip failSFX;
    [SerializeField] AudioClip throwingSFX;
    [SerializeField] AudioClip bombSFX;
    [SerializeField] AudioClip beepSFX;
    [SerializeField] AudioClip fitilSFX;

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
