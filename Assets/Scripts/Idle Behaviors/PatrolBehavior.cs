using UnityEngine;

public class PatrolBehavior : IBehavior
{
    [SerializeField] private Transform[] _patrolPoints;       // ������ ����� ��������������

    [SerializeField] private float _moveSpeed = 3f;           // �������� �������������� �����
    [SerializeField] private float _pointReachThreshold = 0.5f; // ����������, ��� ������� ���������, ��� ���� ������ �����

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
        // �������� �� ������� ����� ��������������
        if (_patrolPoints.Length == 0)
            return;

        // ���� �������� ������� �����, ��������� � ���������
        if (Vector3.Distance(_enemyTransform.position, _patrolPoints[_currentPointIndex].position) < _pointReachThreshold)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Length; // ������� � ��������� �����
        }

        // ���������� ����� � ������� ������� ���������� �����
        _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, _patrolPoints[_currentPointIndex].position, _moveSpeed * Time.deltaTime);
    }
}
