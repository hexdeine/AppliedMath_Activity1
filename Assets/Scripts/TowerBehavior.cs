using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TowerBehavior : MonoBehaviour
{
    public float towerRange = 10f;
    public float towerViewCone = 0.5f;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange() && isPlayerInView()) {
            player.GetComponent<CubeMovement>().Respawn();
        }
    }

    private bool isPlayerInRange() {
        float distance = computeDistance(player.position, transform.position);
        return distance < towerRange;
    }

    private bool isPlayerInView() {
        Vector3 direction = player.position - transform.position;
        float dotProduct = computeDot(normalizeVectors(direction), transform.forward);

        return dotProduct > towerViewCone;
    }

    float computeDistance(Vector3 player, Vector3 tower) {
        float x = tower.x - player.x;
        float y = tower.y - player.y;
        float z = tower.z - player.z;

        return Mathf.Sqrt(Mathf.Pow((x), 2) + Mathf.Pow((y), 2) + Mathf.Pow((z), 2));
    }

    float computeDot(Vector3 player, Vector3 tower) {
        float x = tower.x * player.x;
        float y = tower.y * player.y;
        float z = tower.z * player.z;

        return x + y + z;
    }

    Vector3 normalizeVectors(Vector3 direction) {
        float m = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2) + Mathf.Pow(direction.z, 2));
        direction.x /= m;
        direction.y /= m;
        direction.z /= m;

        return direction;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 minDirection = transform.TransformDirection(Vector3.forward + new Vector3(towerViewCone, 0, -towerViewCone)) * towerRange;
        Vector3 maxDirection = transform.TransformDirection(Vector3.forward + new Vector3(-towerViewCone, 0, -towerViewCone)) * towerRange;
        Gizmos.DrawRay(transform.position, minDirection);
        Gizmos.DrawRay(transform.position, maxDirection);
    }
}
