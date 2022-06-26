using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public Transform cam;
    public float rotateSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion dir = Quaternion.LookRotation(-Camera.main.transform.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, dir, Time.deltaTime * rotateSpeed);
    }

}
