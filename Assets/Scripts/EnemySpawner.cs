using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;


    public EnemyIdleBehavior idleBehaviorType;
    public EnemyActiveBehavior activeBehaviorType;

    public void SpawnEnemy()
    {
     
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

    }

  
}
