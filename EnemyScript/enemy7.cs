using UnityEngine;
using System.Collections;

public class enemy7 : MonoBehaviour {

    Color colorBuf;
    EnergyBar eng;
    StageManager stageMng;
    GameManager mng;
    AudioSource audio;

    public float timer = 2.0f;
    void Start()
    {
        eng = GameObject.Find("Energy").GetComponent<EnergyBar>();
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        audio = GetComponent<AudioSource>();
        StartCoroutine(active());
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
            eng.CurEng += 3;
            audio.Play();
            Destroy(gameObject, 0.1f);
            stageMng.StartCoroutine("checkEnemy");
        }
    }
    IEnumerator active()
    {
        GetComponent<Collider2D>().enabled = false;
        colorBuf = GetComponentInChildren<ParticleSystem>().startColor;
        GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(timer);
        GetComponent<Collider2D>().enabled = true;
        GetComponentInChildren<ParticleSystem>().startColor = colorBuf;
        yield return new WaitForSeconds(timer);
        yield return active();
    }
}
