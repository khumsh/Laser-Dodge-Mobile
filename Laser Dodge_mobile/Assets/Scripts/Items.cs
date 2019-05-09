using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {
	public Player player;
	public GameManager gameManager;
	public Animator anim;

	public float BeforeSpeed = 4f;
	public float AfterSpeed = 6f;


	void Start(){
		player = FindObjectOfType<Player>();
		gameManager = FindObjectOfType<GameManager>();
		anim = GetComponent<Animator>();

		// Invoke("Blink", 8);
		Destroy(gameObject, 10f);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player" && this.tag == "Small Item"){
			gameManager.isSmall = true;
			other.transform.localScale = new Vector3(gameManager.playerSmallScale, gameManager.playerSmallScale, 0);

			if(gameManager.isSmall){
				gameManager.itemTime = 15f;
				this.gameObject.SetActive(false);
			}else{
				Debug.Log("Get Small Item");
				gameManager.isSmall = true;
				this.gameObject.SetActive(false);
				gameManager.itemTime = 15f;
				other.transform.localScale = new Vector3(gameManager.playerSmallScale, gameManager.playerSmallScale, 0);
			}

			if(gameManager.isFast){
				gameManager.isFast = false;
				Player.speed = BeforeSpeed;
			}
			gameManager.isEaten = true;

		}

		if(other.tag == "Player" && this.tag == "Speed Item"){
			gameManager.isFast = true;
			Player.speed = AfterSpeed;

			if(gameManager.isFast){
				gameManager.itemTime = 15f;
				this.gameObject.SetActive(false);
			}else{
				Debug.Log("Get Speed Item");
				gameManager.isFast = true;
				this.gameObject.SetActive(false);
				gameManager.itemTime = 15f;
				Player.speed = BeforeSpeed;
			}

			if(gameManager.isSmall){
				gameManager.isSmall = false;
				player.transform.localScale = new Vector3(gameManager.playerBigScale, gameManager.playerBigScale, 0);
			}

			gameManager.isEaten = true;
		}
	}

	public void GetBigger(){
		player.transform.localScale = new Vector3(gameManager.playerBigScale, gameManager.playerBigScale, 0);
		gameManager.isSmall = false;
	}

	public void GetSlow(){
		Player.speed -= 3f;
		gameManager.isFast = false;
	}

/*
	private void Blink(){	
		if(!gameManager.isEaten)
		anim.SetTrigger("Blink");
	}
*/
}
