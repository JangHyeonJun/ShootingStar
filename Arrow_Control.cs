using UnityEngine;
using System.Collections;

public class Arrow_Control : MonoBehaviour {

    float prePosX, curPosX, movPosX; // 터치시작위치, 현재위치, 시작-현재위치
    float prePosY, curPosY;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {


        // X좌표의 터치와 드래그를 인식하는 코드.
        if (Input.touches[0].phase == TouchPhase.Began)
        {
            prePosX = Input.touches[0].position.x;
            prePosY = Input.touches[0].position.y;
        }
        if (Input.touches[0].phase == TouchPhase.Moved)
        {
            curPosX = Input.touches[0].position.x;
            if (curPosX > prePosX)
                movPosX = curPosX - prePosX;

            curPosY = Input.touches[0].position.y;

            float angle = Mathf.Atan2(curPosY - 670.0f, curPosX - 550.0f) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        if (Input.touches[0].phase == TouchPhase.Ended) // 터치 값 초기화
        {
            prePosX = 0.0f;
            curPosX = 0.0f;
            movPosX = 0.0f;

            prePosY = 0.0f;
            curPosY = 0.0f;


            GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
        }
        // 좌,우로 드래그 한만큼 화살표의 scale의 X가 바뀌고 상,하로 드래그 한만큼 화살표의 rotation의 Z가 바뀐다.
        GetComponent<Transform>().localScale = new Vector3(1.0f + (movPosX * 4.0f / Screen.width), 1, 1);
       


        




    }
}
