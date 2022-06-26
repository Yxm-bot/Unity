using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MyData", menuName = "LevelCfg/LevelAsset", order = 1)]
public class LevelCfg : ScriptableObject
{
    //延迟多久开始生成小兵
    public float delayTimeStart = 10f;
    //每个小兵生成间隔时间
    public float intervalTimeStart = 3f;
    //下一波生成小兵间隔
    public float nextTimeStart = 20f;
    //几波  一波几个敌人
    public int[] totalSoldierNum;
}
