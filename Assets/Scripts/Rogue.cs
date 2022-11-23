using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    public bool IsDetected { get; private set; } = false;

    public void OnDetected()
    {
        IsDetected = true;
    }
}
