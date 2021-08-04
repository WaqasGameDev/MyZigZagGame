using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int score = 0;
    Scene scene;
    public GameObject yourScorePanel;
    public int speedLimit = 0;
    public static GameManager instance;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        if(instance == null)
        {
            instance = this;
        }
        scene = SceneManager.GetActiveScene();
        UIManager.instance.ZigZagBestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore", 0).ToString();
        UIManager.instance.bestScoreInt.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.instance.yourScoreInt.text = score.ToString();
        if (score >= PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        UIManager.instance.bestScoreInt.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        if(score > speedLimit)
        {
            ballController.instance.speed += 1;
            speedLimit += 50;
        }
    }

    public void StartScore()
    {
        InvokeRepeating("IncreaseScore", 0.1f, 0.3f);
    }

    public void StopScore()
    {
        CancelInvoke("IncreaseScore");
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
