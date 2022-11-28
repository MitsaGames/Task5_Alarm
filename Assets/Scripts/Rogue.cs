using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private float _detectionResponseTime;

    public RogueState State { get; private set; } = RogueState.RunningToTarget;

    private Coroutine _waitReactionToDetection;
    private bool _isWaitReactionToDetectionRunning = false;

    private void Update()
    {
        if(State == RogueState.ReactionToDetection)
        {
            _waitReactionToDetection = StartCoroutine(WaitReactionToDetection(_detectionResponseTime));
            _isWaitReactionToDetectionRunning = true;
        }
        else
        {
            if(_isWaitReactionToDetectionRunning == true)
            {
                StopCoroutine(_waitReactionToDetection);
                _isWaitReactionToDetectionRunning = false;
            }
        }
    }

    public void OnDetected()
    {
        State = RogueState.ReactionToDetection;
    }

    private IEnumerator WaitReactionToDetection(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

        State = RogueState.Detected;
    }
}
