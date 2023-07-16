using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyBehaviour : MonoBehaviour
{
	InvaderLogic invader;

	public void Init(InvaderLogic newInvader)
	{
		invader = newInvader;
		transform.position = invader.Position.ToUnity();
	}

	void Update()
	{
		invader.Tick(Time.deltaTime);
		transform.position = invader.Position.ToUnity();
	}
}

static public class Vector3ExtensionMethods
{
	public static UnityEngine.Vector3 ToUnity(this System.Numerics.Vector3 n) => new UnityEngine.Vector3(n.X, n.Y, n.Z);
	public static System.Numerics.Vector3 ToNumerics(this Vector3 u) => new System.Numerics.Vector3(u.x, u.y, u.z);
}