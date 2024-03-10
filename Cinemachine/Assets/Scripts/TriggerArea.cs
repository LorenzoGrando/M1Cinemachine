using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public event Action OnEnterTrigger;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {
            Debug.Log("Called trigger");
            OnEnterTrigger?.Invoke();
        }
    }
}
