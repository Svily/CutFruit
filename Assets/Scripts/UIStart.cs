using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStart : MonoBehaviour {

    private Button btnPlay;
    private Button btnSound;
    private AudioSource bgPlayer;
    public Sprite[] soundSprites;
    private Image imgSound;


	void Start () {

        getComponets();
        btnPlay.onClick.AddListener(onPlayClick);
        btnSound.onClick.AddListener(onSoundClick);
	}

    void OnDestroy()
    {
        btnPlay.onClick.RemoveListener(onPlayClick);
        btnSound.onClick.RemoveListener(onSoundClick);
    }

    private void getComponets() {

        btnPlay = transform.Find("BtnPlay").GetComponent<Button>();
        btnSound = transform.Find("BtnBgm").GetComponent<Button>();
        bgPlayer = transform.Find("BtnBgm").GetComponent<AudioSource>();
        imgSound = transform.Find("BtnBgm").GetComponent<Image>();
    }

	void Update () {
		
	}


    void onPlayClick() {

        SceneManager.LoadScene("Play");

    }

    void onSoundClick() {

        if (bgPlayer.isPlaying)
        {
            bgPlayer.Pause();
            imgSound.sprite = soundSprites[1];
        }
        else {
            bgPlayer.Play();
            imgSound.sprite = soundSprites[0];
        }

    }
}
