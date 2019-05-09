using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
	public GameObject item1, item2;
	public Player player;

	private int whatToSpawn;
	private float spawnRate = 16; // 아이템 생성 주기
	private float nextSpawn = 10; // 처음 아이템이 나올 시간
	private float xMin = -2.2f;
	private float xMax = 2.2f;
	private float yMin = -2.3f;
	private float yMax = 2.3f;
	private float nowTime;

	void Start(){
		player = FindObjectOfType<Player>();
		nowTime = 0;
	}

	void Update () {
		nowTime += Time.deltaTime;
		if(nowTime > nextSpawn){
			whatToSpawn = Random.Range(1, 3);
			float xRange = Random.Range(xMin, xMax);
			float yRange = Random.Range(yMin, yMax);
            Vector3 range = new Vector3(xRange, yRange, 1);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(item1, range, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(item2, range, Quaternion.identity);
                    break;
            }
            nextSpawn = nowTime + spawnRate;
		}
	}
}
