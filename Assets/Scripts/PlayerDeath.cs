// // using UnityEngine;
// // using UnityEngine.SceneManagement;

// // public class PlayerDeath : MonoBehaviour
// // {
// //     private bool isDead = false;

// //     private void OnTriggerEnter2D(Collider2D other)
// //     {
// //         if (isDead) return;

// //         if (other.CompareTag("Snowball"))
// //         {
// //             isDead = true;

// //             string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");
// //             int finalScore = 0;

// //             if (ScoreManager.Instance != null)
// //                 finalScore = ScoreManager.Instance.GetScore();

// //             GameData.SaveScore(playerName, finalScore);

// //             SceneManager.LoadScene("HighScoreScene");
// //         }
// //     }
// // }

// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PlayerDeath : MonoBehaviour
// {
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Waterfall"))
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         Debug.Log("Purly melted 💀");

//         // Reload scene (or go to Game Over)
//         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//     }
// }