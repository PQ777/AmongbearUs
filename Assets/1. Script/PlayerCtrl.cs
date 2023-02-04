using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Camera.main.transform.parent = transform;
        Camera.main.transform.localPosition = new Vector3(0, 0, -10);
    }
    private void Update()
    {
        Move();
    }
    // 캐릭터 움직임 관리
    void Move()
    {
        // 클릭했는지 판단
        if (Input.GetMouseButton(0))
        {
            Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f)).normalized;

            transform.position += dir * speed * Time.deltaTime;
        }
    }
}
