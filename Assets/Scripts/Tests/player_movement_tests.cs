using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;
using System.Numerics;
using Vector3 = System.Numerics.Vector3;

public class player_movement_tests
{
	PlayerLogic player;
	Mock<IPlayerInput> input;

	[SetUp]
	public void SetUp()
	{
		input = new Mock<IPlayerInput>();
		player = new PlayerLogic(input.Object, new Vector3(0,0,0));
	}

	[TearDown]
	public void TearDown()
	{

	}

    [Test]
	[TestCase( 1,  1,  1,  1,  1)]
	[TestCase(-1,  1,  1, -1,  1)]
	[TestCase( 1,  1,  2,  2,  1)] // max speed 2 right
	[TestCase(-1,  1,  2, -2,  1)] // max speed 2 left
	[TestCase( 0,  1,  1,  0,  1)] // test no input but yes acceleration
	[TestCase( 1,  0,  1,  0,  1)] // test yes input but no acceleration
	[TestCase( 1,  1,  1,  2,  2)] // test right for 2 seconds
	[TestCase(-1,  1,  1, -2,  2)] // test left  for 2 seconds
	public void input_in_each_dir_moves_player(float input, float acceleration, float maxSpeed, float endXPos, float time)
    {
		// Arrange
		this.input.Setup(x => x.HorizontalMovement).Returns(input);
		player.SetAcceleration(acceleration);
		player.SetMaxSpeed	  (maxSpeed);

		// Act
		player.Tick(time);

		// Assert
		Assert.AreEqual(endXPos, player.Position.X);
	}
}
