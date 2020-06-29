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
    public int moveSpeed = 10;
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
            moveSpeed = 2;
        }
        else
        {
            moveSpeed = 5;
            defence = false;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            moveable = false;
            player01Animation.attck1();
        }

    }
    public void SkillDown()
    {
        moveable = true;
        player01Animation.Skill1down();
    }

    public void AtkDown()
    {
        moveable = true;
        player01Animation.attck1down();
    }

}
