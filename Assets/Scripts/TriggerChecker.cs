using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Invoke("FallDown", 0.5f);
        }
        
        
    }

    void FallDown()
    {
        rb.useGravity = true;
        Destroy(transform.parent.gameObject, 2f);
    }

    
}
