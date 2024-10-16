using UnityEngine;

public class StalkingBehavior : IBehavior
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
    public void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        // ѕроверка рассто€ни€ до игрока, если враг находитс€ достаточно близко, то он остановитс€
        if (Vector3.Distance(_enemy.position, _player.position) > _stopDistance)
        {
            // ƒвижение к игроку
            _enemy.position = Vector3.MoveTowards(_enemy.position, _player.position, _moveSpeed * Time.deltaTime);
        }
    }
}
