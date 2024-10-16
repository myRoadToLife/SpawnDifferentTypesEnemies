using UnityEngine;

public class PatrolBehavior : IBehavior
{
    [SerializeField] private Transform[] _patrolPoints;       // ћассив точек патрулировани€

    [SerializeField] private float _moveSpeed = 3f;           // —корость патрулировани€ врага
    [SerializeField] private float _pointReachThreshold = 0.5f; // –ассто€ние, при котором считаетс€, что враг достиг точки

    private int _currentPointIndex = 0;
    private Transform _enemyTransform;

    public PatrolBehavior(Transform transform, Transform[] points)
    {
        _enemyTransform = transform;
        _patrolPoints = points;
    }
    public void Update()
    {
        Patrol();
    }

    public void Patrol()
    {
        // ѕроверка на наличие точек патрулировани€
        if (_patrolPoints.Length == 0)
            return;

        // ≈сли достигли текущей точки, переходим к следующей
        if (Vector3.Distance(_enemyTransform.position, _patrolPoints[_currentPointIndex].position) < _pointReachThreshold)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Length; // ѕереход к следующей точке
        }

        // ѕеремещаем врага в сторону текущей патрульной точки
        _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, _patrolPoints[_currentPointIndex].position, _moveSpeed * Time.deltaTime);
    }
}
