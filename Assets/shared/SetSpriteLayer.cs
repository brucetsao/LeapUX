using UnityEngine;
using System.Collections;

public class SetSpriteLayer : MonoBehaviour {
	public GameObject target;
	public string layerName;
	public int layerOrder;

	// Use this for initialization
	void Start () {
		target.GetComponent<TextMesh>().renderer.sortingLayerName = layerName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
