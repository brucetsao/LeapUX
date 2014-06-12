using UnityEngine;
using System.Collections;
using System;

public class StartController : MonoBehaviour {
	public TextMesh prompt;
	public GameObject signinButton;
	bool sib = false;
	const int DELAY = 4;

	// Use this for initialization
	void Start () {
		prompt.text = "You must have a folder named <b>\"/Users/" + Environment.UserName + "/test_data/\"</b> in your computer. \n" +
			"Please create it now if it does not already exist.";
	}
	
	// Update is called once per frame
	void Update () {
		if (!sib && (Time.time > DELAY)){
			sib = true;
			signinButton.SetActive(true);
		}
	}
}
