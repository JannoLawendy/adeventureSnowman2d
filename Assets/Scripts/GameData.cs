// // using System.Collections.Generic;
// // using UnityEngine;

// // public static class GameData
// // {
// //     private const int MaxScores = 5;

// //     public static void SaveScore(string playerName, int score)
// //     {
// //         List<(string name, int score)> scores = GetScores();

// //         scores.Add((playerName, score));

// //         scores.Sort((a, b) => b.score.CompareTo(a.score));

// //         if (scores.Count > MaxScores)
// //             scores = scores.GetRange(0, MaxScores);

// //         PlayerPrefs.SetInt("ScoreCount", scores.Count);

// //         for (int i = 0; i < scores.Count; i++)
// //         {
// //             PlayerPrefs.SetString($"PlayerName_{i}", scores[i].name);
// //             PlayerPrefs.SetInt($"PlayerScore_{i}", scores[i].score);
// //         }

// //         PlayerPrefs.Save();
// //     }

// //     public static List<(string name, int score)> GetScores()
// //     {
// //         List<(string name, int score)> scores = new List<(string name, int score)>();

// //         int count = PlayerPrefs.GetInt("ScoreCount", 0);

// //         for (int i = 0; i < count; i++)
// //         {
// //             string name = PlayerPrefs.GetString($"PlayerName_{i}", "Unknown");
// //             int score = PlayerPrefs.GetInt($"PlayerScore_{i}", 0);
// //             scores.Add((name, score));
// //         }

// //         return scores;
// //     }

// //     public static void ClearScores()
// //     {
// //         int count = PlayerPrefs.GetInt("ScoreCount", 0);

// //         for (int i = 0; i < count; i++)
// //         {
// //             PlayerPrefs.DeleteKey($"PlayerName_{i}");
// //             PlayerPrefs.DeleteKey($"PlayerScore_{i}");
// //         }

// //         PlayerPrefs.DeleteKey("ScoreCount");
// //         PlayerPrefs.Save();
// //     }
// // }


using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    private const int MaxScores = 5;

    public static void SaveScore(string playerName, int score)
    {
        List<(string name, int score)> scores = GetScores();

        scores.Add((playerName, score));
        scores.Sort((a, b) => b.score.CompareTo(a.score));

        if (scores.Count > MaxScores)
            scores = scores.GetRange(0, MaxScores);

        PlayerPrefs.SetInt("ScoreCount", scores.Count);

        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetString($"PlayerName_{i}", scores[i].name);
            PlayerPrefs.SetInt($"PlayerScore_{i}", scores[i].score);
        }

        PlayerPrefs.Save();
    }

    public static List<(string name, int score)> GetScores()
    {
        List<(string name, int score)> scores = new List<(string name, int score)>();

        int count = PlayerPrefs.GetInt("ScoreCount", 0);

        for (int i = 0; i < count; i++)
        {
            string name = PlayerPrefs.GetString($"PlayerName_{i}", "Unknown");
            int score = PlayerPrefs.GetInt($"PlayerScore_{i}", 0);
            scores.Add((name, score));
        }

        return scores;
    }
}