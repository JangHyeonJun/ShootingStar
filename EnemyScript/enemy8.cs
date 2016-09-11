using UnityEngine;
using System.Collections;

public class enemy8 : MonoBehaviour {

    EnergyBar eng;
    StageManager stageMng;
    GameManager mng;
    AudioSource audio;

    void Start()
    {
        eng = GameObject.Find("Energy").GetComponent<EnergyBar>();
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        audio = GetComponent<AudioSource>();

    }
    void Update()
    {
        if (mng.gameover)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShootingStar")
        {
            audio.Play();
            eng.CurEng -= 10;
        }
    }
}
