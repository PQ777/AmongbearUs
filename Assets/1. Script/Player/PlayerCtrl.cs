using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject joyStick;
    public float speed;

    public bool isJoyStick;

    private void Start()
    {
        Camera.main.transform.parent = transform;
        Camera.main.transform.localPosition = new Vector3(0, 0, -10);
    }
    private void Update()
    {
        Move();
    }
    // ĳ���� ������ ����
    void Move()
    {
        if (isJoyStick)
        {
            joyStick.SetActive(true);
        }

        else
        {
            joyStick.SetActive(false);
        }
        // Ŭ���ߴ��� �Ǵ�
        if (Input.GetMouseButton(0))
        {
            Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f)).normalized;

            transform.position += dir * speed * Time.deltaTime;
        }
    }
}
