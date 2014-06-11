using UnityEngine;
using System.Collections;

public class TestsMenu : MonoBehaviour {

	public Transform item;

	const float COUNT = 10f;
	const float WIDTH = 3.25f;
	const float HEIGHT = 3.75f;
	const float COLS = 5f;

	// Use this for initialization
	void Start () {
		//transform.Translate ();

		for (int c = 0; c < COUNT; ++c) {
						addTest (c);
				}
		transform.localPosition = new Vector3((Mathf.Min(COLS, COUNT) - 1) * WIDTH/-2,0.5f,0);
	}

	void addTest(int c){
		Transform testButton = (Transform) Instantiate (item,new Vector3(c * WIDTH,0,0), Quaternion.identity);
		testButton.parent = transform;
		testButton.localPosition = new Vector3(c % COLS * WIDTH,Mathf.Floor (c / COLS) * -HEIGHT,0);
		TestButton button = testButton.GetComponent<TestButton> ();

		button.SetTest (c);
		}
	
	// Update is called once per frame
	void Update () {
	}
}
