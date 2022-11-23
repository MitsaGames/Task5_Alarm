using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _enemyDetected = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Триггер сработал ");

        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("Обнаружен объект ");
            _enemyDetected.Invoke();
        }
    }
}
