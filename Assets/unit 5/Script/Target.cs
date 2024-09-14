using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody tragetRb;
    private float maxSpeed = 16;
    private float minSpeed = 12;
    private float torqueSpeed = 10;
    private float ySpawnPos = -2;
   [SerializeField] private float xRange = 4;
    


    public int pointValue;
    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        tragetRb = GetComponent<Rigidbody>();
        tragetRb.AddForce(RandomSpeed(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        tragetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //getting gameManager script from game manager object persent scene

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive )
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            gameManager.UpdateScore(pointValue);
            
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.tag); // Check what tag is being detected
        Destroy(gameObject); // Destroy the target object

        
        if (!other.CompareTag("bad"))
        {
            Debug.Log("Good tag detected. Updating lives.");
            gameManager.UpdateLives(-1);
        }
        else
        {
            Debug.Log("Non-good tag detected. No life update.");
        }
    }


    // void OnTriggerEnter(Collider other)
    //{
    //    Destroy(gameObject);
    //    if(!other.gameObject.CompareTag("Bad") && gameManager.isGameActive)
    //    {
    //        gameManager.UpdateLives(-1);
    //    }
    //}


    // click and Swiping
    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position,
    explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
       
    }

    Vector3 RandomSpeed()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-torqueSpeed, torqueSpeed);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
