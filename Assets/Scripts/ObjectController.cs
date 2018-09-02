using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    public AudioClip cutSound;

    public GameObject halfFurit;

    public GameObject splash;

    public GameObject splashFlat;



   

    public void OnCut() {

        

        if (gameObject.name.Contains("Bomb")) {

            GameUI.Instance.removeScore(20);

            Instantiate<GameObject>(splash, transform.position, Quaternion.identity);

        } else {

            GameUI.Instance.addScore(10);

            for (int i = 0; i < 2; i++)
            {
                

                GameObject go = Instantiate<GameObject>(halfFurit, transform.position, Random.rotation);

                go.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 5f, ForceMode.Impulse);
            }

            Instantiate<GameObject>(splash, transform.position, Quaternion.identity);
            Instantiate<GameObject>(splashFlat, transform.position, Quaternion.identity);
        }

        AudioSource.PlayClipAtPoint(cutSound,transform.position);

        Destroy(gameObject);
    }
}
