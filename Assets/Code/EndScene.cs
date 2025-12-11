using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("hi");
    }
}
