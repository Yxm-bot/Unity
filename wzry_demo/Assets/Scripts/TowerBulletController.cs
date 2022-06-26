using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletController : MonoBehaviour
{
    //子弹速度和伤害  谁实例化 谁复写;
    public float bulletSpped = 3f;
    public float hurtNum = 4f;
    public Transform enemyPos;
    // Start is called before the first frame update
    public void init(Transform enemy,float speed,float hurt)
    {
        enemyPos = enemy;
        bulletSpped = speed;
        hurtNum = hurt;
    }

    private void Update()
    {
        transform.LookAt(enemyPos.position);
        transform.Translate(Vector3.forward * bulletSpped * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
