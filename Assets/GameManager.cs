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
    
    [Header("Scenes")]
    public string winSceneName = "WinScreen";
    public string loseSceneName = "LoseScreen";
    public int targetScore = 10; // minimum score to avoid losing
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
            if (score < targetScore)
            {
                // Player did not reach enough points → Lose
                SceneManager.LoadScene(loseSceneName);
            }
            else
            {
                // Player reached target score or higher → Win
                SceneManager.LoadScene(winSceneName);
            }
        }
    
}