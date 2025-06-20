using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Puntuaje inicial
    public TMP_Text scoreText; // Referencia al componente de texto para mostrar el puntaje
    public int scoreIncrement = 1; // Puntos que se añaden por segundo
    public float incrementInterval = 1f; // Intervalo de tiempo en segundos para incrementar el puntaje

    private float timeSinceLastIncrement = 1f;

    void Start()
    {
        // Inicializar el texto del puntaje
        UpdateScoreText();
    }

    void Update()
    {
        // Incrementar el puntaje basado en el tiempo
        timeSinceLastIncrement += Time.deltaTime;

        if (timeSinceLastIncrement >= incrementInterval)
        {
            AddScore(scoreIncrement);
            timeSinceLastIncrement = 0f;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
