using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator animator;
    private BoxCollider col;

    private bool isMoving;
    private bool isSliding;
    private bool isPraying;

    void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<BoxCollider>();
    }

    void Update()
    {
        MovePlayer();
        TryUnslideCollider();
        UpdateAnimator();
    }

    private void MovePlayer() {
        Vector3 inputDirection = new Vector3();
        inputDirection.z = Input.GetAxisRaw("Horizontal");
        
        if(inputDirection.z > 0 ) {
            isMoving = true;
        }
        else {
            isMoving = false;
            inputDirection.z = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            isSliding = true;
            col.center += Vector3.up;
        }


        transform.Translate(inputDirection.normalized * speed * Time.deltaTime );
    }

    private void TryUnslideCollider() {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("OnSlideEnd")) {
            col.center -= Vector3.up;
            isSliding = false;
        }
    }

    private void UpdateAnimator() {
        animator.SetBool("IsRunning", isMoving);
        if(isSliding) {
            animator.SetTrigger("Slide");
        }
        animator.SetBool("IsPraying", isPraying);
        isSliding = false;
    }
}
