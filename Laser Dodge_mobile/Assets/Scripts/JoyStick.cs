using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
//조이스틱 연습용 클래스
//사용하지 않음
	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;
	private Vector3 oriPos;


	private void Start(){
		bgImg = GetComponent<Image>();
		joystickImg = transform.GetChild(0).GetComponent<Image>();

		oriPos = bgImg.transform.position;
		Debug.Log(oriPos);
	}

	private void Update(){
		if(Input.GetMouseButtonDown(0)){
			gameObject.transform.position = Input.mousePosition;
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag(ped);
	}

	public virtual void OnPointerUp(PointerEventData ped){
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
		//bgImg.transform.position = oriPos;

	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)){
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector3(pos.x*2, 0, pos.y*2);
			inputVector = (inputVector.magnitude > 1.0f)?inputVector.normalized:inputVector;


			joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x/3), inputVector.z * (bgImg.rectTransform.sizeDelta.y/3));
		}

	}

	public float Horizontal(){
		if(inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis("Horizontal");
		
	}

	public float Vertical(){
		if(inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis("Vertical");
	}

}
