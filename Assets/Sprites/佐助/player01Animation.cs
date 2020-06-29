using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player01Animation : MonoBehaviour
{
    private Animator animator;
    private Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void attck1()
    {
        animator.SetTrigger("Atk1");
    }
    public void Skill1()
    {
        animator.SetTrigger("Skill1");
    }
    public void Run(bool move)
    {
        if(move)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Defence", false);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    public void Defence(bool defence)
    {
        if(defence)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Defence", true);
        }
        else
        {
            animator.SetBool("Defence", false);
        }
        
    }
    public void Idle()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Defence", false);
    }
}
