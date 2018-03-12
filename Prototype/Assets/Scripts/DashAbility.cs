﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Dash")]
public class DashAbility : Ability {

	public override void Initialize(GameObject obj)
	{
		
	}

	public override void TriggerAbility()
	{
		//Animator anim = CharacterControl.instance.player.GetComponent<Animator> ();
		//anim.SetTrigger ("Attack");

		GameObject wr = GameObject.Find ("WallCheckRight");
		GameObject wl = GameObject.Find ("WallCheckLeft");



		if((CharacterControl.instance.player.GetComponent<SpriteRenderer> ()).flipX == false && !(wr.GetComponent<WallCheckController>()).touching) //facing right
		{
			(CharacterControl.instance.player.GetComponent<Transform> ()).Translate (new Vector3(500f, 0f) * Time.deltaTime);
		}
		else if ((CharacterControl.instance.player.GetComponent<SpriteRenderer> ()).flipX == true && !(wl.GetComponent<WallCheckController>()).touching) //facing left
		{
			(CharacterControl.instance.player.GetComponent<Transform> ()).Translate (new Vector3(-500f, 0f) * Time.deltaTime);
		}

	}

}