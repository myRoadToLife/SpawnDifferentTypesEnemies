using UnityEngine;

public class StalkingBehavior : IActiveBehavior
{
    private float _moveSpeed = 5f;
    private float _stopDistance = 1f;

    private Transform _player;
    private Transform _enemy;

    private bool _isStalkingPlayer;

    public StalkingBehavior(Transform player, Transform enemy)
    {
        _player = player;
        _enemy = enemy;
    }
    public void ActiveAction()
    {
        ChasePlayer();

        Debug.Log("Я преследую!");
    }

    void ChasePlayer()
    {
        // Проверка расстояния до игрока, если враг находится достаточно близко, то он остановится
        if (Vector3.Distance(_enemy.position, _player.position) > _stopDistance)
        {
            // Движение к игроку
            _enemy.position = Vector3.MoveTowards(_enemy.position, _player.position, _moveSpeed * Time.deltaTime);
        }
    }
}
