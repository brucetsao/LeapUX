using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestButton : MonoBehaviour {

	static TestButton lastHovered;
	const int NUM_IMAGES = 5;

	static List<string> names = new List<string>(){"Goatcraft - mouse", "Goatcraft LMC - v1", "", "", "", "", "", "", "", "", "", "", "", "", ""};

	public GameObject hover;
	public Sprite[] sprites = new Sprite[NUM_IMAGES];
	public int testNumber;
	
	public GameObject title;
	public GameObject icon;
	// Use this for initialization
	void Start () {
		hover.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetTest(int i){
		testNumber = i;
		int imageNumber = i % NUM_IMAGES;
		icon.GetComponent<SpriteRenderer> ().sprite = sprites[imageNumber];
		ButtonTitle (names[i]);
		}

	public void ButtonTitle(string s){
				title.GetComponent<TextMesh> ().text = s;
		}

	void OnMouseOver(){
		if (lastHovered != null){
			lastHovered.hover.SetActive(false);
		}
		hover.SetActive (true);
		lastHovered = this;
	}

	void OnMouseOut(){
		hover.SetActive(false);
	}

	string targetSceneName {
		get { return "Test" + (1 + testNumber).ToString(); }
	}

	void OnMouseDown(){
		Application.LoadLevel(targetSceneName);
	}
}
