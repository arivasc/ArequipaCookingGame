using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena1 : MonoBehaviour
{
    public string nextSceneName = "Nivel 03"; // Nombre de la siguiente escena

    public void CargarSiguienteNivel()
    {
        Debug.Log("Cargando siguiente nivel: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
