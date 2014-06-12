using UnityEngine;
using System.Collections;

public class SliderMC : MonoBehaviour {
	public GameObject thumb;
	public GameObject back;
	public float sliderWidth;
	public Camera camera;
	public TextMesh title;
	public string phrase;
	public float ratio = 1.0f;

	const int HEIGHT = 47;
	const int THUMB_WIDTH = 20;
	public float maxValue = 100f;
	public string suffix = "%";

	public TestScriptBase testBase;
	public string screenName;

	bool active; 

	// Use this for initialization
	void Start () {
		active = false;
		thumb.transform.position = new Vector3(transform.position.x + sliderWidth * ratio, thumb.transform.position.y, -0.5f);
		title.text = phrase + ": " + Mathf.Round (maxValue * ratio) + suffix;
		title.renderer.sortingLayerName = "Titles";
	}
	
	// Update is called once per frame
	void Update () {
		if (active){
			Debug.Log ("Moving thumb....");

			Vector3 worldMouse = camera.ScreenToWorldPoint(Input.mousePosition);

			float x = Mathf.Min (sliderWidth + transform.position.x, Mathf.Max (transform.position.x, worldMouse.x));

			ratio = (x - transform.position.x)/sliderWidth;

			title.text = phrase + ": " + Mathf.Round (maxValue * ratio) + suffix;

			thumb.transform.position = new Vector3(x, thumb.transform.position.y, -0.5f);
		}
	}

	void OnMouseUp(){
		active = false;
		Debug.Log ("not moving the thumb");

		if (testBase != null){
			testBase.AddClick(screenName, phrase, Mathf.Round(maxValue * ratio).ToString());
		}
	}

	void OnMouseDown(){
		active = true;
		Debug.Log ("moving the thumb");
	}
}
