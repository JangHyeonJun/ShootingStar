// UI로 취급하는놈의 z좌표를 -10 배경을 10으로함

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class Arrow_Control : MonoBehaviour
{

    Vector3 curTouch; // (스크린좌표) 현재 터치좌표
    Vector3 init_worldPos, worldPos, relative_worldPos; // (월드좌표) 첫, 현재, 현재-첫 
    float angle; //화살표의 방향
    public float power;

    public Transform firePoint;
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
            
            txt.text = relative_worldPos.magnitude.ToString();

            

            
            // 터치 단계
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                init_worldPos = worldPos;       
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
            }
            if (Input.touches[0].phase == TouchPhase.Ended) // 터치 값 초기화
            {
                power = relative_worldPos.magnitude * 2.0f;

                Instantiate(shootingStar, firePoint.position, arrowHead.transform.localRotation);
                arrowHead.SetActive(false);
                arrowBody.SetActive(false);
            }
        }
    }

}
