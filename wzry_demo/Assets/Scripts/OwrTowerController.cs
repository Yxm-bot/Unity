using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwrTowerController : MonoBehaviour
{
    public float moveUpSpeed=3f;
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject ring;
    public ParticleSystem effect;
    public GameObject blood;
    public float rotateSpeed = 4f;

    public float bulletSpeed = 3f;
    public float hurtNum = 2f;
    // Start is called before the first frame update
    void Start()
    {
        ring.SetActive(false);
        blood.SetActive(false);
        transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion dir = Quaternion.LookRotation(-Camera.main.transform.forward);
        blood.transform.rotation = Quaternion.Lerp(blood.transform.rotation, dir, Time.deltaTime * rotateSpeed);
        if (transform.position.y >= 0)
        {
            blood.SetActive(true);
            return;
        }
        transform.Translate(Vector3.up * moveUpSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("攻击--11111");
        //判断是玩家
        if (other.gameObject.layer ==9)
        {
            print("玩家--11111");
            ring.SetActive(true);
            StartCoroutine("createrSoldier", other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //判断是玩家
        if (other.gameObject.layer == 9)
        {
            ring.SetActive(false);
            StopCoroutine("createrSoldier");
        }
    }

    IEnumerator createrSoldier(Transform other)
    {
        while (true)
        {
            GameObject bult = Instantiate<GameObject>(bullet);
            bult.AddComponent<TowerBulletController>().init(other.transform, bulletSpeed, hurtNum);
            bult.transform.position = bulletPos.position;
            yield return new WaitForSeconds(3f);
        }
        

    }
}
