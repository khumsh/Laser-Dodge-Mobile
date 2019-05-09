using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEffect : MonoBehaviour {
	public Animator anim;
	public GameManager gameManager;
	void Start(){
		anim = GetComponent<Animator>();
		gameManager = GetComponent<GameManager>();
	}

	void Update(){
	}

	void AnimationEnd(){
		gameObject.SetActive(false);
	}


}
