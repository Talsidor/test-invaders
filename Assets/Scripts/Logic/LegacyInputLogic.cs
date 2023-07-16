using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegacyInputLogic : IPlayerInput
{
	public float HorizontalMovement => Input.GetAxis("Horizontal");
}
