using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineCamCommunicator : MonoBehaviour
{
    [SerializeField]
    private PlayableAsset timelineAsset;
    [SerializeField]
    private CinemachineDollyCart cartObject;
    private float initialActivationTime;
    private float finalAnimationTime;


    private void OnEnable()
    {
        initialActivationTime = Time.time;
        finalAnimationTime = (float)timelineAsset.duration + initialActivationTime;
        StartCoroutine(routine:InterpolateCamPosOnTrack());
    }

    private IEnumerator InterpolateCamPosOnTrack(){
        while(cartObject.m_Position < 1) {
            float tValue = Mathf.InverseLerp(initialActivationTime, finalAnimationTime, Time.time);

            cartObject.m_Position = tValue;
            
            yield return null;
        }
        yield break;
    }
}
