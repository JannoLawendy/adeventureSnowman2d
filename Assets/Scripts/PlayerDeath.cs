// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PlayerDeath : MonoBehaviour
// {
//     private bool isDead = false;

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (isDead) return;

//         if (other.CompareTag("Snowball"))
//         {
//             isDead = true;

//             string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");
//             int finalScore = 0;

//             if (ScoreManager.Instance != null)
//                 finalScore = ScoreManager.Instance.GetScore();

//             GameData.SaveScore(playerName, finalScore);

//             SceneManager.LoadScene("HighScoreScene");
//         }
//     }
// }