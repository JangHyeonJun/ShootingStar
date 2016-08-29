﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    static public GameManager Manager;
    StageManager stageMng;
    TitleColor titlecolor;

    public GameObject UI, PlayUI, TitleUI, GameOverUI;
    public GameObject stage0;

    public Text MaxScoreText;
    public int HighScore = 0;
    public int Score = 0;
    public bool gameover = false;

    void Awake()
    {
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        titlecolor = GameObject.Find("Title").GetComponent<TitleColor>();
    }
    void Update()
    {
        MaxScoreText.text = Score.ToString() + " KM";
    }


    IEnumerator startGame()
    {
        titlecolor.gameStart = true;
        yield return new WaitForSeconds(2.0f);
        TitleUI.SetActive(false);
        PlayUI.SetActive(true);
        titlecolor.gameStart = false;
        gameover = false;
        Instantiate(stage0, stage0.transform.position, Quaternion.identity);
    }

    public void GameOver()
    {
        gameover = true;
        PlayUI.SetActive(false);
        GameOverUI.SetActive(true);
    }
    public void goTitle()
    {
        GameOverUI.SetActive(false);
        TitleUI.SetActive(true);
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }


}
