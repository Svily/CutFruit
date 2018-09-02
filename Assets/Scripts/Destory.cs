using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour {

	
	void Start () {

        Invoke("dead",2f);

	}
	
	
	void dead () {

        Destroy(gameObject);

	}
}
