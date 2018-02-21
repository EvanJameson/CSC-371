using UnityEngine;
using System.Collections;

public class ProjectileShootTriggerable : MonoBehaviour {

	[HideInInspector] public Rigidbody2D projectile;                          // Rigidbody variable to hold a reference to our projectile prefab
	[HideInInspector] public float projectileForce = 500f;                  // Float variable to hold the amount of force which we will apply to launch our projectiles

	public void Launch()
	{
		//Instantiate a copy of our projectile and store it in a new rigidbody variable called clonedBullet
		Transform t = CharacterControl.instance.player.transform;
		Rigidbody2D clonedBullet = Instantiate(projectile, t.position, t.rotation) as Rigidbody2D;
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		//Add force to the instantiated bullet, pushing it forward away from the bulletSpawn location, using projectile force for how hard to push it away
		Vector2 myPos = new Vector2(t.position.x, t.position.y);
		Vector2 direction = mousePosition - myPos;
		clonedBullet.AddForce(direction * projectileForce);
	}
}