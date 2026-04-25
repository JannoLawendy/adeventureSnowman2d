using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;

    private int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        ResetScore();
    }

    public void AddScore(int amount = 1)
    {
        score += amount;

        if (score < 0)
            score = 0;

        UpdateUI();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned in ScoreManager.");
        }
    }
}



// using UnityEngine;
// using TMPro;

// public class ScoreManager : MonoBehaviour
// {
//     public TextMeshProUGUI scoreText;

//     private int score = 0;

//     void Start()
//     {
//         score = 0;
//         UpdateUI();
//     }

//     public void AddScore()
//     {
//         score++;
//         UpdateUI();
//     }

//     void UpdateUI()
//     {
//         if (scoreText != null)
//         {
//             scoreText.text = "Score: " + score;
//         }
//     }

//     public int GetScore()
//     {
//         return score;
//     }
// }