using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Moq;
using NUnit.Framework;
using UnityEngine.TestTools;

public class enemy_movement_tests
{
	InvaderLogic enemy;
	Mock<ILevelData> levelData;

	[SetUp]
	public void SetUp()
	{
		levelData = new Mock<ILevelData>();
		enemy = new InvaderLogic(levelData.Object, Vector3.Zero);
	}

	[TearDown]
	public void TearDown()
	{

	}

	[Test]
	[TestCase(10)]
	[TestCase( 1)] // very narrow level
	[TestCase(99)] // very wide level
	[TestCase(10, 10.0f)] // fast boi
	[TestCase(10,  0.1f)] // slow boi
	public void enemy_changes_direction_when_bound_reached(float levelWidth, float speed = 1)
    {
        // Arrange
		levelData.Setup(x => x.LevelWidth).Returns(levelWidth);
		enemy.SetSpeed(speed);

		// Act

		// fast forward until enemy will reach edge of level
		enemy.Tick((levelWidth / 2) / speed);
		Assert.AreEqual(speed, enemy.Velocity.X);
		enemy.Tick(0.1f);
		Assert.AreEqual(-speed, enemy.Velocity.X);

		// fast forward until enemy does another lap
		enemy.Tick(levelWidth / speed);
		Assert.AreEqual(-speed, enemy.Velocity.X);
		enemy.Tick(0.1f);

		// Assert
		Assert.AreEqual(speed, enemy.Velocity.X);
	}
}
