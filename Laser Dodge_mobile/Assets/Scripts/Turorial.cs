using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turorial : MonoBehaviour {
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		Invoke("Bye", 5f);
	}

	void SetOff(){
		gameObject.SetActive(false);
	}

	void Bye(){
		anim.SetTrigger("Bye");
	}

}
