using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	public Camera mainGameCamera;           // 터치할때 화면을 보여줄 카메라
	public LineRenderer LR;                 // 라인렌더 선언
	public Vector3 TouchPOS;                // 터치 포지션
	public Vector3 DregPOS;                 // 드래그 포지션
	// Update is called once per frame


	void Start()
	{
		LR = this.gameObject.GetComponent<LineRenderer> ();                 // 라인렌더러를 선언함.
		LR.material = new Material (Shader.Find("Transparent/Diffuse"));    // 라인랜더링시 사용할 매터리얼.
		LR.material.color = Color.red;                                      // 라인 색
		LR.enabled = false;                                                 // 처음에는 안보이게 합니다.
		LR.SetWidth (0.1f, 0.1f);                                           // 라인의 두께
	}
	void Update () {
	/// PC로 작업하기 때문에 일단 GetTouch가 아닌 마우스로 컨트롤 하는 방법으로 알려 드리겠습니다.

		if (Input.GetMouseButtonDown(0)) {                                  // 최초 터치시
			TouchPOS 	= Input.mousePosition;                              // 터치 위치를 터치 포지션에 저장합니다.
			TouchPOS 	= mainGameCamera.ScreenToWorldPoint(TouchPOS);      // 화면상 터치 포지션을 3d좌표로 옮깁니다.
			LR.enabled 	= true;                                             // 그리고 라인랜더러가 보이도록 합니다.
		}

		if (Input.mousePosition != TouchPOS && LR.enabled) {                // 터치 후 드래그가 발생되면
			DregPOS 	= Input.mousePosition;                              // 드래그 되고 있는 위치를 드래그 포지션에 저장합니다.
			DregPOS 	= mainGameCamera.ScreenToWorldPoint(DregPOS);       // 스크린 좌표의 드래그 포지션을 월드 좌표로 옮깁니다.

            // 여기까지의 좌표로 그냥 라인을 그리면 카메라에 보이질 않습니다.(카메라 좌표 위치와 같기 때문에...)
			TouchPOS.y = 0.2f;                                              // 그래서 각각의 포지션의 높이를 적당히 잡아줍니다.
			DregPOS.y = 0.2f;

			LR.SetPosition(0, TouchPOS);                                    // 라인렌더 포지션을 셋팅하는데 index 0은 시작입니다.
			LR.SetPosition(1, DregPOS);                                     // index 0이상은 해당 인덱스 -1 에서 부터의 연결 지점입니다.(여기서는 끝이 됩니다.)
		}

		if (Input.GetMouseButtonUp(0)) {                                    // 터치가 끝날 경우
			LR.enabled = false;                                             // 라인을 보이지 않도록 합니다.
		}
	}
}
