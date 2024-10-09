using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private EnemyIdleBehaviorType _idleType;
    [SerializeField] private EnemyActiveBehaviorType _activeType;

    private IIdleBehavior _idleBehavior;
    private IActiveBehavior _activeBehavior;

    public void SpawnEnemy()
    {
        // ������� ������ �����
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        // �������� ������ �� ���������� ���������
        switch (_idleType)
        {
            case EnemyIdleBehaviorType.StandStill:
                _idleBehavior = enemy.GetComponent<StandStillBehavior>();
                break;
            case EnemyIdleBehaviorType.Patrol:
                _idleBehavior = enemy.GetComponent<PatrolBehavior>();
                break;
            case EnemyIdleBehaviorType.RandomWalk:
                _idleBehavior = enemy.GetComponent<RandomWalkBehavior>();
                break;
        }

        switch (_activeType)
        {
            case EnemyActiveBehaviorType.Stalking:
                _activeBehavior = enemy.GetComponent<StalkingBehavior>();
                break;
            case EnemyActiveBehaviorType.Flee:
                _activeBehavior = enemy.GetComponent<FleeBehavior>();
                break;
            case EnemyActiveBehaviorType.DieOnContact:
                _activeBehavior = enemy.GetComponent<DieOnContactBehavior>();
                break;
        }

        // �������������� �����
        enemy.Initialize(_idleBehavior, _activeBehavior);
    }

}
