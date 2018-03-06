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
	private float bias = 0.01f;

	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	
	void Update () {
		if (deltaTime <= 1 + bias) {
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
			/* Page is enlarged and expanded UI is in the background -
			 * Move back to original place on expanded UI */
			Animate (startingPoint, miniSize);
			active = false;
		} else if (active) {
			/* Must have just been picked up - move to bottom corner */
			Animate (bottomRight, miniSize);
			active = false;
		} else if (expanded) {
			/* On the expanded UI, enlarge page for user to read */
			Animate (centerScreen, expandedSize);
			active = true;
		} else {
			/* Clicked on bottom right corner requesting expanded UI */
			expanded = true;
			SendMessageUpwards ("ExpandJournalUI");
		}
	}

	/* Called from Storyline when all pieces should return to bottom right corner */
	void ReturnInactive() {
		Animate (bottomRight, miniSize);
		expanded = false;
	}

	/* Called from Storyline when necessary to move into place of expanded UI */
	void MoveTo(Vector3 destination) {
		Animate (destination, miniSize);
	}
}
