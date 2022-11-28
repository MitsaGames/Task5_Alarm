using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rogue), typeof(Animator))]
public class RogueMove : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private Transform _robberyTarget;
    [SerializeField] private Transform _escapeTarget;

    private Rogue _rogue;
    private Animator _animator;
    private float _speed;
    private float _moveThreshold = 0.1f;

    private void Awake()
    {
        _rogue = GetComponent<Rogue>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Transform target = null;
        _speed = _baseSpeed;

        if (_rogue.State == RogueState.RunningToTarget || _rogue.State == RogueState.ReactionToDetection)
        {
            target = _robberyTarget;
        }
        else if (_rogue.State == RogueState.Detected)
        {
            target = _escapeTarget;
        }

        if (target != null)
        {
            var directionToEscape = target.position - transform.position;

            if(directionToEscape != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(directionToEscape);
            }

            if (Vector3.Distance(transform.position, target.position) > _moveThreshold)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
            }
            else
            {
                _speed = 0.0f;
            }

            _animator.SetFloat("speed", _speed);
        }
    }
}
