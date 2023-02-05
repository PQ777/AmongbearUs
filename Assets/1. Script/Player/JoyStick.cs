using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1 . ��ƽ �巡�� + ����
// 2. �巡���Ѹ�ŭ ĳ���� �̵�
public class JoyStick : MonoBehaviour
{
    public RectTransform stick, backGround;

    PlayerCtrl playerCtrl_script;
    bool isDrag;
    float limit;
    private void Start()
    {
        playerCtrl_script = GetComponent<PlayerCtrl>();
        limit = backGround.rect.width * 0.5f;
    }
    // ��ƽ�� ������ ȣ��

    private void Update()
    {
        // �巡�� �ϴ� ����
        if(isDrag)
        {
            Vector2 vec = Input.mousePosition - backGround.position;
           stick.localPosition =  Vector2.ClampMagnitude(vec, limit);

            Vector3 dir = (stick.position - backGround.position).normalized;
            transform.position += dir * playerCtrl_script.speed * Time.deltaTime;

            // �巡�� ������
            if (Input.GetMouseButtonUp(0))
            {
                stick.localPosition = new Vector3(0, 0, 0);
                
                isDrag = false;
            }
        }
    }
    public void ClickStick()
    {
        isDrag = true;
    }

}
