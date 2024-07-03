using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    private float move = 0.5f;
    private bool isBlocked = false;
   
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Walking_start");
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isBlocked == false){
            transform.Translate(Vector2.right*move*Time.deltaTime);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other){
        animator.SetTrigger("Idle_start");
        isBlocked = true;
    }

}
