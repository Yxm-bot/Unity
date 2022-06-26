using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public Button btnStart;
    public void onStartGame()
    {
        btnStart.gameObject.SetActive(false);
    }
}
