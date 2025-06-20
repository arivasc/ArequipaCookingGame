using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public string nextSceneName = "Nivel 02"; // Nombre de la siguiente escena

    public void CargarSiguienteNivel()
    {
        Debug.Log("Cargando siguiente nivel: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
