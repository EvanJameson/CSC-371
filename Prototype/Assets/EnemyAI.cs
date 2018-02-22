using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class EnemyAI : MonoBehaviour {

	public Transform target;
	public GameObject player;

	public float updateRate = 2f;

	private Seeker seeker;
	private Rigidbody2D rb;

	//The calculated path

	public Path path;
	//AI's speed
	public float speed = 600f;
	public ForceMode2D fMode;

	[HideInInspector]
	public bool pathIsEnded = false;

	// max dist from AI to waypoint for it to cont to next waypoint
	public float nextWaypointDistance = 3;

	//waypoint currently targeting (index)
	private int currentWaypoint = 0;

	void Start(){
		seeker = GetComponent<Seeker> ();
		rb = GetComponent<Rigidbody2D> ();

		if (target == null) {
			Debug.LogError ("No player");
			return;
		}



	}
	
	void Update()
	{
		if(player == null)
		{
			player =  GameObject.Find ("RatPlayer(Clone)");
			target = player.GetComponent<Transform>();
			//player.gameObject.SetActive (false);
			if(target == null)
			{
				Debug.LogError ("No player2");
			}
			seeker.StartPath (transform.position, target.position, OnPathComplete);

			StartCoroutine (UpdatePath());
		}
	}


	IEnumerator UpdatePath(){
		if (target == null) {
			yield return false;
		}
		seeker.StartPath (transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds (1f / updateRate);
		StartCoroutine (UpdatePath ());
	}

	public void OnPathComplete(Path p){
		Debug.Log ("got path error" + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	
	void FixedUpdate(){
		if (target == null) {
			return;
		}
		if (path == null)
			return;
		if(currentWaypoint >= path.vectorPath.Count){
			if(pathIsEnded){
				return;
			}
			Debug.Log ("End of path reached.");
			pathIsEnded = true;
			return;
		}

		pathIsEnded = false;
		//direction to next waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;

		//move the ai
		rb.AddForce(dir,fMode);

		float dist = Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]);

		if(dist < nextWaypointDistance){
			currentWaypoint++;
			return;
		}


	}

}
