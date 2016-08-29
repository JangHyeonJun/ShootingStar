// UI로 취급하는놈의 z좌표를 -10 배경을 10으로함

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;


public class Arrow_Control : MonoBehaviour
{
    
    Vector3 curTouch; // (스크린좌표) 현재 터치좌표
    Vector3 init_worldPos, worldPos, relative_worldPos; // (월드좌표) 첫, 현재, 현재-첫 
    float angle; //화살표의 방향
    public float power;
    public float buf;

    public Transform firePoint;
    public GameObject shootingStar;
    public GameObject arrowHead, arrowBody;
    public GameObject emissionParticle;
    public GameObject finalchance;
    public Text txt;

    AudioSource audio;
    public List<AudioClip> sounds;
    EnergyBar engCtrl;


    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        arrowHead.SetActive(false);
        arrowBody.SetActive(false);
        engCtrl = GameObject.Find("Energy").GetComponent<EnergyBar>();
    }


    // Update is called once per frame
    void Update()
    {
        txt.text = engCtrl.CurEng +"  "+ buf;
        if (Input.touchCount > 0)
        {
            

            curTouch = Input.touches[0].position;
            worldPos = Camera.main.ScreenToWorldPoint(curTouch);
            // 터치 단계
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                buf = engCtrl.CurEng; // 현재체력 담아두는 임시변수
                init_worldPos = worldPos;
                audio.clip = sounds[0];
                audio.Play();
                audio.loop = true;
                emissionParticle.SetActive(true);
                
                
            }
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                relative_worldPos = worldPos - init_worldPos;

                

                // 화살표 머리 코드
                arrowHead.transform.position = new Vector3(firePoint.position.x - relative_worldPos.x * 2.0f, firePoint.position.y - relative_worldPos.y * 2.0f, -10);
                angle = Mathf.Atan2(-relative_worldPos.y, -relative_worldPos.x) * Mathf.Rad2Deg;
                arrowHead.transform.localRotation = Quaternion.Euler(0, 0, angle);

                // 화살표 몸통 코드
                arrowBody.GetComponent<LineRenderer>().SetPosition(0, new Vector3(firePoint.position.x, firePoint.position.y, -10));
                arrowBody.GetComponent<LineRenderer>().SetPosition(1, new Vector3(firePoint.position.x - relative_worldPos.x * 2.0f, firePoint.position.y - relative_worldPos.y * 2.0f, -10)); 

                arrowBody.SetActive(true);
                arrowHead.SetActive(true);

                // 에너지 게이지 코드
                if (engCtrl.CurEng >= 0)
                    power = relative_worldPos.magnitude * 2.0f + 1.5f;
                engCtrl.CurEng = buf - power;

                if (engCtrl.CurEng <= 0)
                    finalchance.SetActive(true);
                
            }
            if (Input.touches[0].phase == TouchPhase.Ended) // 터치 값 초기화
            {
                audio.clip = sounds[1];
                audio.loop = false;
                audio.Play();
                Instantiate(shootingStar, firePoint.position, arrowHead.transform.localRotation);
                arrowHead.SetActive(false);
                arrowBody.SetActive(false);
                emissionParticle.SetActive(false);
                finalchance.SetActive(false);
            }
        }
    }

}
