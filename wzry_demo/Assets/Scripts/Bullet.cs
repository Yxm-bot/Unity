using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform enemy;
    public float moveSpeed = 2f;
    // Start is called before the first frame update

    public void Init(Transform ey)
    {
        enemy = ey;
    }

    private void Update()
    {
        if (enemy != null)
        {
            transform.LookAt(enemy);
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("销毁子弹");
        Destroy(transform);
    }

}
