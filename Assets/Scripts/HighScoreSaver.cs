using UnityEngine;

public class HighScoreSaver : MonoBehaviour
{
    private const int maxScores = 5;

    public void SaveScore(int newScore)
    {
        // Load existing scores
        int[] scores = new int[maxScores];

        for (int i = 0; i < maxScores; i++)
        {
            scores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
        }

        // Insert new score
        for (int i = 0; i < maxScores; i++)
        {
            if (newScore > scores[i])
            {
                // shift down
                for (int j = maxScores - 1; j > i; j--)
                {
                    scores[j] = scores[j - 1];
                }

                scores[i] = newScore;
                break;
            }
        }

        // Save back to PlayerPrefs
        for (int i = 0; i < maxScores; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, scores[i]);
        }

        PlayerPrefs.Save();
    }
}