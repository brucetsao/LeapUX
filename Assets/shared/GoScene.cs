using UnityEngine;
using System.Collections;

public class GoScene : MonoBehaviour {

	public string targetSceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Application.LoadLevel(targetSceneName);
	}
}
