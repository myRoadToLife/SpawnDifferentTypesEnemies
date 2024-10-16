using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("EnumeType")]
    [SerializeField] private EnemyIdleBehaviorType _idleType;
    [SerializeField] private EnemyActiveBehaviorType _activeType;

    [Header("Elements")]
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemyPrefab;

    [Header("Effects")]
    [SerializeField] private ParticleSystem _enemyDieEffectPrefab;

    [Header("PointsPatrol")]
    [SerializeField] private Transform[] _patrolPoints;

    private IBehavior _activeBehavior;
    private IBehavior _idleBehavior;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        // Создаем префаб врага
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, null);

        // Получаем ссылки на компоненты поведения
        switch (_idleType)
        {
            case EnemyIdleBehaviorType.StandStill:
                _idleBehavior = new StandStillBehavior();
                break;
            case EnemyIdleBehaviorType.Patrol:
                _idleBehavior = new PatrolBehavior(enemy.transform, _patrolPoints);
                break;
            case EnemyIdleBehaviorType.RandomWalk:
                _idleBehavior = new RandomWalkBehavior(enemy.transform);
                break;
        }

        switch (_activeType)
        {
            case EnemyActiveBehaviorType.Stalking:
                _activeBehavior = new StalkingBehavior(_player.transform, enemy.transform);
                break;
            case EnemyActiveBehaviorType.Flee:
                _activeBehavior = new FleeBehavior(_player.transform, enemy.transform);
                break;
            case EnemyActiveBehaviorType.DieOnContact:
                _activeBehavior = new DieOnContactBehavior(enemy.gameObject, _enemyDieEffectPrefab.gameObject);
                break;
        }

        // Инициализируем врага
        enemy.Initialize(_idleBehavior, _activeBehavior);
    }
}
