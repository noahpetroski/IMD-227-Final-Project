using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Rotation : MonoBehaviour
{
    public float speed = 10.0f;

    float yRot = 0f;
    float xRot = 0f; 

    // Update is called once per frame
    void Update()
    {
        float xmove = 0f;
        float ymove = 0f;

        if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed) 
        {
            xmove = 1f;
        }
        else if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            xmove = -1f;
        }

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            ymove = -1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            ymove = 1f;
        }

        xRot = xRot + xmove * speed * Time.deltaTime;
        yRot = yRot + ymove * speed * Time.deltaTime;

        // Vertical rotation between 0 and 120 
        xRot = Mathf.Clamp(xRot, -120f, 120f);
        yRot = Mathf.Clamp(yRot, -100f, 100f);

        // Reset rotation
        transform.rotation = Quaternion.identity;

        // Apply the rotation we clamped
        transform.Rotate(xRot, yRot, 0f);
    }
}