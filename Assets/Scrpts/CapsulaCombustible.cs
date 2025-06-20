using UnityEngine;

public class CapsulaCombustible : MonoBehaviour
{
    public AudioSource recargaAudioSource; // AudioSource para el sonido de recarga

    private void Start()
    {
        if (recargaAudioSource == null)
        {
            Debug.LogError("No se encontró el AudioSource para el sonido de recarga.");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("nave")) // Verifica que el objeto que colisiona tiene el tag "nave"
        {
            // Obtener el script de combustible de la nave
            Combustible combustibleNave = other.GetComponentInParent<Combustible>();

            if (combustibleNave != null)
            {
                combustibleNave.RecargarCombustible();
                
                // Reproducir sonido de recarga
                PlayRecargaSound();

                 // Esta función se define en el controlador del juego

                Destroy(gameObject); // Destruir la cápsula de combustible solo cuando la nave colisiona
            }
        }
    }

    private void PlayRecargaSound()
    {
        if (recargaAudioSource != null)
        {
            recargaAudioSource.Play();
        }
        else
        {
            Debug.LogError("No se encontró el AudioSource para el sonido de recarga.");
        }
    }
}
