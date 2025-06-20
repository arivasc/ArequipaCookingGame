using UnityEngine;
using UnityEngine.UI;

public class MoverNave : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento de la nave
    public float velocidadRotacion = 100f; // Velocidad de rotación de la nave
    public float combustibleMaximo = 100f; // Cantidad máxima de combustible
    public float consumoPorSegundo = 10f; // Combustible consumido por segundo al presionar espacio
    public AudioSource propulsionAudioSource;
    private float combustibleActual;
    private Rigidbody rb;
    public Image barraCombustible;
    //private AudioSource audioSource;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
        combustibleActual = combustibleMaximo; // Inicializa el combustible
        ActualizarBarraCombustible();
        //audioSource = GetComponent<AudioSource>(); // Inicializa el AudioSource
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarInput();
        Rotacion();
    }

    private void ProcesarInput()
    {
        Mover();
    }

    private void Mover()
    {
        if (Input.GetKey(KeyCode.Space) && combustibleActual > 0)
        {
            Vector3 direccion = transform.up; // Mover en la dirección a la que apunta la cabeza de la nave
            rb.AddForce(direccion * velocidad); // Aplicar fuerza en lugar de ajustar directamente la velocidad

            // Reducir el combustible
            combustibleActual -= consumoPorSegundo * Time.deltaTime;
            if (combustibleActual < 0)
            {
                combustibleActual = 0;
            }

            ActualizarBarraCombustible();

            // Reproducir el sonido
            if (!isMoving)
            {
                PlayPropulsionSound(true);
            }
        }
        else
        {
            // Detener el sonido cuando se suelta la tecla
            if (isMoving)
            {
                PlayPropulsionSound(false);
            }
        }
    }

    private void Rotacion()
    {
        float rotacion = 0;
        if (Input.GetKey(KeyCode.D))
        {
            rotacion = -velocidadRotacion; // Rotar a la derecha
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rotacion = velocidadRotacion; // Rotar a la izquierda
        }

        // Aplicar rotación directamente al transform
        transform.Rotate(Vector3.forward * rotacion * Time.deltaTime);
    }

    // Actualizar la barra de combustible en la UI
    private void ActualizarBarraCombustible()
    {
        if (barraCombustible != null)
        {
            float porcentajeCombustible = combustibleActual / combustibleMaximo;
            barraCombustible.fillAmount = porcentajeCombustible;
        }
    }

    // Manejar colisiones
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FuelCapsule"))
        {
            // Recargar el combustible
            combustibleActual = combustibleMaximo;
            ActualizarBarraCombustible();

            // Destruir la cápsula de combustible
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Meteorite"))
        {
            // Lógica cuando la nave colisiona con un meteorito
            Debug.Log("Colisionaste con un meteorito!");
        }
        else if (other.CompareTag("Venus"))
        {
            // Lógica cuando la nave llega a Venus
            Debug.Log("¡Llegaste a Venus!");
        }
    }
     private void PlayPropulsionSound(bool play)
    {
        if (propulsionAudioSource != null)
        {
            if (play)
            {
                if (!propulsionAudioSource.isPlaying)
                {
                    propulsionAudioSource.Play();
                    isMoving = true;
                }
            }
            else
            {
                propulsionAudioSource.Stop();
                isMoving = false;
            }
        }
        else
        {
            Debug.LogError("propulsionAudioSource es nulo.");
        }
    }
}


