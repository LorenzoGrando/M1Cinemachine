using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RobPlayerControl : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField]
    private GameObject finalPlayerPos;
    public bool playOnEnable = true;
    Coroutine animRoutine;

    void OnEnable()
    {
        player = FindObjectOfType<PlayerMovement>();
        if(playOnEnable)
            OnTriggerTimeline();
    }

    public void OnTriggerTimeline() {
        player.hasSelfControl = false;
        player.isMoving = true;

        animRoutine = StartCoroutine(routine:InterpolatePlayerToPos(player.speed));
    }

    public void ForceEndAnimation() {
        player.hasSelfControl = true;
        player.isMoving = false;

        StopCoroutine(animRoutine);
    }

    private IEnumerator InterpolatePlayerToPos(float playerSpeed) {
        while(player.transform.position != finalPlayerPos.transform.position) {
            player.transform.position = Vector3.MoveTowards(player.transform.position, finalPlayerPos.transform.position, playerSpeed/60);
            yield return null;
        }
        player.isMoving = false;
        yield return new WaitForSeconds(7.5F);
        player.isPraying = true;
        yield break;
    }
}
