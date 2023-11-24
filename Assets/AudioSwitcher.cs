using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    public AudioClip menuAudio;
    public AudioClip gameplayAudio;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Set initial audio clip to menu audio
        audioSource.clip = menuAudio;
        audioSource.Play();
    }

    void Update()
    {
        if (Time.timeScale == 0f && audioSource.clip != menuAudio)
        {
            // Deactivate gameplay audio and activate menu audio
            audioSource.Stop();
            audioSource.clip = menuAudio;
            audioSource.Play();
        }
        else if (Time.timeScale == 1f && audioSource.clip != gameplayAudio)
        {
            // Deactivate menu audio and activate gameplay audio
            audioSource.Stop();
            audioSource.clip = gameplayAudio;
            audioSource.Play();
        }
    }
}

