using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Time.timeScale = 0f;
        Debug.Log("You Win!");
    }
}
