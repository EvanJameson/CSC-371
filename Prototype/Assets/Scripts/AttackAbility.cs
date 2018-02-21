using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/AttackAbility")]
public class AttackAbility : Ability {

	public override void Initialize(GameObject obj)
	{
	}

	public override void TriggerAbility()
	{
		Animator anim = CharacterControl.instance.player.GetComponent<Animator> ();
		anim.SetTrigger ("Attack");
		(CharacterControl.instance.player.GetComponent<Rigidbody2D> ()).velocity += (new Vector2 (2, 0));

	}

}