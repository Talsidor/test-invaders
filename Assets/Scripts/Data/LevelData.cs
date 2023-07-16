using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Invaders/LevelData")]
public class LevelData : ScriptableObject, ILevelData
{
	[SerializeField]
	[Range(1, 100)]
	float levelWidth = 20;
	public float LevelWidth => levelWidth;

	[SerializeField]
	[Range(1, 10)]
	int enemiesPerRow = 4;
	public int EnemiesPerRow => enemiesPerRow;

	[SerializeField]
	[Range(1, 10)]
	int numberOfRows = 4;
	public int NumberOfRows => numberOfRows;

	[SerializeField] ScriptableGameObject playerData;
	public ScriptableGameObject PlayerData => playerData;

	[SerializeField] List<ScriptableGameObject> enemyData = new List<ScriptableGameObject>();
	public List<ScriptableGameObject> EnemyData => enemyData;
}

public interface ILevelData
{
	float LevelWidth { get; }

	int EnemiesPerRow { get; }
	int NumberOfRows { get; }
	int TotalEnemies => EnemiesPerRow * NumberOfRows;

	ScriptableGameObject PlayerData { get; }

	List<ScriptableGameObject> EnemyData { get; }
}