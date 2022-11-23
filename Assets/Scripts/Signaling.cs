using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _enemyDetected = new UnityEvent();
    [SerializeField] private UnityEvent _enemyLost = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue enemy))
        {
            _enemyDetected.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue enemy))
        {
            _enemyLost.Invoke();
        }
    }
}
