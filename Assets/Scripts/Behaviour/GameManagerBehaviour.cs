using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
	LevelSetupLogic levelSetupLogic;

    void Awake()
    {
		LevelData levelData = LoadLevelData();
		levelSetupLogic = new LevelSetupLogic(levelData);
		levelSetupLogic.OnPlayerSpawned += CreatePlayerInstance;
		levelSetupLogic. OnEnemySpawned +=  CreateEnemyInstance;
	}

	private void Start()
	{
		levelSetupLogic.StartLevel();
	}

	LevelData LoadLevelData()
	{
		LevelData levelData = Resources.Load<LevelData>("LevelData");
		if (levelData == null)
		{
			Debug.LogError("Unable to load LevelData asset", this);
		}
		return levelData;
	}

	void CreatePlayerInstance(PlayerLogic playerLogic)
	{
		var playerData = levelSetupLogic.Data.PlayerData;
		var playerPrefab = playerData.Prefab;
		var playerInstance = Instantiate(playerPrefab);
		var playerBehaviour = playerInstance.GetComponent<PlayerBehaviour>();
		playerBehaviour.Init(playerLogic);
	}

	void CreateEnemyInstance(InvaderLogic invaderLogic)
	{
		var enemyData = levelSetupLogic.Data.EnemyData[0];
		var enemyPrefab = enemyData.Prefab;
		var enemyInstance = Instantiate(enemyPrefab);
		var enemyBehaviour = enemyInstance.GetComponent<EnemyBehaviour>();
		enemyBehaviour.Init(invaderLogic);
	}
}
