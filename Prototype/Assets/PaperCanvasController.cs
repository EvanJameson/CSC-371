using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCanvasController : MonoBehaviour {

	private RectTransform rt;

	private bool active = true, expanded = false;

	private Vector3 centerScreen = new Vector3 (341, 211, 0);
	private Vector3 bottomRight = new Vector3 (660, 60, 0);
	private Vector2 expandedSize = new Vector2 (600, 600);
	private Vector2 miniSize = new Vector2 (100, 100);

	private Vector3 startingPoint;
	private Vector2 startingSize;
	private Vector3 deltaPosition;
	private Vector2 deltaSize;
	private float deltaTime = 2;

	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	
	void Update () {
		if (deltaTime <= 1 + 0.01) {
			rt.position = startingPoint + deltaPosition * deltaTime;
			rt.sizeDelta = startingSize + deltaSize * deltaTime;
			deltaTime += 0.1f;
		}
	}

	void Animate(Vector3 destination, Vector2 size) {
		deltaTime = 0;
		deltaPosition = destination - rt.position;
		deltaSize = size - rt.sizeDelta;
		startingPoint = rt.position;
		startingSize = rt.sizeDelta;
	}
		
	void OnClick() {
		if (active && expanded) {
			Animate (startingPoint, miniSize);
			active = false;
		} else if (active) {
			Animate (bottomRight, miniSize);
			active = false;
		} else if (expanded) {
			Animate (centerScreen, expandedSize);
			active = true;
		} else {
			expanded = true;
			SendMessageUpwards ("ExpandJournalUI");
		}
	}

	void ReturnInactive() {
		Animate (bottomRight, miniSize);
		expanded = false;
	}

	void MoveTo(Vector3 destination) {
		Animate (destination, miniSize);
	}
}
