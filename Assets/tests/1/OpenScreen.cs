using UnityEngine;
using System.Collections;

public class OpenScreen : MonoBehaviour {

	public GameObject goFrom;
	public GameObject goTo;

	public static Vector3 WAY_OFF = new Vector3(0, 1000, 0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		goTo.transform.position = Vector3.zero;
		goFrom.transform.position = WAY_OFF;
	}
}
