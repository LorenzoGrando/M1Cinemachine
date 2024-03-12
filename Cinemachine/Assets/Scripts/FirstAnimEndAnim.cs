using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAnimEndAnim : MonoBehaviour
{
    [SerializeField]
    private TriggerArea triggerArea;
    [SerializeField]
    private RobPlayerControl robPlayerControl;

    void OnEnable()
    {
        triggerArea.OnEnterTrigger += TriggerStopAnim;
    }

    void OnDisable()
    {
       triggerArea.OnEnterTrigger -= TriggerStopAnim; 
    }

    void TriggerStopAnim() {
        robPlayerControl.ForceEndAnimation();
    }
}
