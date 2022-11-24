using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private float _detectionResponseTime;

    public bool IsDetected { get; private set; } = false;
    public RogueState State { get; private set; } = RogueState.RunningToTarget;

    private Coroutine _coroutineWaitReactionToDetection;
    private bool _isCoroutineWaitReactionToDetectionRunning = false;

    private void Update()
    {
        if(State == RogueState.ReactionToDetection)
        {
            _coroutineWaitReactionToDetection = StartCoroutine(WaitReactionToDetection(_detectionResponseTime));
            _isCoroutineWaitReactionToDetectionRunning = true;
        }
        else
        {
            if(_isCoroutineWaitReactionToDetectionRunning == true)
            {
                StopCoroutine(_coroutineWaitReactionToDetection);
                _isCoroutineWaitReactionToDetectionRunning = false;
            }
        }
    }

    public void OnDetected()
    {
        State = RogueState.ReactionToDetection;
        IsDetected = true;
    }

    private IEnumerator WaitReactionToDetection(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

        State = RogueState.Detected;
    }
}
