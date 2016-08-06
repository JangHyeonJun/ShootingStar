using UnityEngine;
using System.Collections;

public class Arrow_Control : MonoBehaviour
{

    float curPosX, curPosY;  // 터치 현재좌표
    public Vector3 screenPos; // 이 오브젝트가 스크린에선 어떤 좌표를 가지고있는지 담는 변수.
    public Vector3 worldPos; // 터치한 좌표가 월드에서는 어떤 좌표를 가지고있는지 담는 변수.
    public float angle; //화살표의 방향

    public GameObject shootingStar;
    public GameObject arrowHead, arrowBody;


    // Use this for initialization
    void Start()
    {

        arrowHead.SetActive(false);
        arrowBody.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {

        screenPos = Camera.main.WorldToScreenPoint(transform.position);


        // 터치
        if (Input.touches[0].phase == TouchPhase.Began)
        {
            arrowHead.SetActive(true);
            arrowBody.SetActive(true);
        }
        if (Input.touches[0].phase == TouchPhase.Moved)
        {
            worldPos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);


            // 화살표 머리 코드
            curPosX = Input.touches[0].position.x;
            curPosY = Input.touches[0].position.y;

            angle = Mathf.Atan2(curPosY - screenPos.y, curPosX - screenPos.x) * Mathf.Rad2Deg;
            arrowHead.transform.localRotation = Quaternion.Euler(0, 0, angle);

            arrowHead.transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);

            // 화살표 몸통 코드
            arrowBody.GetComponent<LineRenderer>().SetPosition(0, transform.position); //몸통 시작점
            arrowBody.GetComponent<LineRenderer>().SetPosition(1, worldPos);//몸통 끝점


        }
        if (Input.touches[0].phase == TouchPhase.Ended) // 터치 값 초기화
        {
            Instantiate(shootingStar, transform.position, arrowHead.transform.localRotation);

            curPosX = 0.0f;
            curPosY = 0.0f;

            arrowHead.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
            arrowHead.SetActive(false);
            arrowBody.SetActive(false);
        }
    }

}
