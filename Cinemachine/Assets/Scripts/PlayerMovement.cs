using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator animator;

    private bool isMoving;
    private bool isSliding;
    private bool isPraying;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        TryUnslide();
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
        }


        transform.Translate(inputDirection.normalized * speed * Time.deltaTime );
    }

    private void TryUnslide() {
        /*
        if(isSliding & !Input.GetKey(KeyCode.Space)) {
            isSliding = false;
        }
        */
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
