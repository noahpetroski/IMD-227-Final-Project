using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    public GameObject currThrowObj;
    public Transform cam;        
    public float rotationScale = 0.1f; // sensitivity
    private Vector3 camLocalOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
         if (cam == null)
        {
            cam = Camera.main.transform;
        }

        // Where this object is relative to the camera at start
        // Basically subtracting the camera's current pos from the aimer/guns current pos, then un rotating by the camera's rotation
        // converting aimer object/ gun coordinate system from world space to the camera's coordinate space
        camLocalOffset = Quaternion.Inverse(cam.rotation) * (transform.position - cam.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currMousePos = Mouse.current.position.ReadValue();
        float centerX = Screen.width * 0.5f;
        float centerY = Screen.height * 0.5f;

        //allowing the gun to be more centered
        //negative tilt= left, positive tilt = right, center is 0   
        float rotation_horiz = (currMousePos.x - centerX) * rotationScale; 
        //negative tilt = down, positive tilt = up
        //(currMousePos.y - centerY) multiplied by -1 since mouse going up would be neg and we want the rotation to be pos
        float rotation_vert  = -(currMousePos.y - centerY) * rotationScale;  

        //Position = camera position + (camera rotation * local offset)
        transform.position = cam.position + cam.rotation * camLocalOffset; 

        // Rotation = camera rotation * rotation from mouse
        Quaternion gunRot = Quaternion.Euler(rotation_vert, rotation_horiz, 0f); //rotation of gun relative to cam based on mouse position
        transform.rotation = cam.rotation * gunRot; 
    }
}
