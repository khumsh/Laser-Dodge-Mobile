using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour {

	// 레이저를 일정 스코어 이상? 아니면 일정 시간 이상? 지나면 
	// X,y중에 랜덤으로 레이저를 하나씩 생성한다.
	// 난이도 조정


	public GameObject laserX, laserY;

	private int whatToSpawn;
	private float spawnRate = 20; // 레이저 생성 주기
	private float nextSpawn = 20; // 처음 레이저가 나올 시간
	private float xMin = -2.5f;
	private float xMax = 2.5f;
	private float yMin = -2.5f;
	private float yMax = 2.5f;
	private float nowTime;
	private int count;

	void Start(){
		nowTime = 0;
	}

	void Update () {
		nowTime += Time.deltaTime;
		if(nowTime > nextSpawn && count < 2){
			
			if(count == 0){
				whatToSpawn = Random.Range(1, 3); //  1 or 2
			} else if(count < 2 && whatToSpawn == 1){
				whatToSpawn = 2;
			} else if(count < 2 && whatToSpawn == 2){
				whatToSpawn = 1;
			}

			float xRange = Random.Range(xMin, xMax);
			float yRange = Random.Range(yMin, yMax);
            Vector3 range1 = new Vector3(xRange, 0, 1);
			Vector3 range2 = new Vector3(0, yRange, 1);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(laserX, range1, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(laserY, range2, Quaternion.identity);
                    break;
            }
            nextSpawn = nowTime + spawnRate;
			count++;

			Debug.Log("what : " + whatToSpawn);
		}
	}



}
