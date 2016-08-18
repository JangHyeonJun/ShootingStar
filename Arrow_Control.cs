﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class Arrow_Control : MonoBehaviour
{
    public Vector3 curTouch; // 첫터치와 현재터치좌표
    public Vector3 init_worldPos, worldPos; // 터치의 월드좌표
    public float angle; //화살표의 방향

    public GameObject shootingStar;
    public GameObject arrowHead, arrowBody;
    public Text txt;


    // Use this for initialization
    void Start()
    {
        arrowHead.SetActive(false);
        arrowBody.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            curTouch = Input.touches[0].position;
            worldPos = Camera.main.ScreenToWorldPoint(curTouch);
            txt.text = worldPos.ToString();

            

            
            // 터치 단계
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                init_worldPos = worldPos;       
            }
            if (Input.touches[0].phase == TouchPhase.Moved)
            {

                // 화살표 머리 코드
                arrowHead.transform.position = new Vector3(worldPos.x, worldPos.y, -10);
                angle = Mathf.Atan2(worldPos.y - init_worldPos.y, worldPos.x - init_worldPos.x) * Mathf.Rad2Deg;
                arrowHead.transform.localRotation = Quaternion.Euler(0, 0, angle);

                // 화살표 몸통 코드
                arrowBody.GetComponent<LineRenderer>().SetPosition(0, new Vector3(init_worldPos.x, init_worldPos.y, -10));
                arrowBody.GetComponent<LineRenderer>().SetPosition(1, new Vector3(worldPos.x, worldPos.y, -10)); // UI로 취급하는놈의 z좌표를 -10 배경을 10으로함

                arrowBody.SetActive(true);
                arrowHead.SetActive(true);
            }
            if (Input.touches[0].phase == TouchPhase.Ended) // 터치 값 초기화
            {
                Instantiate(shootingStar, init_worldPos, arrowHead.transform.localRotation);

                arrowHead.SetActive(false);
                arrowBody.SetActive(false);
            }
        }
    }

}
