using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    private string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        SceneName = "MainScene";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        print("开始游戏");
        SceneManager.LoadScene(SceneName);
    }
}
