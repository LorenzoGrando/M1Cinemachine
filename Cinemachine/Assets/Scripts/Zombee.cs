using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Zombee : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private bool isCrawler = false;

    private PlayerMovement player;

    private Animator animator;

    void Start()
    {
        int number = UnityEngine.Random.Range(1,6);

        if(number <= 3) {
            isCrawler = true;
        }
        SetupAnimator();
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        transform.LookAt(player.transform);
        Vector3 dirToPlayer = transform.position - player.transform.position;
        transform.Translate(Time.deltaTime * speed * dirToPlayer.normalized);
    }

    void SetupAnimator() {
        if(animator == null) {
            animator = GetComponent<Animator>();
        }
        animator.SetBool("IsCrawler", isCrawler);
    }
}
