using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Rigidbody2D playerRb;
	public bool isDead;
	public static float speed = 4f;
	public JoyStick joystick;

	public JoystickTest joystickTest;
	// Use this for initialization
	void Start () {
		playerRb = GetComponent<Rigidbody2D>();
		isDead = false;	
	}
	
/*
	void Update () {
		//float xInput = Input.GetAxis("Horizontal");
		//float yInput = Input.GetAxis("Vertical");

		float xInput = joystick.Horizontal();
		float yInput = joystick.Vertical();
		// 실제 이동할 속도를 입력값과 입력 속도를 통해 결정
		float xSpeed = xInput * speed;
		float ySpeed = yInput * speed;
		
		//새로운 Vector3 속도 생성
		Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
		// Rigidbody의 속도를 새로운 속도로 덮어쓰기
		playerRb.velocity = newVelocity;




	}
	*/

	void OnTriggerStay2D(Collider2D other){
		if(other.tag == "LaserX" && LaserX.triggerXOn){
			Debug.Log("Die by X");
			Die();
		}

		if(other.tag == "LaserY" && LaserY.triggerYOn){
			Debug.Log("Die by Y");
			Die();
		}

		if(other.tag == "LaserX1" && LaserX1.triggerXOn){
			Die();
		}

		if(other.tag == "LaserY1" && LaserY1.triggerYOn){
			Die();
		}
	}

	public void Die(){
		// Player Character 게임 오브젝트를 비활성화
		gameObject.SetActive(false);
		// 게임 매니저를 찾아내서, 게임 매니저의 EndGame 실행
		FindObjectOfType<GameManager>().EndGame();
		isDead = true;
	}

}
