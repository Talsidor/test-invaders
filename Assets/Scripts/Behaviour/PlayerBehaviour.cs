using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	PlayerLogic player;

	public void Init(PlayerLogic newPlayer)
	{
		player = newPlayer;
		transform.position = player.Position.ToUnity();
	}

	void Update()
	{
		player.Tick(Time.deltaTime);
		transform.position = player.Position.ToUnity();
	}
}
