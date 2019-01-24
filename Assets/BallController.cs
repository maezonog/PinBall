using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	private float visiblePosZ = -6.5f;

	private GameObject gameoverText;
	private GameObject scoreText;
	private int sum = 0;

	// Use this for initialization
	void Start () {

		this.gameoverText = GameObject.Find ("GameOverText");
		this.scoreText = GameObject.Find ("ScoreText");

	}
	
	// Update is called once per frame
	void Update () {

		if (this.transform.position.z < this.visiblePosZ) {
			this.gameoverText.GetComponent<Text> ().text= "Game Over";
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "SmallStarTag"){
			sum += 10;
			this.scoreText.GetComponent<Text> ().text = "Score " + sum;
		}
		if (other.gameObject.tag == "LargeStarTag"){
			sum += 20;
			this.scoreText.GetComponent<Text> ().text = "Score " + sum;
		}
		if (other.gameObject.tag == "SmallCloudTag"){
			sum += 50;
			this.scoreText.GetComponent<Text> ().text = "Score " + sum;
		}
		if (other.gameObject.tag == "LargeCloudTag"){
			sum += 100;
			this.scoreText.GetComponent<Text> ().text = "Score " + sum;
		}
	}
}
