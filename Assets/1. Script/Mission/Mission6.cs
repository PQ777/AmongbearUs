using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission6 : MonoBehaviour
{

    Animator anim;
    PlayerCtrl playerCtrl_script;

    Vector2 clickPos;
    LineRenderer line;

    bool isDrag;
 
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        if (isDrag)
        {
            line.SetPosition(1, new Vector3(Input.mousePosition.x - clickPos.x, Input.mousePosition.y - clickPos.y, -10));
            // �巡�� ��
            if (Input.GetMouseButtonUp(0))
            {
                line.SetPosition(1, new Vector3(0, 0, -10));

                isDrag = false;

            }
        }
    }


    // �̼ǽ���
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

       

    }

    // X��ư ������ ȣ��
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }

    // �� ������ ȣ��
    public void ClickLine(LineRenderer click)
    {
        clickPos = Input.mousePosition;
        line = click;

        isDrag = true;
    }

    // �̼� �����ϸ� ȣ��
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
