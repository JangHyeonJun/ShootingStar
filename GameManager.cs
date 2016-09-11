using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    StageManager stageMng;
    public EnergyBar eng;
    public Arrow_Control arrow_ctrl;
    TitleColor titlecolor;

    public GameObject star, clicksound;
    public GameObject UI, PlayUI, TitleUI, GameOverUI;
    public GameObject stage0;
    public GameObject newscore;

    public Text MaxScoreText, Score;
    public int HighScore = 0;
    public int HighStage = 0;
    public float energy;
    public bool gameover = false;

    void Awake()
    {
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        titlecolor = GameObject.Find("Title").GetComponent<TitleColor>();
    }
    void Update()
    {
        MaxScoreText.text = HighScore.ToString() + " KM";
    }


    IEnumerator startGame()
    {
        if (!titlecolor.gameStart)
        {
            titlecolor.gameStart = true;
            clicksound.SetActive(true);
            yield return new WaitForSeconds(2.0f);  // 타이틀 애니메이션 효과 2초 기다린 후 게임시작.

            titlecolor.gameStart = false;
            clicksound.SetActive(false);

            TitleUI.SetActive(false);
            PlayUI.SetActive(true);
            star.SetActive(true);

            gameover = false;
            eng.StartCoroutine("timeEng");
            eng.MaxEng = energy;
            eng.CurEng = energy;
            Instantiate(stage0, stage0.transform.position, Quaternion.identity);
        }
        else
            yield return null;
    }

    public void GameOver()
    {
        eng.StopCoroutine("timeEng");
        eng.CurEng = 10;
        if (eng.score > HighScore)
        {
            newscore.SetActive(true);
            HighScore = eng.score;
        }
        Score.text = eng.score.ToString();
        energy = 100 + ((HighScore / 1000) * 10);
        if (energy >= 200)
            energy = 200;
        eng.score = 0;
        gameover = true;
        HighStage = stageMng.currentStage;
        stageMng.currentStage = 0;
        PlayUI.SetActive(false);
        star.SetActive(false);
        GameOverUI.SetActive(true);
    }
    public void goTitle()
    {
        newscore.SetActive(false);
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
