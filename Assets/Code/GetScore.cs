using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    public static string score; // Shared across scenes, to access last score for game over screen
    public static int highScore = 0; // highest score, shared across scenes
    public int numDigits = 5; // num of digits displayed for time

    // For game over scene, display player's score and their highest score
    void Start()
    {
        GetComponent<TMP_Text>().SetText("YOUR SCORE WAS: " + score + "\nHIGH SCORE: " + highScore.ToString().PadLeft(numDigits, '0'));
    }

    // Used in UpdateText to change the score while the player plays
    public void setScore(string newScore)
    {
        score = newScore;
        if (int.Parse(score) > highScore)
        {
            highScore = int.Parse(score);
        }
    }
}
