using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool IsDetected { get; private set; } = false;

    public void OnDetected()
    {
        IsDetected = true;
    }
}
