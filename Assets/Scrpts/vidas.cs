using UnityEngine;
using UnityEngine.UI;

public class vidas : MonoBehaviour
{
    public int v = 3;
    public Image[] vidasImages;
    public Canvas endGameCanvas;
    public Canvas next;
    private ParticleSystem particulasDestruccion;

    void Start()
    {
        ActualizarVidasUI();
        particulasDestruccion = GetComponentInChildren<ParticleSystem>();

        if (particulasDestruccion == null)
        {
            Debug.LogError("No se encontró el sistema de partículas de destrucción.");
        }

        if (endGameCanvas != null)
        {
            endGameCanvas.gameObject.SetActive(false);
        }

        if (next != null)
        {
            next.gameObject.SetActive(false);
        }

        AudioManager.Instance.PlayBackgroundMusic();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("meteorito"))
        {
            PerderVida();
        }
        else if (collision.gameObject.CompareTag("tierra"))
        {
            MostrarNextLevelCanvas();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado con: " + other.gameObject.name);
        if (other.CompareTag("tierra"))
        {
            MostrarNextLevelCanvas();
        }
    }

    void PerderVida()
    {
        if (v > 0)
        {
            v--;
            ActualizarVidasUI();
            AudioManager.Instance.PlayExplosionSound();
            if (particulasDestruccion != null)
            {
                particulasDestruccion.Play();
            }
        }

        if (v <= 0)
        {
            Debug.Log("¡La nave ha sido destruida!");
            PausarJuego();
        }
    }

    void ActualizarVidasUI()
    {
        for (int i = 0; i < vidasImages.Length; i++)
        {
            vidasImages[i].enabled = i < v;
        }
    }

    void PausarJuego()
    {
        Time.timeScale = 0;
        Debug.Log("Juego Pausado.");

        if (endGameCanvas != null)
        {
            endGameCanvas.gameObject.SetActive(true);
        }

        AudioManager.Instance.StopBackgroundMusic();
        AudioManager.Instance.PlayEndGameMusic();
    }

    void MostrarNextLevelCanvas()
    {
        Time.timeScale = 0;
        Debug.Log("Colisión con la Tierra. Mostrando el Canvas de Siguiente Nivel y congelando el juego.");

        if (next != null)
        {
            next.gameObject.SetActive(true);
        }

        AudioManager.Instance.StopBackgroundMusic();
    }
}
