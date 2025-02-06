using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // กำหนดความเร็วของศัตรู
    public Vector2 direction = Vector2.left; // กำหนดทิศทางการเคลื่อนที่

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
