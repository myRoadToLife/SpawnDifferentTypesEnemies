using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyIdleBehaviorType _idleType;
    [SerializeField] private EnemyActiveBehaviorType _activeType;

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _enemySpeed;

    [SerializeField] private ParticleSystem _enemyDieEffectPrefab;

    [SerializeField] private Transform[] _patrolPoints;

    private IIdleBehavior _idleBehavior;
    private IActiveBehavior _activeBehavior;
    [SerializeField] private float _slowDownRate;

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
                _activeBehavior = new FleeBehavior(_player.transform, enemy.transform, _enemySpeed);
                break;
            case EnemyActiveBehaviorType.DieOnContact:
                _activeBehavior = new DieOnContactBehavior(enemy.gameObject, _enemyDieEffectPrefab.gameObject);
                break;
        }

        // Инициализируем врага
        enemy.Initialize(_idleBehavior, _activeBehavior);
    }
}
