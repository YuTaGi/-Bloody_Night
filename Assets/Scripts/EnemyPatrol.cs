using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundCheck; // จุดตรวจจับพื้น
    public LayerMask groundLayer; // ระบุว่าพื้นเป็นเลเยอร์ไหน
    private bool movingleft = true; // เริ่มต้นเดินไปทางซ้าย

    void Update()
    {
        // ถ้า movingleft เป็น true เดินไปทางซ้าย, ถ้า false เดินไปทางขวา
        float moveDirection = movingleft ? -1 : 1;
        transform.Translate(Vector2.right * speed * Time.deltaTime * moveDirection);

        // ตรวจจับพื้นด้านหน้า
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1.5f, groundLayer);
        if (groundInfo.collider == null)
    {
        Flip();
    }
    
    Debug.DrawRay(groundCheck.position, Vector2.down * 1.5f, Color.red);

    }

    void Flip()
    {
        movingleft = !movingleft; // สลับทิศทาง
        transform.localScale = new Vector3(movingleft ? 1 : -1, 1, 1);
    }
}