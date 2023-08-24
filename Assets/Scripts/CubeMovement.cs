using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeMovement : MonoBehaviour
{
    float moveX;
    float moveZ;
    public float speed;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void movePlayer() {
        moveX = transform.position.x + Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        moveZ = transform.position.z + Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.position = new Vector3(moveX, transform.position.y, moveZ);
    }

    void detectTower() {

    }
}
