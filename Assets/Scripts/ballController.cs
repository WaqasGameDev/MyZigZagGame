using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{ string axis = "z";
    Rigidbody rb;
    public float speed;
    Ray checkRay;
    RaycastHit hit;
    bool gameOver;
    public static ballController instance;
    private int rotationInt = 0;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && !gameOver)
            {
                rotationInt++;

                if (axis == "z")
                {
                    if (rotationInt > 1)
                    {
                      transform.Rotate(0, -90, 0);
                    }
                    
                    print(axis);
                    rb.velocity = new Vector3(0, 0, speed);
                    axis = "x";
                    

                }
                else if (axis == "x")
                {
                   transform.Rotate(0, 90, 0);
                    print(axis);
                    rb.velocity = new Vector3(speed, 0, 0);
                    axis = "z";

                }
            }
        }

        

        checkRay.origin = transform.position;
        checkRay.direction = Vector3.down;
        Debug.DrawRay(checkRay.origin, checkRay.direction * 200f, Color.red); //here 200f is used to give DRAWING Limit or drawing length to the ray so that we can see a long ray.
        if (!Physics.Raycast(checkRay, Mathf.Infinity) && !gameOver)
        {
            GameManager.instance.StopScore();
            GameManager.instance.yourScorePanel.SetActive(false);
            UIManager.instance.BottomYourScoreText.text = "YOUR SCORE: "+UIManager.instance.yourScoreInt.text;
            
            UIManager.instance.BestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore", 0).ToString();
            gameOver = true;
            CameraFollow.instance.gameOver = true;
            platformSpawner.instance.gameOver = true;
            UIManager.instance.GameOverPanel.SetActive(true);
            rb.velocity = Vector3.down*speed*3;
            Destroy(transform.gameObject, 2f);
        }
    }

    


}
