using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class PlayerLogic : IPlayer
{
	Vector3 velocity;
	public Vector3 Velocity => velocity;

	Vector3 position;
	public Vector3 Position => position;

	IPlayerInput input;
	public IPlayerInput Input => input;

	float acceleration = 50;
	public float Acceleration => acceleration;

	float maxVelocity = 2;

	public PlayerLogic(IPlayerInput inputModule, Vector3 startingPos)
	{
		input	 = inputModule;
		position = startingPos;
	}

	public void Tick(float deltaTime)
	{
		velocity.X = UnityEngine.Mathf.Lerp(velocity.X, input.HorizontalMovement * maxVelocity, acceleration * deltaTime);

		position   += velocity * deltaTime;
	}

	public void SetAcceleration(float newAcceleration)
	{
		acceleration = newAcceleration;
	}

	public void SetMaxSpeed(float newMaxSpeed)
	{
		maxVelocity = newMaxSpeed;
	}
}

public interface IPlayer : IEntity
{
	IPlayerInput Input { get; }

	float Acceleration { get; }
}

public interface IEntity
{
	Vector3 Velocity { get; }

	Vector3 Position { get; }

	public void Tick(float deltaTime)
	{

	}
}