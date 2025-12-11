//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHoleMovement : MonoBehaviour
{
    public Camera cam;

    public float minHeight = -5;
    public float maxHeight = 5;
    public float minWidth = -5;
    public float maxWidth = 5;
    public float speed = .15f;

    //pulser variables
    public float pulseRate = 1f;
    public float pulseSize = .2f;
    private float pulseTheta;

    //pulser activation variables
    public bool boo = false;
   // bool imageShow = false;
    public float pulserCount = 0f;
    public float pulserDuration = 1f;

    //image object
    public GameObject gameEnd;
    public bool imageShow = false;

    // z coord variable
    float zcoord;


    void Start()
    {
        var startPos = new Vector3(0,2, 12);
        transform.position = startPos;
        gameEnd.SetActive(false);

        HoleMove();

    }
    void Update()
    {
        //on a trigger (the hole pulsing) the hole will move to a random location within the boundaries of a z, y and x coord
        //cube will move at a constant speed towards the camera
        if (boo==false){
        Vector3 camPos = (Camera.main.transform.position - transform.position);
        transform.position += camPos * Time.deltaTime * speed;
        }

        if (boo)
        {
            
            Pulser();
            pulserCount -= Time.deltaTime;

            // when pulse is done, move the hole
            if (pulserCount <= 0)
            {
                boo = false;
                HoleMove();
            }
        }
        if(imageShow ==true)
        {
            gameEnd.SetActive(true);
            //trigger end scene??
            Renderer holeMaterial = GetComponent<Renderer>();
            holeMaterial.enabled = false;

            //remember scene
            SceneManager.LoadScene("GameOver");

        }
    }

    void HoleMove()
    {
        //reset scale
        transform.localScale = new Vector3(2, 2, 2);
        zcoord = transform.position.z;
        //random position
        var holePos = new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight), zcoord);

        transform.position = holePos;
        Debug.Log(holePos);
    }

    void OnTriggerEnter(Collider collider)
    { 
        if (collider.gameObject.CompareTag("EndGame"))
        {
            imageShow = true;
        }
        else{
        boo = true;
        pulserCount = pulserDuration;
        }
       

    }

    void Pulser()
    {
        pulseTheta += pulseRate * 2 * Mathf.PI * Time.deltaTime;

       if (pulseTheta > 2 * Mathf.PI) pulseTheta -= 2 * Mathf.PI;


        float scale = 1 + pulseSize * Mathf.Sin(pulseTheta);

        transform.localScale = new Vector3(scale * 2, scale * 2, scale *2);

       // zcoord -= 4; 
       // transform.position.z = zcoord;
       
       // Debug.Log(scale + ", " + scale);
      
    }
}