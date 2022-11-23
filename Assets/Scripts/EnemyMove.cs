using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _target;

    private void Update()
    {
        var direction = _enemy.IsDetected? -1 : 1;

        transform.position = Vector3.MoveTowards(transform.position, _target.position, direction * _speed * Time.deltaTime);
    }
}
