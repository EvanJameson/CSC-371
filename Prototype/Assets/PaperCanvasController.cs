using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCanvasController : MonoBehaviour {

	private bool animateOut = false;
	private RectTransform rt;
	private CanvasRenderer xchild;
	private Vector3 direction = new Vector3(300f-17f, -180f+27.5f, 0);

	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	
	void Update () {
		if (animateOut && rt.sizeDelta.x > 100) {
			rt.sizeDelta -= new Vector2 (30, 30);
			rt.position += direction * 0.06f;
		} else if (animateOut) {
			animateOut = false;
		}
	}
		
	void AnimateOut() {
		animateOut = true;
		SendMessageUpwards ("RemoveXButton");
	}
}
