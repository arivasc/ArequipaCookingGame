using UnityEngine;

public class Camara : MonoBehaviour
{
    public float velocidadSubida = 1f; // Velocidad a la que la cámara sube

    void LateUpdate()
{
    // Incrementar la posición Y de la cámara para que suba gradualmente
    Vector3 nuevaPosicion = transform.position;
    nuevaPosicion.y += velocidadSubida * Time.deltaTime;
    transform.position = nuevaPosicion;

    // Debugging para verificar el movimiento
    Debug.Log("Nueva posición de la cámara: " + transform.position);
}
}
