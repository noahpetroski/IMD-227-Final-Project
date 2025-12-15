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
        // Select a random object from the list of possible objects to launch
        GameObject prefab = objsLaunch[UnityEngine.Random.Range(0, objsLaunch.Length)];
  
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

            settings.PlayShootSound();

            Destroy(bullet, lifetime);
        }
    }
}
