using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    private LineRenderer cutFruitRay;

    private bool firstMouseDown = false ;

    private bool mouseStayDown = false;

    private Vector3[] postions = new Vector3[10];

    private int posCount = 0;

    private Vector3 head;

    private Vector3 last;

    private AudioSource swing;

	void Start () {

        cutFruitRay = GetComponent<LineRenderer>();

        swing = GetComponent<AudioSource>();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            firstMouseDown = true;

            mouseStayDown = true;
        }


        if (Input.GetMouseButtonUp(0)) {

            mouseStayDown = false;

        }

        onDrawLine();

        

        firstMouseDown = false;
    }


    private void onDrawLine() {


        if (firstMouseDown) {

            posCount = 0;

            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            last = head;

            swing.Play();
        }

        if (mouseStayDown)
        {
            

            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if (Vector3.Distance(head, last) >= 0.01f)
            {

                savePostion(head);

                posCount++;

                onRayCast(head);


            }

            last = head;
        }
        else {
            this.postions = new Vector3[10];
        }
        
        ChangePostions(postions);

    }


    private void savePostion(Vector3 savePostion) {

        savePostion.z = 0;

        if (posCount <= 9) {

            for (int i =posCount;i<10;i++) {
                postions[i] = savePostion;
            }

        }
        else {

            for (int i =0; i<9;i++) {

                postions[i] = postions[i + 1];

                postions[9] = savePostion;

            }

        }

    }


    public void ChangePostions(Vector3[] postions) {


        cutFruitRay.SetPositions(postions);

    }


    private void onRayCast(Vector3 worldPos) {

        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        RaycastHit[] hits = Physics.RaycastAll(ray);

        for (int i =0; i< hits.Length;i++) {

            hits[i].collider.gameObject.SendMessage("OnCut",SendMessageOptions.DontRequireReceiver);

        }

    }
}
