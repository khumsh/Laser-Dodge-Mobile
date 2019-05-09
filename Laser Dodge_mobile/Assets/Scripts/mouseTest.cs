using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseTest : MonoBehaviour {

	public GameObject joystick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			joystick.transform.position = Input.mousePosition;
		}
	}
}
