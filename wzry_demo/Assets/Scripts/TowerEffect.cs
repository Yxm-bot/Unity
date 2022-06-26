using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerEffect : MonoBehaviour
{
    public GameObject effect;
    public Slider blood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //受到敌人攻击
        if (other.gameObject.layer == 17)
        {
            TowerBulletController wBullet=other.gameObject.GetComponent<TowerBulletController>();
            blood.value = (blood.value - wBullet.hurtNum / 100);
            GameObject eff = Instantiate<GameObject>(effect);
            eff.transform.position = transform.position;
            Destroy(eff,1f);
        }
    }

}
