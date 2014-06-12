using UnityEngine;
using System.Collections;

public class SpeechBubble : MonoBehaviour {
	private const float TRANSITION = 0.1f;
	public GameObject background;
	public GameObject text;
	private bool add = false;
	SpriteRenderer br ;
		TextMesh tm ;

	public SpeechBubble parent;

	// Use this for initialization
	void Start () {
		if (parent != null){
			return;
		}
		br = background.GetComponent<SpriteRenderer>();
		tm	= text.GetComponent<TextMesh>();
		tm.renderer.material.color = br.color = new Color(1f, 1f, 1f, 0f);
		background.renderer.sortingLayerName = "DoneButton";
		text.renderer.sortingLayerName = "Labels";
	}
	
	// Update is called once per frame
	void Update () {
		
		if (parent != null){
			return;
		}
		if (add){
			if (br.color.a < 1){
				br.color = new Color(1f, 1f, 1f, br.color.a + TRANSITION);
				tm.renderer.material.color = new Color(1f, 1f, 1f, br.color.a);
			}
		} else {
			if (background.renderer.material.color.a > 0){
				br.color = new Color(1f, 1f, 1f, br.color.a - TRANSITION);
				tm.renderer.material.color = new Color(1f, 1f, 1f, br.color.a);
			}
		}
	}

	public void OnMouseDown(){
		if (parent != null){
			parent.OnMouseDown();
			return;
		}
		add = !add;
		Debug.Log ("Add Flipped");
	}
}
