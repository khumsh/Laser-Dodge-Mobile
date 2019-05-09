using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTest : MonoBehaviour {
	//이 클래스 사용
    public Transform player;
	public Player playerClass;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;

	public float speed;
    public GameObject pauseUI;

	void Start()
	{
		playerClass = FindObjectOfType<Player>();
	}

	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0) && !playerClass.isDead && !pauseUI.activeSelf){

			// 클릭시 마우스의 위치가 pointA라는 벡터로 지정
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA;
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;

        }
        if(Input.GetMouseButton(0)){

			//마우스의 움직임을 pointB라는 벡터로 항시 지정(계속 변함)
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

		}else{
            touchStart = false;
        }

		
        
		
	}
	private void FixedUpdate(){
        if(touchStart){
            Vector2 offset = pointB - pointA; // B벡터에서 A벡터를 뺀 값이 플레이어가 이동할 방향
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction);


            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }else{
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

	}
	void moveCharacter(Vector2 direction){
		
        player.Translate(direction * Player.speed * Time.deltaTime);
    }

}