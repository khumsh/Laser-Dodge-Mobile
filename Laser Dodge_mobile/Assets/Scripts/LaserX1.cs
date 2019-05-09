using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserX1 : MonoBehaviour {

	public float speed = 3f; 
	public Rigidbody2D rig2d;
	public Animator anim;
	public BoxCollider2D boxcol2d;
	bool moveRight = true; 
	float startPos = -2.5f; 
	float endPos = 2.5f;
	float count; // 레이저 쏘고난 후 ++; 이거 올라갈수록 스피드레인지랑 레이저가 멈추고 쏘는 시간간격 감소
	public bool moving;
	public static bool triggerXOn;
	public static int nowScore;

	private float startXTime;
	private float btwXTime;
	private float countA;

	public Player player;

	void Start () {
		nowScore = 0;

		triggerXOn = false;

		SetSpeed();

		rig2d = GetComponent<Rigidbody2D>();

		anim = GetComponent<Animator>();

		boxcol2d = GetComponent<BoxCollider2D>();

		startXTime = Random.Range(3f, 5f);

		StartCoroutine("LaserOn", startXTime);

		moving = false;

		player = FindObjectOfType<Player>();

	}
	

	void Update () {
		if(moving){
			Move();
		}
		

		// 시간간격보고 레이저 쏘기
	}

	void Move(){
		// 레이저 움직이게 하는 함수

		if(transform.position.x > player.transform.position.x)   // 끝 포인트에 도달하면 반대로 이동
		{
			moveRight = false;
		}
		if(transform.position.x < player.transform.position.x)
		{
			moveRight = true;
		}

		if(moveRight){
			transform.Translate(Vector2.right * speed * Time.deltaTime);	
		}
		if(!moveRight){
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
	
		
	}
	void SetSpeed(){
		// 랜덤으로 스피드를 설정한다.
		// count가 올라갈수록 더 높은 레인지에서 스피드 랜덤설정 (나중에 추가)
		
		speed = Random.Range(1 + 0.5f * count, 3 + 0.5f * count); // 랜덤으로 스피드 설정

		if(count > 4){
			speed = Random.Range(3f, 5f); // 스피드 고정
		}
	}

	IEnumerator LaserOn(float delay){
		//레이저 쏘는 함수 (멈추고 쏘기 + 애니메이션 추가 + 레이저 쏘고난 후 count ++)
		yield return new WaitForSeconds(delay);

		SetMoving(); // 움직임을 멈춘다

		btwXTime = Random.Range(0.5f, 1f);

		if(speed >= 10){
			btwXTime = Random.Range(0.4f, 0.6f);
			
			if(nowScore > 15){
				btwXTime = Random.Range(0.3f, 0.5f);
			}
		}

		Debug.Log("X : " + btwXTime);

		yield return new WaitForSeconds(btwXTime); // btwTIme초 뒤

		anim.SetTrigger("LaserOn"); // 애니메이션 재생

		count++;

		SetSpeed();
	}

	void SetMoving(){
		moving = !moving;
	}

	void SetTriggerOn(){
		triggerXOn = !triggerXOn;
	}

	void ScoreUp(){
		nowScore++;
	}
	void MoveStart(){
		anim.SetTrigger("Move");
		moving = true;
	}

}
