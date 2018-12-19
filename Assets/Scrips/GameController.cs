using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject floorPrefab;
    public GameObject coin;
    public float spawnTime = 0.8f;
    private float posY = 4.8f;
    private float Timer = 0;
    private float Timer2 = 0;
    public float spawnTime2 = 15f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime; // PRO
        Timer2 += Time.deltaTime;
   

        posY += (Time.deltaTime)*3f;
        if (Timer >= spawnTime)
        {
            Timer -= spawnTime;

            float num = Random.Range(0f,1.2f);
            float num2 = Random.Range(0f, 0.8f);
            float posX1 = Random.Range(-6f, 0f); // Aleatorio entre 2 num
            float posX2 = Random.Range(2f, 6f);

          

            Vector3 pos1 = new Vector3(posX1, posY + num);
            Instantiate(floorPrefab, pos1, Quaternion.identity);

            Vector3 pos2 = new Vector3(posX2, posY+num2);
            Instantiate(floorPrefab, pos2, Quaternion.identity);
        }

        if (Timer2 >= spawnTime2)
        {
            float num = Random.Range(1.8f, 2.2f);
            float posX1 = Random.Range(-6f, 6f); // Aleatorio entre 2 num
            Timer2 -= spawnTime2;
            Vector3 posCoin = new Vector3(posX1, posY + num);
            Instantiate(coin, posCoin, Quaternion.identity);
        }
    }
}
