using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum State{
    atk1,
    beaten,
    death,
    defence,
    idle,
    run,
    skill1
}


public class player01Controller : MonoBehaviour
{
    public int moveSpeed = 3;
    
    public float continueTime = 2f;
    public int clickNum = 0;
    private float lastClickedTime = 0;
    private player01Animation player01Animation;
    private Rigidbody2D m_Rigidbody2D;
    private bool move = false;
    private bool defence = false;
    private bool moveable = true;
    
    // Start is called before the first frame update
    void Start()
    {
        player01Animation = GetComponent<player01Animation>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
        ChangeStatus();
    }

    void Move()
    {

        if (moveable)//如果可以移动
        {
            //角色的移动
            if (Input.GetKey(KeyCode.D))
            {
                
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                transform.localScale = new Vector2(1f, 1f);
                move = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                transform.localScale = new Vector2(-1f, 1f);
                move = true;
            }
            else
            {
                m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
                move = false;
            }
        }
       



    }
    //控制状态机的变化
    void ChangeStatus()
    {
        player01Animation.Run(move);
        player01Animation.Defence(defence);
        if (Input.GetKeyDown(KeyCode.J))
        {
            moveable = false;
            player01Animation.Skill1();
        }

        //下蹲的状态变化 
        if (Input.GetKey(KeyCode.S))
        {
            defence = true;
            moveSpeed = 1;
        }
        else
        {
            moveSpeed = 3;
            defence = false;
        }
        if (Input.GetKey(KeyCode.K))
        {
            
            player01Animation.attack1();
            lastClickedTime = Time.time;
            clickNum++;
            Debug.Log(clickNum);
        }
        if (Time.time - lastClickedTime > continueTime)
        {
            clickNum = 0;
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    lastClickedTime = Time.time;
        //    clickNum++;
        //    if (clickNum == 1)
        //    {
        //        GetComponent<Animator>().SetBool("AtkCombo", true);
        //    }

        //    clickNum = Mathf.Clamp(clickNum, 0, 3);
        //}

    }

    public void SkillDown()
    {
        moveable = true;
        player01Animation.Skill1down();
    }

    public void Atk1Down()
    {
        player01Animation.attack1down();
    }
    public void ComboCheck1()
    {
        if (clickNum > 1)
        {
            clickNum = 0;
            player01Animation.attack2();
        }
    }
    public void ComboCheck2()
    {
        if(clickNum>2) player01Animation.attack3();

    }
    public void ComboCheck(int num)
    {
        if (clickNum >= num)
        {

            GetComponent<Animator>().SetBool("AtkCombo", true);
        }
    }
}
