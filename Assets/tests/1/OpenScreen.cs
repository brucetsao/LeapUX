using UnityEngine;
using System.Collections;

public class OpenScreen : MonoBehaviour {

	public GameObject goFrom;
	public GameObject goTo;
	public TestScriptBase testScript;
	public string screen;
	public string buttonName;
	public string goName;

	public static Vector3 WAY_OFF = new Vector3(0, 1000, 0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Debug.Log ("OpenScreen click");
		if (testScript != null){
			testScript.AddClick(screen, buttonName, goName);
			testScript.CheckState(screen, "(opened)", goName);
		} else {
			Debug.Log ("not setting state with OpenScreen -- no test script");
		}
		goTo.transform.position = Vector3.zero;
		goFrom.transform.position = WAY_OFF;
	}
}
