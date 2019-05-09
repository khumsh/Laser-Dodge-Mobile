using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	private bool pauseOn = false;
	private bool muteOn = false;
	public GameObject pauseUI;
	public Text muteText;

	private void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			pauseUI.SetActive(!pauseOn);
			PauseButton();

		}
	}

	public void OnClick(){

		SceneManager.LoadScene("Main");

	}

	public void Quit(){
		Application.Quit();
	}

	public void MainMenu(){
		SceneManager.LoadScene("Intro");
		PauseButton();
	}

	public void PauseButton(){
		if(!pauseOn){
			Time.timeScale = 0;
		}else if(pauseOn){
			Time.timeScale = 1;
		}

		pauseOn = !pauseOn;
	}

	public void Restart(){
		SceneManager.LoadScene("Main");
		PauseButton();
	}

	public void Mute(){
		AudioListener.pause = !AudioListener.pause;
		muteOn = !muteOn;
		if(muteOn){
			muteText.text = "MUTE OFF";
		}else if(!muteOn){
			muteText.text = "MUTE ON";
		}
	}

}
