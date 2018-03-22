//Authors: Nick Sciacqua

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Character")]
public class Character : ScriptableObject {
	
	public string characterName = "Default";
	public int startingHP = 100;
	public Ability[] characterAbilities;
	public GameObject prefab;
	public float jump_velocity = 5;

}
