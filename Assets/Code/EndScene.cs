using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // Start the game
    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
