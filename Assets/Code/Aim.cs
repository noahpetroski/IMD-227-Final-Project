using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    public GameObject currThrowObj;
    public Transform cam;              // assign in Inspector, or will use Camera.main
    public float rotationScale = 0.1f; // sensitivity
    private Vector3 camLocalOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         if (cam == null)
        {
            cam = Camera.main.transform;
        }

        // Where this object is relative to the camera at start
        camLocalOffset = cam.InverseTransformPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currMousePos = Mouse.current.position.ReadValue();
        float centerX = Screen.width * 0.5f;
        float centerY = Screen.height * 0.5f;

        float rotation_horiz = (currMousePos.x - centerX) * rotationScale;  //negative tilt = left, positive tilt = right, center is 0
        float rotation_vert  = -(currMousePos.y - centerY) * rotationScale; 

        //Position = camera position + (camera rotation * local offset)
        transform.position = cam.TransformPoint(camLocalOffset); 

        // Rotation = camera rotation * rotation from mouse
        Quaternion gunRot = Quaternion.Euler(rotation_vert, rotation_horiz, 0f); //rotation relative to cam based on mouse
        transform.rotation = cam.rotation * gunRot; 

        /*
        if (!currThrowObj.GetComponent<Launch>().shoot)
        {
            Quaternion throwLocalRot =
                Quaternion.Euler(rotation_vert * 1.1f, rotation_horiz * 1.1f, 0f);

            currThrowObj.transform.position = transform.position;
            currThrowObj.transform.rotation = cam.rotation * throwLocalRot;
        }*/

        /*Vector2 currMousePos = Mouse.current.position.ReadValue();
        float rotation_horiz= (currMousePos.x - 450) /10;
        float rotation_vert = -(currMousePos.y - 350) / 10;
        transform.rotation = Quaternion.Euler(rotation_vert, rotation_horiz, 0);
        */
      /*  if (!currThrowObj.GetComponent<Launch>().shoot) {
            currThrowObj.transform.rotation = Quaternion.Euler(rotation_vert *1.1f, rotation_horiz * 1.1f, 0);
        }*/
    }
}
