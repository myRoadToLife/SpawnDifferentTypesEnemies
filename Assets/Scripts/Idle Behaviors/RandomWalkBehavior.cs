using UnityEngine;

public class RandomWalkBehavior : IIdleBehavior
{
    private float _patrolRadius = 10f;       // ������, � �������� �������� ������������ ����� ��������������
    private float _moveSpeed = 3f;           // �������� ����������� �����
    private float _pointReachThreshold = 0.5f; // ����������, ��� ������� ���������, ��� ���� ������ �����

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
        // ���� ���� ������ � ������� �����, ���������� �����
        if (Vector3.Distance(_enemyTransform.position, _targetPoint) < _pointReachThreshold)
        {
            GenerateNewTargetPoint();
        }

        // ���������� ����� � ������� ������� �����
        MoveTowardsTarget();
    }

    // ��������� ����� ��������� ����� � �������� ��������� �������
    void GenerateNewTargetPoint()
    {
        Vector2 randomPoint = Random.insideUnitCircle * _patrolRadius;
        _targetPoint = new Vector3(randomPoint.x, _enemyTransform.position.y, randomPoint.y);
        _hasTarget = true;
    }

    // ����� ��� ����������� ����� � ������� �����
    void MoveTowardsTarget()
    {
        if (_hasTarget)
        {
            _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, _targetPoint, _moveSpeed * Time.deltaTime);
        }
    }

}
