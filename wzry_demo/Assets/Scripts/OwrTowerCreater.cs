using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwrTowerCreater : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] towerArr;
    public string perfabName;
    void Start()
    {
        GameObject towerObj = new GameObject();
        towerObj.name = perfabName;
        foreach (Transform i in towerArr)
        {
            GameObject tower=Instantiate(Resources.Load<GameObject>(perfabName));
            tower.transform.position = i.position;
            tower.transform.parent = towerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
