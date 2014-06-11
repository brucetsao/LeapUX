using UnityEngine;
using System.Collections;

public class largeMinecraftButton : MonoBehaviour {
	public GameObject onButton;
	public GameObject offButton;

	public static largeMinecraftButton lastButton;

	// Use this for initialization
	void Start () {
		Swap(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Swap(bool isOn){
		onButton.SetActive(isOn);
		offButton.SetActive(!isOn);
	}

	void OnMouseOver(){
		if (lastButton){
			lastButton.Swap(false);
		}
		Swap(true);
		lastButton = this;
	}

	void OnMouseOut(){
		Swap(false);
	}
}
