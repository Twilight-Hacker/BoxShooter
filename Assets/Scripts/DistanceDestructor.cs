using UnityEngine;
using System.Collections;

public class DistanceDestructor : MonoBehaviour {

	public float distance = 15;
	public bool detachChildren = false;

	// Use this for initialization
	void Update(){
		if(gameObject.transform.position.magnitude >= distance){
			DestroyNow ();
		}
	}

	void DestroyNow ()
	{
		if (detachChildren) { // detach the children before destroying if specified
			transform.DetachChildren ();
		}

		// destory the game Object
		Destroy(gameObject);
	}
}
