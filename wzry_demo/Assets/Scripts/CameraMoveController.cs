using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    public Transform player;
    public Vector3 distanceVec3;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        distanceVec3 = player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position- distanceVec3, moveSpeed * Time.deltaTime);
    }
}
