﻿using UnityEngine;
using System.Collections;

public class enemy4 : MonoBehaviour
{

    EnergyBar eng;
    StageManager stageMng;
    GameManager mng;
    AudioSource audio;
    public int phase;
    public float timer;
    void Start()
    {
        eng = GameObject.Find("Energy").GetComponent<EnergyBar>();
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        audio = GetComponent<AudioSource>();
        phase = 0;
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;

        switch (phase)
        {
            case 0:
                transform.Translate(2.0f * new Vector2(-1, 1) * Time.deltaTime);
                if (timer >= 2.0f)
                {
                    phase = 1;
                    timer = 0;
                }
                break;

            case 1:
                transform.Translate(4.0f * new Vector2(1, -1) * Time.deltaTime);
                if (timer >= 1.0f)
                {
                    phase = 0;
                    timer = 0;
                }
                break;

            default:
                break;
        }

        if (mng.gameover)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShootingStar")
        {
            eng.CurEng += 3;
            audio.Play();
            Destroy(gameObject, 0.1f);
            stageMng.StartCoroutine("checkEnemy");
        }
    }
}
