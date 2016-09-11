using UnityEngine;
using System.Collections;

public class enemy6 : MonoBehaviour
{
    public float speed = 3.0f;
    public float angle = 90.0f;
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
        transform.Translate(speed * Vector2.up * Time.deltaTime);
        transform.localEulerAngles += new Vector3(0, 0, angle * Time.deltaTime);

        if (mng.gameover)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShootingStar")
        {
            eng.CurEng += 5;
            audio.Play();
            Destroy(gameObject, 0.1f);

            if (GameObject.FindWithTag("Boss"))
            {
                eng.CurEng += 3;
                GameObject.FindWithTag("Boss").GetComponent<boss1>().hp -= 10;
            }
            else
                stageMng.StartCoroutine("checkEnemy");
        }
    }
}
