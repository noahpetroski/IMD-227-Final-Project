using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // Start the game
    void Start()
    {
        Cursor.visible = true;
    } 
    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
        Cursor.visible = false;
    }
}
