using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public Text ScoreText;
    public int Score = 0;

    void Update()
    {
        ScoreText.text = Score.ToString();
    }
}
