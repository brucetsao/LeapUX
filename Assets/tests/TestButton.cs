using UnityEngine;
using System.Collections;

public class TestButton : MonoBehaviour {

	static TestButton lastHovered;

	public GameObject hover;

	const int NUM_IMAGES = 5;
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
		ButtonTitle ("Test " + (i + 1).ToString());
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
