using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EasterEgg : MonoBehaviour {

	public Text easterEgg;
	private int count;
	private int touchCount;

	void Start(){
		count = 0;
		touchCount = 0;
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.M) && count == 0){
			easterEgg.gameObject.SetActive(true);
			count++;
		}

		if(Input.GetKeyDown(KeyCode.S) && count == 1){
			easterEgg.text = "<color=#0000ff>" + "경희대학교 소프트웨어융합학과 문석호" + "</color>";
			//easterEgg.gameObject.SetActive(false);
			count++;


		}

		if(Input.GetKeyDown(KeyCode.H) && count == 2){
			SceneManager.LoadScene("EasterEgg");
		}
	}

	public void OnClick(){
		SceneManager.LoadScene("Intro");
	}

	public void EasterEggTouch(){
		touchCount++;
		if(touchCount >= 5){
			SceneManager.LoadScene("EasterEgg");
		}
	}
}
