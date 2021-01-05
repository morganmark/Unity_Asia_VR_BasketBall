using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("ScoreUI")]
    public Text scoreText;
    [Header("Score")]
    public int scoreNumber;
    [Header("當下投分")]
    public int scoreInt=2;
    [Header("進球音效")]
    public AudioClip soundin;
    private AudioSource aud;
    private void Awake()
    {
        aud = GetComponent<AudioSource>();//抓取元件

    }

    private void OnTriggerEnter(Collider other)//進入碰撞範圍
    {
        //球進入籃框
        if (other.tag=="BaseketBall")
        {
            //print(other.name);
            AddScore();
        }

        //判定Player在3分區
        if (other.transform.root.name=="Player")
        {
            print("InSide");
            scoreInt = 3;
        }
    }
    private void OnTriggerExit(Collider other)//離開碰撞範圍
    {
        if (other.transform.root.name == "Player")
        {
            print("OutSide");
            scoreInt = 2;
        }
    }
    private void AddScore()
    {
        scoreNumber += scoreInt;
        scoreText.text = "分數:"+scoreNumber;
        aud.PlayOneShot(soundin, 1.0f);//播放音效一次(音檔, 聲音大小)
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
