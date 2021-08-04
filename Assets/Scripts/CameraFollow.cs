using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public GameObject objTofollow;
    //Vector3 pos;
    //Vector3 objStartPosition;
    //Vector3 objFinalPosition;
    //Vector3 changeInPosition;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    objStartPosition = objTofollow.transform.position;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    objFinalPosition = objTofollow.transform.position;
    //    changeInPosition = objFinalPosition - objStartPosition;
    //    transform.position += changeInPosition;
    //    objStartPosition = objTofollow.transform.position;
    //}

    //Below is better way

    public GameObject objToFollow;
    Vector3 offset;
    public bool gameOver;
    public static CameraFollow instance;
    

    private void Start()
    {
        offset = objToFollow.transform.position - transform.position;
        gameOver = false;
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (!gameOver)
        {
            transform.position = objToFollow.transform.position - offset;
        }
    }



}
