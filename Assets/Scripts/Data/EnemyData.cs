using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Invaders/EnemyData")]
public class EnemyData : ScriptableGameObject
{

}

public abstract class ScriptableGameObject : ScriptableObject, IScriptableGameObject
{
	[SerializeField] GameObject prefab;

	public GameObject Prefab => prefab;
}

public interface IScriptableGameObject
{
	GameObject Prefab { get; }
}