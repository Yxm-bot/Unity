using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnsoldierCreater : MonoBehaviour
{
    public GameObject perfab;
    public LevelCfg cfg;
    // Start is called before the first frame update
    private GameObject EnemyObj;
    public Transform[] targetTran;
    public int index = 0;
    void Start()
    {
        EnemyObj = new GameObject();
        StartCoroutine("createrSoldier");
    }

    IEnumerator createrSoldier()
    {
        yield return new WaitForSeconds(cfg.delayTimeStart);
        for (var i = 0; i < cfg.totalSoldierNum.Length; i++)
        {
            for(var j=0;j< cfg.totalSoldierNum[i]; j++)
            {
                yield return new WaitForSeconds(cfg.intervalTimeStart);
                GameObject enemy=Instantiate<GameObject>(perfab);
                enemy.name = index+"-enemy-" + i + "--" + j;
                AiActor aiActor=enemy.AddComponent<AiActor>();
                aiActor.InitData(targetTran);
                enemy.transform.position = transform.position;
                enemy.transform.parent = EnemyObj.transform;
            }
            yield return new WaitForSeconds(cfg.nextTimeStart);
        }

    }

}
