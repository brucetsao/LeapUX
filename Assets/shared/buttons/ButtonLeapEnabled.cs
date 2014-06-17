using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * A ButtonLeapEnabled is "registered" with a leapMotionController enabled Controller.
 * As it is the controller, not the button, that determines functionality, 
 * the only functionality delivered here is to properly layer the label
 * and to change the appearance when hovered. 
 */

public class ButtonLeapEnabled : MonoBehaviour
{

		public GameObject onInstance; // the sprite that should show on hover/use
		public GameObject offInstance; // the sprite that shows by default (on not hover/use);
		public GameObject waveInstance; // a sprite indicating how well you have "waved" over the button
		public static Vector3 TITLE_POSITION = new Vector3 (0, -0.1116991f, -1f);
		public TextMesh title;
		public string titleSortingLayer = "Buttons";
		public Color textColor = new Color (1f, 1f, 1f);
		public Color textColorHover = new Color (1f, 1f, 1f);
		public float waveProgress = 0f;
		public bool hovered = false;
		public List<Vector3> buttonPoints = new List<Vector3> ();
		const float WAVE_PROGRESS = 0.05f;
		public bool waveLocked = false;

		// Use this for initialization
		void Start ()
		{
				Hover (false);
				title.renderer.sortingLayerName = titleSortingLayer;
				waveInstance.SetActive (false);
		}
	
		// Update is called once per frame
		void Update ()
		{
		}

		// flips the backgrounds on rollover/out
		public void Hover (bool overMe)
		{
				hovered = overMe;
				if (overMe) {
						((SpriteRenderer)onInstance.GetComponent<SpriteRenderer> ()).enabled = true;
						((SpriteRenderer)offInstance.GetComponent<SpriteRenderer> ()).enabled = false;
						title.renderer.material.color = textColorHover;
				} else {
						((SpriteRenderer)onInstance.GetComponent<SpriteRenderer> ()).enabled = false;
						((SpriteRenderer)offInstance.GetComponent<SpriteRenderer> ()).enabled = true;
						title.renderer.material.color = textColor;
						waveProgress = 0;

				}
		}
	
		public void AddWave (bool add)
		{
				if (waveLocked)
						return;
				if (add && waveProgress < 1) {
						waveProgress += WAVE_PROGRESS;
				} else {
						waveProgress -= WAVE_PROGRESS;
				}
		
				if (waveProgress < 0) {
						waveInstance.SetActive (false);
				} else {
						waveInstance.SetActive (true);
						waveInstance.transform.localScale = new Vector3 (Mathf.Min (1.0f, waveProgress), 1, 1);
				}
		}
		
		public void AddWave (bool add, Vector3 newPoint)
		{
				if (waveLocked) {
						return;
				} else 	if (add && waveProgress < 1) {
						if (buttonPoints.Count > 0) {
								Vector3 lastPoint = buttonPoints [buttonPoints.Count - 1];
								if (lastPoint.x < newPoint.x) {
										waveProgress += Mathf.Min ((newPoint.x - lastPoint.x) / 4.0f, 0.1f);
								} else {
										waveProgress -= WAVE_PROGRESS / 2.0f;
								}
						}
						Debug.Log ("wave progress pushed to " + waveProgress.ToString ());
						if (waveProgress >= 1.0f) {
								waveLocked = true;
						}
						buttonPoints.Add (newPoint);
						while (buttonPoints.Count > 5) {
								buttonPoints.Remove (buttonPoints [0]);
						}
				} else {
						waveProgress -= WAVE_PROGRESS;
				}



				if (waveProgress < 0) {
						waveInstance.SetActive (false);
				} else {
						waveInstance.SetActive (true);
						waveInstance.transform.localScale = new Vector3 (Mathf.Min (1.0f, waveProgress), 1, 1);
				}
		}

}
