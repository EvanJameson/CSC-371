﻿using UnityEngine;
using System.Collections;

//Authors: Nick Sciacqua
[CreateAssetMenu (menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability {

	public float projectileForce = 500f;
	public Rigidbody2D projectile;

	private ProjectileShootTriggerable launcher;

	public override void Initialize(GameObject obj)
	{
		launcher = obj.GetComponent<ProjectileShootTriggerable> ();
		launcher.projectileForce = projectileForce;
		launcher.projectile = projectile;
	}

	public override void TriggerAbility()
	{
		launcher.Launch ();
	}

}