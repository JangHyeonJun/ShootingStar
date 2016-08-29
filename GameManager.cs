using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    static public GameManager Manager;
    StageManager stageMng;
    TitleColor titlecolor;

    public GameObject UI, PlayUI, TitleUI;
    public GameObject stage0;

    public Text MaxScoreText;
    public int HighScore = 0;
    public int Score = 0;

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
        Instantiate(stage0, stage0.transform.position, Quaternion.identity);
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
