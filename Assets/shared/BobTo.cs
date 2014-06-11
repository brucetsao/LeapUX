using UnityEngine;
using System.Collections;

public class BobTo : MonoBehaviour {

	public 	float targetX = 0;
	public 	float targetY = 0;
	Vector2 velocity;
	public float snap = 2.0f;
	public float snapMagnitude = 0.01f;
	public float accel = 0.1f;
	public float drag = 0.99998f;

	// Use this for initialization
	void Start () {
		velocity = new Vector2(0,0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 toTarget = new Vector2(targetX - transform.localPosition.x, targetY - transform.localPosition.y);
		if (toTarget.magnitude == 0 ) return;
		velocity += toTarget * accel;
		velocity *= drag;
		transform.localPosition = new Vector3(transform.localPosition.x + velocity.x, transform.localPosition.y + velocity.y, transform.localPosition.z);
	}

	bool onTarget(){
		return (Vector2.Distance(MyPosition(), TargetPosition()) < snap) &&  (velocity.magnitude < snapMagnitude) ? true : false;
	}
	
	Vector2 TargetPosition (){
		return new Vector2(targetX, targetY);
	}
	
	Vector2 MyPosition (){
		return new Vector2(transform.localPosition.x, transform.localPosition.y);
	}	

	void animate(){
	}
}
