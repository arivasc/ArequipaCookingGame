using UnityEngine;
using UnityEngine.UI;

public class Combustible : MonoBehaviour
{
    public float combustible = 100f;
    public float consumoPorSegundo = 5f;
    public Image imagenCombustibleFrontal;
    public Canvas endGameCanvas;

    private bool juegoTerminado = false;

    void Start()
    {
        if (endGameCanvas != null)
        {
            endGameCanvas.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!juegoTerminado)
        {
            ActualizarCombustible();
        }
    }

    private void ActualizarCombustible()
    {
        combustible -= consumoPorSegundo * Time.deltaTime;

        if (combustible < 0)
        {
            combustible = 0;
        }

        if (imagenCombustibleFrontal != null)
        {
            imagenCombustibleFrontal.fillAmount = combustible / 100f;
        }

        if (combustible <= 0 && !juegoTerminado)
        {
            FinDelJuego();
        }
    }

    public void RecargarCombustible()
    {
        combustible = 100f;
    }

    private void FinDelJuego()
    {
        juegoTerminado = true;
        PausarJuego();
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
}
