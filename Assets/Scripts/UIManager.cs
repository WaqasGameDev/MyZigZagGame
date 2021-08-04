using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject tapToPlayText;
    public GameObject ZigZagObj;
    public Text BestScore;
    public Text ZigZagBestScore;
    public GameObject GameOverPanel;
    public Text BottomYourScoreText;
    public bool gameStarted = false;
    Animator zigzagAnimator;
    public Text yourScoreInt;
    public Text bestScoreInt;
    public static UIManager instance;
    private void Awake()
    {
        zigzagAnimator = ZigZagObj.GetComponent<Animator>();
        if (instance == null)
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if(Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Time.timeScale = 1f;
                    gameStarted = true;
                    GameManager.instance.StartScore();
                    tapToPlayText.SetActive(false);
                    zigzagAnimator.enabled = true;
                    GameManager.instance.yourScorePanel.SetActive(true);
                    Destroy(ZigZagObj, 1f);
                }
            }
        }

        
    }
}
