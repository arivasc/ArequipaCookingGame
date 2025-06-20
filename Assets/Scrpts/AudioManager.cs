using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public AudioSource explosionAudioSource;
    public AudioSource endGameAudioSource;

    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Para que el AudioManager persista entre escenas
        }
        else
        {
            Destroy(gameObject); // Destruir duplicados
        }
    }

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("AudioManager");
                    instance = go.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundAudioSource != null && backgroundAudioSource.clip != null)
        {
            backgroundAudioSource.loop = true;
            backgroundAudioSource.Play();
        }
        else
        {
            Debug.LogError("No se encontró el AudioSource o el AudioClip para la música de fondo.");
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundAudioSource != null)
        {
            backgroundAudioSource.Stop();
        }
    }

    public void PlayExplosionSound()
    {
        if (explosionAudioSource != null && explosionAudioSource.clip != null)
        {
            explosionAudioSource.Play();
        }
        else
        {
            Debug.LogError("No se encontró el AudioSource o el AudioClip para el sonido de explosión.");
        }
    }

    public void PlayEndGameMusic()
    {
        if (endGameAudioSource != null && endGameAudioSource.clip != null)
        {
            endGameAudioSource.Play();
        }
        else
        {
            Debug.LogError("No se encontró el AudioSource o el AudioClip para la música de derrota.");
        }
    }
}
