using UnityEngine;
using System.Collections;

public class Test1Script : MonoBehaviour {

	TestScript script;

	GameObject panel1;
	GameObject panel2;

	// Use this for initialization
	void Start () {
		script = new TestScript("Test One");
		script.Report();
	}
	
	// Update is called once per frame
	void Update () {
		SetActivePanel(1);
	}

	void SetActivePanel(int n){
		return;
		panel1.SetActive(n == 1 ? true : false);
		panel2.SetActive (n == 2 ? true : false);
	}

}
