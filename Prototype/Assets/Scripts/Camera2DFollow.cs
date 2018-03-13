using System;
using UnityEngine;

//namespace UnityStandardAssets._2D
//{
	public class Camera2DFollow : MonoBehaviour
	{
		public Transform target;
		public float damping = 1;
		public float lookAheadFactor = 3;
		public float lookAheadReturnSpeed = 0.5f;
		public float lookAheadMoveThreshold = 0.1f;

		private float m_OffsetZ;
		private Vector3 m_LastTargetPosition;
		private Vector3 m_CurrentVelocity;
		private Vector3 m_LookAheadPos;

		private bool spanscene = false;
		private Camera cam;
		private float deltaTime = 2;
		private float bias = 0.01f;
		private Vector3 deltaPosition;
		private float deltaSize;
		private Vector3 startPosition;
		private float startSize;
		private bool animating = false;

		// Use this for initialization
		private void Start()
		{
			target = CharacterControl.instance.player.transform;
			m_LastTargetPosition = target.position;
			m_OffsetZ = (transform.position - target.position).z;
			transform.parent = null;
			cam = GetComponent<Camera>();
		}


		// Update is called once per frame
		private void Update()
		{
			if (!spanscene) {
				target = CharacterControl.instance.player.transform;
				// only update lookahead pos if accelerating or changed direction
				float xMoveDelta = (target.position - m_LastTargetPosition).x;

				bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

				if (updateLookAheadTarget)
				{
					m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
				}
				else
				{
					m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
				}

				Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
				Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

				transform.position = newPos;

				m_LastTargetPosition = target.position;
			} else if (deltaTime < 1 + bias) {
				//Debug.Log("in other branch of update");
				cam.orthographicSize = startSize + deltaSize * deltaTime;
				cam.transform.position = startPosition + deltaPosition * deltaTime;
			} else {
				DoneAnimating();
			}
			deltaTime += Time.deltaTime;
		}

		public void DoneAnimating() {
			if (animating && deltaTime > 4f) {
				// Animate back to original camera position
				deltaTime = 0;
				startSize = cam.orthographicSize;
				deltaSize *= -1;
				startPosition = cam.transform.position;
				deltaPosition *= -1;
				animating = false;
			} else if (!animating) {
				// Let the player keep playing
				CharacterControl.instance.player.SendMessage("ResumeMovement");
				spanscene = false;
			}
		}

		public void SpanScene(Vector3 goal) {
			//Debug.Log("in span scene");
			spanscene = true;
			deltaTime = 0;
			startSize = cam.orthographicSize;
			startPosition = cam.transform.position;
			deltaSize = goal.z - cam.orthographicSize;
			deltaPosition = goal - cam.transform.position;
			deltaPosition.z = 0;
			CharacterControl.instance.player.SendMessage("FreezeMovement");
			animating = true;
		}
	}
//}