using UnityEngine;
using System.Collections;

public class MusicScreen : MonoBehaviour {
	public TextMesh title;

	// Use this for initialization
	void Start () {
		title.renderer.sortingLayerName = "Buttons";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
