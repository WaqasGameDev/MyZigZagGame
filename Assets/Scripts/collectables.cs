using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectables : MonoBehaviour
{ public float rotationSpeed;
    public GameObject particles;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up,rotationSpeed*Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           GameObject particle = Instantiate(particles, transform.position, Quaternion.identity);
            GameManager.instance.score+=5;
            Destroy(transform.gameObject);
            Destroy(particle, 1f);
            
        }
    }
}
