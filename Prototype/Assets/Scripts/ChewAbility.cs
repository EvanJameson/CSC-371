using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Abilities/ChewAbility")]
public class ChewAbility : Ability {
	
	private ChewTriggerable chewer;
	public override void Initialize(GameObject obj)
	{
		chewer = FindObjectOfType<ChewTriggerable> ();
	}

	public override void TriggerAbility()
	{
		if (!chewer.other_collider.CompareTag ("Rope")) {
			FindObjectOfType<AudioManager>().Play("Clink");
		}
	}

}