using UnityEngine;

public class TestGame : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Transform _point;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _enemySpawner.SpawnEnemy();
        }
    }
}
