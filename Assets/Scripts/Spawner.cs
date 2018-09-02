using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Fruits;
    public GameObject Bomb;
    public float spawnTimer = 1f;
    private bool isPlaying = true;
    private int tapZ = 0;
    private AudioClip lanughFruit;
    private AudioSource audioSource;
 
	void Start () {

        audioSource = GetComponent<AudioSource>();

    }
	
    
	
	void Update () {

        if (!isPlaying) {

            return;

        }



        spawnTimer -= Time.deltaTime;

          if (0 > spawnTimer) {

            int fruitCount = Random.Range(1, 4);

            for (int i = 0;i < fruitCount;i++)
            {
                onSpawn(true);
                
            }
               


               spawnTimer = 1f;

            if (Random.Range(0,100) > 90) {

                
                onSpawn(false);
            } 

          }    
        
		
	}


    private void onSpawn(bool isFruit) {

        float x = Random.Range(-8.4f, 8.4f);

        float y = transform.position.y;


        int fruitIndex = Random.Range(0,Fruits.Length);

        GameObject go;

        tapZ -= 2;

        if (tapZ < -10 ) {

            tapZ = 0;

        }

        if (isFruit)
        {

            go = Instantiate<GameObject>(Fruits[fruitIndex], new Vector3(x, y, tapZ), Quaternion.identity);

        }

        else {

            go = Instantiate<GameObject>(Bomb , new Vector3(x, y, tapZ), Quaternion.identity);

        }


        Vector3 vector = new Vector3(-x*Random.Range(0.4f,0.8f),-Physics.gravity.y*Random.Range(1.0f,1.45f),0);

        //Vector3 vector = new Vector3(-x * Random.Range(0.3f, 0.6f), -Physics.gravity.y*1.05f, 0);

        Rigidbody rigidbody = go.GetComponent<Rigidbody>();

        audioSource.Play();

        rigidbody.velocity = vector;

    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

}
