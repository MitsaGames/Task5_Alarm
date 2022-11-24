using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rogue), typeof(Animator))]
public class RogueMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _robberyTarget;
    [SerializeField] private Transform _escapeTarget;

    private Rogue _rogue;
    private Animator _animator;

    private void Awake()
    {
        _rogue = GetComponent<Rogue>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_rogue.State == RogueState.ReactionToDetection)
        {
            _animator.SetFloat("speed", 0);
        }
        else
        {
            _animator.SetFloat("speed", _speed);
        }

        if (_rogue.State == RogueState.RunningToTarget || _rogue.State == RogueState.ReactionToDetection)
        {
            transform.position = Vector3.MoveTowards(transform.position, _robberyTarget.position, _speed * Time.deltaTime);
        }
        else if (_rogue.State == RogueState.Detected)
        {
            var directionToEscape = _escapeTarget.position - transform.position;

            transform.rotation = Quaternion.LookRotation(directionToEscape);

            transform.position = Vector3.MoveTowards(transform.position, _escapeTarget.position, _speed * Time.deltaTime);
        }
    }
}
