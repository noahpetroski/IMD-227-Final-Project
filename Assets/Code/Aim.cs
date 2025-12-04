using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    public GameObject currThrowObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currMousePos = Mouse.current.position.ReadValue();
        float rotation = (currMousePos.x - 450) /10;
        transform.rotation = Quaternion.Euler(0, rotation, 0);

        if (!currThrowObj.GetComponent<Launch>().shoot) {
            currThrowObj.transform.rotation = Quaternion.Euler(0, rotation * 1.1f, 0);
        }
    }
}
