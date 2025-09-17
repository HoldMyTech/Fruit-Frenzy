using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText; // assign a UI Text element in Inspector
    public float gameDuration = 30f; // 30 seconds
    private float timer;
    private int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        timer = gameDuration;
        score = 0;
        UpdateScoreUI();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void EndGame()
    {
        // Load your end screen scene
        SceneManager.LoadScene("EndScreen");
    }
}