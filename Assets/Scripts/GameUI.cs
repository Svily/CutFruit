using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public static GameUI Instance = null;

    private Text textScore;

    private int score = 0;

     void Awake()
    {
        Instance = this;
    }

    void Start () {

        textScore = GameObject.Find("Score").GetComponent<Text>();
		

	}

    public void addScore(int score) {

        this.score += score;

        textScore.text = this.score.ToString();

    }

    public void removeScore(int score) {

        this.score -= score;

        if (this.score <= 0) {

            SceneManager.LoadScene("Over");
            return;
        }

        textScore.text = this.score.ToString();
    }
}
