using UnityEngine;

public class DieOnContactBehavior : IBehavior
{
    private GameObject _enemyObject;
    private GameObject _enemyDieEffectPrefab;

    public DieOnContactBehavior(GameObject enemyObject, GameObject enemyDieEffect)
    {
        _enemyObject = enemyObject;
        _enemyDieEffectPrefab = enemyDieEffect;
    }

    public void Update()
    {
        if (_enemyDieEffectPrefab != null)
        {
            GameObject particles = Object.Instantiate(_enemyDieEffectPrefab, _enemyObject.transform.position, Quaternion.identity);

            Object.Destroy(_enemyObject);
        }
    }

}
