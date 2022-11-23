using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rogue))]
public class RogueMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private Rogue _rogue;

    private void Awake()
    {
        _rogue = GetComponent<Rogue>();
    }

    private void Update()
    {
        var direction = _rogue.IsDetected? -1 : 1;

        transform.position = Vector3.MoveTowards(transform.position, _target.position, direction * _speed * Time.deltaTime);
    }
}
