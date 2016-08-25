using UnityEngine;
using System.Collections;

public class enemy3 : MonoBehaviour {

    StageManager stageMng;
    GameManager mng;
    AudioSource audio;
    public int phase;
    public float timer;
    void Start()
    {
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
                transform.Translate(2.0f * Vector2.down * Time.deltaTime);
                if (timer >= 2.0f)
                {
                    phase = 1;
                    timer = 0;
                }
                break;

            case 1:
                transform.Translate(4.0f * Vector2.down * Time.deltaTime);
                if (timer >= 1.0f)
                {
                    phase = 2;
                    timer = 0;
                }
                break;

            case 2:
                transform.Translate(2.0f * Vector2.up * Time.deltaTime);
                if (timer >= 2.0f)
                {
                    phase = 3;
                    timer = 0;
                }
                break;

            case 3:
                transform.Translate(4.0f * Vector2.up * Time.deltaTime);
                if (timer >= 1.0f)
                {
                    phase = 0;
                    timer = 0;
                }
                break;

            default:
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShootingStar")
        {
            mng.Score += 300;
        }
        audio.Play();
        Destroy(gameObject, 0.1f);
        stageMng.StartCoroutine("checkEnemy");
    }
}
