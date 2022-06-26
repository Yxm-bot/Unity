using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierContorller : MonoBehaviour
{
    private AiActor ai;
    private Animator anim;
    public GameObject bulletPerfabe;
    public Transform bulletTran;
    public float attackTime=3f;

    public float bulletSpeed = 3f;
    public float hurtNum = 2f;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        ai = transform.GetComponent<AiActor>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        print("防御塔1111");
        //敌方防御塔
        if(other.gameObject.layer==16)
        {
            ai.isStop(true);
            anim.SetBool("atack", true);
            anim.speed = 0.3f;
            StartCoroutine("createrSoldier", other.transform);
        }
    }

    private void contuinMoveNext()
    {
        ai.isStop(false);
    }

 
    //小兵攻击
    IEnumerator createrSoldier(Transform other)
    {
        while (true)
        {
            GameObject bult = Instantiate<GameObject>(bulletPerfabe);
            bult.AddComponent<TowerBulletController>().init(other.transform, bulletSpeed, hurtNum);
            bult.transform.position = bulletTran.position;
            yield return new WaitForSeconds(attackTime);
        }


    }
}
