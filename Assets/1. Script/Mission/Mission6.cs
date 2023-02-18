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
            // 드래그 끝
            if (Input.GetMouseButtonUp(0))
            {
                line.SetPosition(1, new Vector3(0, 0, -10));

                isDrag = false;

            }
        }
    }


    // 미션시작
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

       

    }

    // X버튼 누르면 호출
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }

    // 선 누르면 호츌
    public void ClickLine(LineRenderer click)
    {
        clickPos = Input.mousePosition;
        line = click;

        isDrag = true;
    }

    // 미션 성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
