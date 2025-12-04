using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] objsLaunch;
    private int objNum;
    public GameObject currObj;
    public bool shoot = false;
    void Start()
    {
        objNum = 0;
        currObj = objsLaunch[objNum];
        currObj.GetComponent<MeshRenderer>().enabled = true;
        for (int i = 1; i < objsLaunch.Length; i++)
        {
            objsLaunch[i].GetComponent<MeshRenderer>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            shoot = true;
        }

        if (shoot)
        {
            if (transform.position.z < -2)
            {
                transform.position += transform.forward * 5 * Time.deltaTime;
            } else
            {
                shoot = false;
                currObj.GetComponent<MeshRenderer>().enabled = false;
                transform.position = new Vector3(0.038f, 0.68f,-9.48f);
                objNum++;
                currObj = objsLaunch[objNum%objsLaunch.Length];
                currObj.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        
    }
}
