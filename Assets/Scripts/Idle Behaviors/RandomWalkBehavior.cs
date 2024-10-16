using UnityEngine;

public class RandomWalkBehavior : IIdleBehavior
{
    private float _patrolRadius = 10f;       // –адиус, в пределах которого генерируютс€ точки патрулировани€
    private float _moveSpeed = 3f;           // —корость перемещени€ врага
    private float _pointReachThreshold = 0.5f; // –ассто€ние, при котором считаетс€, что враг достиг точки

    private Vector3 _targetPoint;           
    private bool _hasTarget = false;        
    private Transform _enemyTransform;      

    public RandomWalkBehavior(Transform transform)
    {
        _enemyTransform = transform;
        GenerateNewTargetPoint();
    }

    public void IdleAction()
    {
        Patrol();
    }

    void Patrol()
    {
        // ≈сли враг близко к целевой точке, генерируем новую
        if (Vector3.Distance(_enemyTransform.position, _targetPoint) < _pointReachThreshold)
        {
            GenerateNewTargetPoint();
        }

        // ѕеремещаем врага в сторону целевой точки
        MoveTowardsTarget();
    }

    // √енераци€ новой случайной точки в пределах заданного радиуса
    void GenerateNewTargetPoint()
    {
        Vector2 randomPoint = Random.insideUnitCircle * _patrolRadius;
        _targetPoint = new Vector3(randomPoint.x, _enemyTransform.position.y, randomPoint.y);
        _hasTarget = true;
    }

    // ћетод дл€ перемещени€ врага к целевой точке
    void MoveTowardsTarget()
    {
        if (_hasTarget)
        {
            _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, _targetPoint, _moveSpeed * Time.deltaTime);
        }
    }

}
