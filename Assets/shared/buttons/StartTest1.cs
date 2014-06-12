using UnityEngine;
using System.Collections;

public class StartTest1 : MonoBehaviour {
	public GameObject doneButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		doneButton.SetActive(true);
	}
}
