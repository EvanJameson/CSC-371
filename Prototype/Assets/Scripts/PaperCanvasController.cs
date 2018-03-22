using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Authors: Tori
public class PaperCanvasController : MonoBehaviour {

	private RectTransform rt;
	private Canvas canvas;

	private bool active = true, expanded = false;

	private Vector3 centerScreen = new Vector3 (341, 211, 0);
	private Vector3 bottomRight = new Vector3 (1472, 100, 0);
	private Vector2 expandedSize = new Vector2 (1000, 1000);
	private Vector2 miniSize = new Vector2 (200, 200);
	private float buffer = 10;

	private Vector3 startingPoint;
	private Vector2 startingSize;
	private Vector3 deltaPosition;
	private Vector2 deltaSize;

	private float deltaTime = 2;
	private float bias = 0.01f;

	void Start () {
		rt = GetComponent<RectTransform> ();
		canvas = Object.FindObjectOfType<Canvas> ();
		canvas.SendMessage("ActivatePauseBackground");
		SetScreenDimensions();
		Animate(centerScreen, expandedSize);
	}

	void SetScreenDimensions() {
		bottomRight.x = canvas.pixelRect.width - 100;
		bottomRight.y = canvas.pixelRect.height - 100;
		centerScreen.x = canvas.pixelRect.width / 2.0f;
		centerScreen.y = canvas.pixelRect.height / 2.0f;
		expandedSize = new Vector2(canvas.pixelRect.height, canvas.pixelRect.height);
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
			SetScreenDimensions();
			Animate (startingPoint, miniSize);
			active = false;
			canvas.SendMessage("RestoreOtherPages");
		} else if (active) {
			/* Must have just been picked up - move to bottom corner */
			SetScreenDimensions();
			Animate (bottomRight, miniSize);
			active = false;
			canvas.SendMessage("RemovePauseBackground");
		} else if (expanded) {
			/* On the expanded UI, enlarge page for user to read */
			SetScreenDimensions();
			Animate (centerScreen, expandedSize);
			active = true;
			canvas.SendMessage("RemoveOtherPages", gameObject);
		} else {
			/* Clicked on bottom right corner requesting expanded UI */
			SetScreenDimensions();
			expanded = true;
			SendMessageUpwards ("ExpandJournalUI");
		}
	}

	/* Called from Storyline when all pieces should return to bottom right corner */
	void ReturnInactive() {
		SetScreenDimensions();
		Animate (bottomRight, miniSize);
		expanded = false;
	}

	/* Called from Storyline when necessary to move into place of expanded UI */
	void MoveTo(Vector3 destination) {
		SetScreenDimensions();
		Animate (destination, miniSize);
	}
}
