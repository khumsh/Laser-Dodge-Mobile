using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	public Player player;
	public GameObject gameoverText; // 게임 오버시 활성화할 게임오버 UI
	public Text scoreText; // 스코어를 표시할 텍스트 컴포넌트
	public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
	public int score; // 현재 스코어
	public bool isSmall; // 스몰 아이템을 먹었는가
	public bool isFast; // 스피드업 아이템을 먹었는가
	public GameObject getItemObject;
	public Text getItemText;
	public Text itemTimeText;
	public Items items;
	public bool isEaten;
	public Text overScoreText;


	public bool isGameover; // 현재 게임 오버 상태를 표현
	public float itemTime;
	public bool itemReset;

	public float playerBigScale = 4.5f;
	public float playerSmallScale = 3f;


	void Start(){

		// 초기화
		LaserX1.nowScore = 0;
		LaserY1.nowScore = 0;
		score = 0;
		isGameover = false;
		itemTime = 15f;

		int bestTime = PlayerPrefs.GetInt("BestTime");

		recordText.text = "Best Score : " + bestTime;

		player = FindObjectOfType<Player>();

		items = GetComponent<Items>();

		isEaten = false;
		
		itemReset = false;

		Time.timeScale = 1;

	}

	void Update(){
		// 게임 오버가 아닌 동안
		if(!isGameover) {
			// 생존 시간을 갱신


			score = LaserY.nowScore + LaserX.nowScore + LaserY1.nowScore + LaserX1.nowScore;
			// 갱신한 스코어를 텍스트 컴포넌트를 통해 표시
			scoreText.text = "Score : " + score;

		}
		else{

			// 게임 오버 상태에서 키보드 R키를 누르면 게임 재시작
			if (Input.GetKeyDown(KeyCode.R)){
				// Main 씬을 로드
				// 이전 씬은 파괴됨
				SceneManager.LoadScene("Main");
			}
		}

		if(isSmall && !isFast){
			itemTime -= Time.deltaTime;
			getItemObject.gameObject.SetActive(true);
			getItemText.text = "크기가 작아졌습니다!";
			itemTimeText.text = "( 지속시간 : " + (int)itemTime + ")";

			if(itemTime < 0 || itemReset){
				player.transform.localScale = new Vector3(playerBigScale, playerBigScale, 0);
				getItemObject.gameObject.SetActive(false);
				itemTime = 15f;
				itemReset = false;

				
				isSmall = false;

				isEaten = false;

				
			}
		}

		if(isFast && !isSmall){
			itemTime -= Time.deltaTime;
			getItemObject.gameObject.SetActive(true);
			getItemText.text = "속도가 빨라졌습니다!";
			itemTimeText.text = "( 지속시간 : " + (int)itemTime + ")";

			if(itemTime < 0 || itemReset){
				Player.speed = 4f;
				getItemObject.gameObject.SetActive(false);
				itemTime = 15f;
				itemReset = false;

				
				isFast = false;

				isEaten = false;

				
			}
		}

	}
	// 게임 오버 상태로 현재 상태를 변경하는 처리
	public void EndGame(){
		// 현재 상태를 게임 오버 상태
		isGameover = true;
		// 게임 오버 UI를 활성화
		gameoverText.SetActive(true);
		scoreText.text = null;

		// 이전까지의 최고 기록이 BestTime이라는 키로 저장되어 있다면 가져오기
		int bestTime = PlayerPrefs.GetInt("BestTime");

		// 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
		if(bestTime < score){
			// 최고 기록 갱신
			bestTime = score;
			// 변경된 최고 기록 값을 BestTime 이라는 키로 저장
			PlayerPrefs.SetInt("BestTime", bestTime);
		}

		// 최고 기록을 recordText 텍스트 컴포넌트를 통해 표시
		recordText.text = "Best Score : " + bestTime;
		overScoreText.text = "Score : " + score;

		LaserX1.nowScore = 0;
		LaserY1.nowScore = 0;
	}

}
