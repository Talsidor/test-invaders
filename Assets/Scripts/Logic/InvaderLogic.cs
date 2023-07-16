using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class InvaderLogic : IEnemy
{
	static bool allInvadersMoveLeft = false;

	ILevelData level;

	public InvaderLogic(ILevelData levelData, Vector3 startPos)
	{
		level = levelData;

		position = startPos;
	}

	float speed = 2;
	public Vector3 Velocity => Vector3.UnitX * (allInvadersMoveLeft ? -speed : speed);

	Vector3 position;
	public Vector3 Position => position;

	public void SetSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

	public void Tick(float deltaTime)
	{
		if (position.X >= level.LevelWidth / 2)
		{
			allInvadersMoveLeft = true;
		}
		else if (position.X <= -level.LevelWidth / 2)
		{
			allInvadersMoveLeft = false;
		}

		position += Velocity * deltaTime;
	}
}

public interface IEnemy : IEntity
{
	public void SetSpeed(float newSpeed);
}