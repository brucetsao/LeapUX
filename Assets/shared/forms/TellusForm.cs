using UnityEngine;
using System.Collections;

public class TellusForm : MonoBehaviour {

	public GUISkin skin;
	public GameObject button;
	float w;
	float h;
	float t;
	float progress = 0f;
	public static int exposure;

	public static string myName = "Your FULL Name";
	// Use this for initialization
	void Start () {
		exposure = -1;
		t = Time.time;
		button.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		progress = Mathf.Min (1, ((Time.time - t)/0.5f));
	//	Debug.Log ("Progress: " + (progress.ToString ()));
	}

	public static string userLevel (){
		return exposureStrings [exposure];
		}

	public static string[] exposureStrings = new string[]{"Internal", "Developer", "Owns a Leap", "None"};
	void OnGUI () {
		GUI.skin = skin;
		w = Screen.width;
		h = Screen.height;
		
		float itemHeight = h * 0.075f;
		float itemWidth = w * 0.5f;
		float itemMargin = h * 0.025f;
		float left = w * 0.25f;
		float labelLeft = w * 0.05f;
		float labelWidth = left - labelLeft;
		float top = h * 0.25f;

		top -= (2 * (itemHeight + itemMargin)) * (1 - progress);

		GUI.Label (new Rect (labelLeft, top, labelWidth, itemHeight), "FULL Name");
		TellusForm.myName = GUI.TextField(new Rect(left, top, itemWidth, itemHeight), TellusForm.myName, 25);

		if (myName.Length > 3 && myName != "Your FULL Name"){
		GUI.Label (new Rect (labelLeft, top + (itemHeight + itemMargin), labelWidth, itemHeight), "Exposure");
		exposure = GUI.Toolbar (new Rect (left, top + (itemHeight + itemMargin) * 1f, w - left - itemMargin, itemHeight), exposure, exposureStrings);
		
			if ( exposure != -1) button.SetActive(true);
	//	if (GUI.Button (new Rect(left, top + (itemHeight + itemMargin) * 2f, itemWidth, itemHeight), "Send")) {
				
	//			Application.LoadLevel("menu");
	//	}
		}

	}
}
