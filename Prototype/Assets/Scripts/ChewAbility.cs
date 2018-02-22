using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Abilities/ChewAbility")]
public class ChewAbility : Ability {
	
	private ChewTriggerable chewer;
	public override void Initialize(GameObject obj)
	{
		chewer = obj.GetComponent<ChewTriggerable> ();
	}

	public override void TriggerAbility()
	{
		chewer.Chew();
	}
}