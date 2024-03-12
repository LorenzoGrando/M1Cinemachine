using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImelineManager : MonoBehaviour
{
    [SerializeField]
    private TriggerArea triggerZone;
    [SerializeField]
    private GameObject timelineObject;


    void OnEnable()
    {
        triggerZone.OnEnterTrigger += OnTriggerTimeline;
    }

    void OnDisable()
    {
        triggerZone.OnEnterTrigger -= OnTriggerTimeline;
    }

    void OnTriggerTimeline() {
        timelineObject.SetActive(true);
    }
}
