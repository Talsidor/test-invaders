using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class LevelSetupLogic 
{
	readonly ILevelData data;
	public ILevelData Data => data;

	public Action< PlayerLogic> OnPlayerSpawned = delegate { };
	public Action<InvaderLogic>  OnEnemySpawned = delegate { };

	public LevelSetupLogic(ILevelData levelData)
	{
		data = levelData;
	}

	public void StartLevel()
	{
		SpawnPlayer ();
		SpawnEnemies();
	}

	void SpawnPlayer()
	{
		var input = new LegacyInputLogic();
		var player = new PlayerLogic(input, Vector3.UnitY * -4);
		OnPlayerSpawned(player);
	}

	void SpawnEnemies()
	{
		float xStartPos = -data.LevelWidth / 2;
		float yStartPos = 0;
		float xPerEnemy = (data.LevelWidth / data.EnemiesPerRow) / 2;

		for (int x = 0; x < data.EnemiesPerRow; x++)
		{
			float xPos = xStartPos + (xPerEnemy * x);

			for (int y = 0; y < data.NumberOfRows; y++)
			{
				float yPos = yStartPos + (1 * y);

				SpawnEnemy(xPos, yPos);
			}
		}
	}

	void SpawnEnemy(float xPos, float yPos)
	{
		var pos = new Vector3(xPos, yPos, 0);
		var enemy = new InvaderLogic(data, pos);
		OnEnemySpawned.Invoke(enemy);
	}
}
