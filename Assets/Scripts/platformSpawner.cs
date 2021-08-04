using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    //public GameObject platform;
    //public GameObject startingPlatformTile;
    //Vector3 spawnPosition;
    //Vector3[] additionArray = { new Vector3(0,0,2), new Vector3(2, 0,0) };
    //bool coroutineAllowed = true;
    //public Vector3 addition;
    //// Start is called before the first frame update

    //private void Awake()
    //{

    //}
    //void Start()
    //{
    //    addition = additionArray[Random.Range(0, 2)];
    //   spawnPosition = startingPlatformTile.transform.position + addition;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (coroutineAllowed)
    //    {
    //        StartCoroutine("Spawn");
    //    }
    //}



    //IEnumerator Spawn()
    //{
    //    coroutineAllowed = false;
    //    yield return new WaitForEndOfFrame();
    //    GameObject gameObject = Instantiate(platform, spawnPosition, Quaternion.identity);
    //    addition = additionArray[Random.Range(0, 2)];
    //    spawnPosition = gameObject.transform.position + addition;
    //    yield return new WaitForSeconds(1f);
    //    coroutineAllowed = true;

    //}

    //BELOW IS TEACHER CODE

    Vector3 lastPos;
    float size;
    public GameObject platform;
    public GameObject diamond;
    public static platformSpawner instance;
    public bool gameOver = false;
    public GameObject player;
    public float diamondYOffset;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        for( int i = 0; i<40; i++)
        {
            SpawnPlatform();
        }
        Time.timeScale = 0f;
        InvokeRepeating("SpawnPlatform", 2f,0.2f);
        
    }

    private void Update()
    {
        if (gameOver)
        {
            CancelInvoke("SpawnPlatform");
        }
    }

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnX();
        }
        else if(rand >=3)
        {
            SpawnZ();
        }

        if(rand == 3)
        {
            print("REACHED");
            SpawnDiamond();
        }
    }



    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        GameObject gameObject = Instantiate(platform, pos, Quaternion.identity);
        lastPos = gameObject.transform.position;
        
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        GameObject gameObject = Instantiate(platform, pos, Quaternion.identity);
        lastPos = gameObject.transform.position;
    }

    void SpawnDiamond()
    {
        Vector3 pos = lastPos;
        pos.y = platform.transform.position.y + diamondYOffset;
        GameObject gameObject = Instantiate(diamond, pos,diamond.transform.rotation);
        
    }


}
