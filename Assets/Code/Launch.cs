using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] objsLaunch; //possible bullets
    private int objNum; //number of bullets
    public GameObject currObj;
    public float speed = 20f; //speed of bullet
    public float lifetime = 4f; //how long each bullet exists for
    public Transform launchPos; //from where the bullet gets launched
    void Start()
    {
        objNum = 0;
        currObj = objsLaunch[objNum];
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        // Select an object from the list of possible objects to launch
        GameObject prefab = objsLaunch[objNum%objsLaunch.Length];
        objNum++;
        Camera cam = Camera.main;
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Aim firePoint at the hit point
            launchPos.LookAt(hit.point);

            // Spawn bullet
            GameObject bullet = Instantiate(prefab, launchPos.position, launchPos.rotation);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            BulletSettings settings = bullet.GetComponent<BulletSettings>();
            rb.linearVelocity = launchPos.forward * settings.speed;

            Destroy(bullet, lifetime);
        }

        /*Vector3 targetPoint = ray.GetPoint(1000f);
        Vector3 direction = (targetPoint - launchPos.position).normalized;
        rb.linearVelocity = launchPos.forward * settings.speed;*/


       /* BulletMover mover = bullet.AddComponent<BulletMover>();
        mover.speed = settings.speed;
        mover.lifetime = settings.lifetime;*/
       /* if (transform.position.z < -2)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                shoot = false;
            } else
            {
                currObj.GetComponent<MeshRenderer>().enabled = false;
                //transform.position = new Vector3(0.038f, 0.68f,-9.48f); // change to camera position
                //transform.position = Camera.main.transform.position;
                transform.position = launchPos.position;
                transform.rotation = launchPos.rotation; 
                objNum++;
                currObj = objsLaunch[objNum%objsLaunch.Length];
                currObj.GetComponent<MeshRenderer>().enabled = true;
            }*/
    }
}
