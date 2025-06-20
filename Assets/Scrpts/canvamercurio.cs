using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvamercurio : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas nextLvlPlayCanvas; // Referencia al Canvas de "Next Level"
    void Start()
    {
        if (nextLvlPlayCanvas != null)
        {
            nextLvlPlayCanvas.gameObject.SetActive(false); // Asegúrate de que esté desactivado al inicio
            Debug.Log("Canvas de Next Level desactivado al inicio.");
        }
        else
        {
            Debug.LogError("No se encontró el Canvas de Next Level.");
        }
    } 
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name); // Línea de depuración

        if (collision.gameObject.CompareTag("mercurio")) // Verifica si el objeto colisionado tiene el tag "tierra"
        {
            Debug.Log("hola");
            MostrarNextLevelCanvas();
            Time.timeScale = 0;
        }
    }
    void MostrarNextLevelCanvas()
    {
        if (nextLvlPlayCanvas != null)
        {
            nextLvlPlayCanvas.gameObject.SetActive(true); // Mostrar el Canvas de "Next Level"
            Time.timeScale = 0; // Pausar el juego
            Debug.Log("Mostrando el Canvas de Siguiente Nivel y pausando el juego.");
        }
        else
        {
            Debug.LogError("nextLvlPlayCanvas no está asignado.");
        }
    }
}
