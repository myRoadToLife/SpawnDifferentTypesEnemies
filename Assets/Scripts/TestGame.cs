using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Transform _point;
    [SerializeField] private EnemyActiveBehavior _enemyActiveBehavior;
    [SerializeField] private EnemyIdleBehavior _enemyIdleBehavior;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _enemySpawner.SpawnEnemy();
        }
    }
}
