using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rig;
    public float moveSpeed = 1f;
    public float rotateSpeed = 0.2f;
    public List<Transform> enemyList = new List<Transform>();
    public GameObject Bullet;
    public Transform BulletTra;
    public float delayAttack = 1f;
    public float intervalTime = 3f;
    public float nowTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        rig = transform.GetComponent<Rigidbody>();
        nowTime = intervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (JoystickMove.moveInput.magnitude < 0.1f)
        {
            anim.SetBool("run", false); 
            return;
        }
        anim.SetBool("run", true);
        Quaternion dir = Quaternion.LookRotation(JoystickMove.moveInput);
        this.transform.rotation = Quaternion.Lerp(transform.rotation, dir, Time.deltaTime * rotateSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        startAttack();
    }
    private void startAttack()
    {
        if (enemyList != null)
        {
            if (enemyList.Count > 0)
            {
                if(nowTime>= intervalTime)
                {
                    GameObject bullet =GameObject.Instantiate(Bullet, BulletTra);
                    nowTime = 0;
                    Bullet bt = bullet.GetComponent<Bullet>();
                    bt.Init(enemyList[0]);
                }
                nowTime += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("玩家---");
        //if (!enemyList.Contains(other.transform))
        //{
        //    enemyList.Add(other.transform);
        //    print("add--gameobject--" + other.name);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (enemyList.Contains(other.transform))
        //{
        //    enemyList.Remove(other.transform);
        //    print("remove--gameobject--" + other.name);
        //}
    }
}
