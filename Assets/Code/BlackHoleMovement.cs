//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHoleMovement : MonoBehaviour
{
    public Camera cam;

    //random constraints
    public float minHeight = -5;
    public float maxHeight = 5;
    public float minWidth = -5;
    public float maxWidth = 5;

    public float maxLength = 9;
    public float minLength = 4;
    public float speed = .15f;

    //pulser variables
    public float pulseRate = 1f;
    public float pulseSize = .2f;
    private float pulseTheta;

    //pulser activation variables
    public bool boo = false;
    public float pulserCount = 0f;
    public float pulserDuration = 1f;

    //image object
    public GameObject gameEnd;
    public bool imageShow = false;

    // sound clip
    public AudioClip audioHoleMove; 

    

    void Start()
    {
        //start hole in same position
        var startPos = new Vector3(0,2, 12);
        transform.position = startPos;
        gameEnd.SetActive(false);

       // HoleMove();

    }
    void Update()
    {
        //if the object is not triggered, go towards camera
        if (boo==false){
        Vector3 camPos = (Camera.main.transform.position - transform.position);
        transform.position += camPos * Time.deltaTime * speed;
        }

        if (boo)
        {
            //if object is triggered, activate the pulser motion
            //pulser runs at normal speed and decreases
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
            //if hole hits the camera boolean is activated
            //gameEnd.SetActive(true);
            
           
          //  Renderer holeMaterial = GetComponent<Renderer>();
          //  holeMaterial.enabled = false;
            
            //trigger end scene
            //remember scene
            SceneManager.LoadScene("GameOver");

        }
    }

    void HoleMove()
    {
        //reset scale
        transform.localScale = new Vector3(2, 2, 2);
       
        //random position
        var holePos = new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight), Random.Range(minLength, maxLength));
        
        //set position to the random
        transform.position = holePos;
        //Debug.Log(holePos);
    }

    void OnTriggerEnter(Collider collider) //when object collides with hole
    { 
       
        //if object collides with camera change boolean
        if (collider.gameObject.CompareTag("EndGame"))
        {
            imageShow = true;
        }
        else{
       
        // play audio
        AudioSource.PlayClipAtPoint(audioHoleMove, transform.position);
        //set boo true
        boo = true;
      
        //reset the pulser count to the duration amount
        pulserCount = pulserDuration;

        //increase hole speed
        speed += .06f;
       
        }
       

    }

    void Pulser()
    {
        pulseTheta += pulseRate * 2 * Mathf.PI * Time.deltaTime;

       if (pulseTheta > 2 * Mathf.PI) pulseTheta -= 2 * Mathf.PI;


        float scale = 1 + pulseSize * Mathf.Sin(pulseTheta);

        transform.localScale = new Vector3(scale * 2, scale * 2, scale *2);
      
    }
}