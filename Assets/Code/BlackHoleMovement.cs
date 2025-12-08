//using System.Numerics;
using UnityEngine;

public class BlackHoleMovement : MonoBehaviour
{
    public Camera cam;

    public float minHeight = -5;
    public float maxHeight = 5;
    public float minWidth = -5;
    public float maxWidth = 5;
    public float speed = 1f;

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


    void Start()
    {
    
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
        }
    }

    void HoleMove()
    {
        //reset scale
        transform.localScale = new Vector3(3, 3, 3);
      
        //random position
        var holePos = new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight), 0);

        transform.position = holePos;

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

        transform.localScale = new Vector3(scale * 3, scale *3, scale *3);
       
        Debug.Log(scale + ", " + scale);
      
    }
}