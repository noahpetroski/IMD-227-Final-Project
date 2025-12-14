using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    public static string score; // Shared across scenes, to access last score for game over screen
    public static int highScore = 0;
    public int numDigits = 5; // num of digits displayed for time

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TMP_Text>().SetText("YOUR SCORE WAS: " + score + "\nHIGH SCORE: " + highScore.ToString().PadLeft(numDigits, '0'));
    }

    public void setScore(string newScore)
    {
        score = newScore;
        if (int.Parse(score) > highScore)
        {
            highScore = int.Parse(score);
        }
    }
}
