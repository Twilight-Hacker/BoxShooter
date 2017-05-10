using UnityEngine;
using System.Collections;

public class BasicMover : MonoBehaviour {

	public float spinSpeed = 180.0f;
	public float motionMangitude = 0.5f;
	public float distanceMultiplier = 1.0f;

	private bool doMotion = true;
	private CharacterController character;
	private Vector3 waypoint;
	private Vector3 startLocation;
	private Vector3 temp;
	private float waittime;
	private float localDistance;
	private float rand;

	void Start(){
		waypoint = gameObject.transform.position;
		startLocation = waypoint;
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject == null) {
			return;
		}

		if (GameManager.gm.gameIsOver) {
			return;
		}

		localDistance = (gameObject.transform.position.x - waypoint.x) + (gameObject.transform.position.z - waypoint.z) + (gameObject.transform.position.y - waypoint.y);

		if (localDistance <= 0.05 && doMotion) {
			doMotion = false;
			rand = (float)Random.Range (100, 350) / 100;
			waittime = rand + Time.time;
		}

		//Rotate around the object's up axis
		if (Time.time < waittime) {
			gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime);
		} else {
			//Move
			if (doMotion) {
				gameObject.transform.Translate (waypoint * Time.deltaTime * motionMangitude);
				temp = gameObject.transform.position - startLocation;
				if (temp.magnitude >= distanceMultiplier) {
					doMotion = false;
					rand = (float)Random.Range (100, 350) / 100;
					waittime = rand + Time.time;
				}
			} else {
				startLocation = gameObject.transform.position;
				waypoint = (distanceMultiplier * Random.onUnitSphere) + startLocation;
				if (waypoint.y <= 2) {
					waypoint.y = 3;
				}
				doMotion = true;
			}
		}
			
	}
}
