using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;
	private float defaultAngle = 20;
	private float flickAngle= -20;
	private int leftFingerId;
	private int rightFingerId;


	// Use this for initialization
	void Start () {

		this.myHingeJoint = GetComponent<HingeJoint> ();
		SetAngle (this.defaultAngle);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount > 0) {
			for (int i = 0; i < Input.touchCount; i++) {
				var id = Input.touches [i].fingerId;
				var pos = Input.touches [i].position;

				TouchPhase phase = Input.touches[i].phase;

				Debug.LogFormat ("{0} - x:{1}, y:{2}", id, pos.x, pos.y);

				if(phase == TouchPhase.Began){

				   if (pos.x < Screen.width * 0.5 && tag == "LeftFripperTag") {
					leftFingerId = id;
					SetAngle (this.flickAngle);

				}else if (pos.x >= Screen.width * 0.5 && tag == "RightFripperTag") {
					rightFingerId = id;
					SetAngle (this.flickAngle);
				}

			}else if (phase == TouchPhase.Ended){

				if(id == leftFingerId && tag == "LeftFripperTag") 
					SetAngle(this.defaultAngle);
					if (id == rightFingerId && tag == "RightFripperTag")
					SetAngle (this.defaultAngle);
			}
		}
	}
	
			

		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
	}

	

		public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;

		
	}
}
