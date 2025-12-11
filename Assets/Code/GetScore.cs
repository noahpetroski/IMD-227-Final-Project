using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    public static string score; // Shared across scenes, to access last score for game over screen

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TMP_Text>().SetText("YOUR SCORE WAS: " + score);
    }

    public void setScore(string newScore)
    {
        score = newScore;
    }
}
