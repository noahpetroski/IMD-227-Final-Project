using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    private float currTime;
    public int numDigits = 5; // num of digits displayed for time
    private bool stop = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            // Update the current time
            currTime += Time.deltaTime;
            int displayInt = (int) (currTime * 10);
            string displayText = displayInt.ToString();

            // Add padded zeroes to time/score and update the text on the screen
            displayText = displayText.PadLeft(numDigits, '0');
            gameObject.GetComponent<GetScore>().setScore(displayText);
            GetComponent<TMP_Text>().SetText(displayText.ToString());
        }
    }
}
