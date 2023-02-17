using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission5 : MonoBehaviour
{
    public Transform rotate, handle;
    public Color blue, red;

    Animator anim;
    PlayerCtrl playerCtrl_script;

    RectTransform rect_handle;
    bool isDrag, isPlay;
    float rand;
 
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rect_handle = handle.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(isPlay)
        {
            // 드래그
            if (isDrag)
            {
                handle.position = Input.mousePosition;
                rect_handle.anchoredPosition = new Vector2(184, Mathf.Clamp(rect_handle.anchoredPosition.y, -195, 195));

                

                // 드래그 끝
                if (Input.GetMouseButtonUp(0))
                {
                    // 성공 여부 체그
                    if(rect_handle.anchoredPosition.y > -5 && rect_handle.anchoredPosition.y < 5)
                    {
                        Invoke("MissionSuccess", 0.2f);
                        isPlay = false;
                    }
                    isDrag = false;
                    
                }
            }

            rotate.eulerAngles = new Vector3(0, 0, 90 * rect_handle.anchoredPosition.y / 195);

            // 색 변경
            if (rect_handle.anchoredPosition.y > -5 && rect_handle.anchoredPosition.y < 5)
            {
                rotate.GetComponent<Image>().color = blue;
                
            }
            else
            {
                rotate.GetComponent<Image>().color = red;
            }
        }

    }

    // 미션시작
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        // 초기화
        rand = 0;

        // 랜덤
        rand = Random.Range(-195, 195);
        while(rand >=-10 && rand >=10)
        {
            rand = Random.Range(-195, 195);
        }

        rect_handle.anchoredPosition = new Vector2(184, rand);

        isPlay = true;

    }

    // X버튼 누르면 호출
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }

    // 손잡이 누르면 호츌
    public void ClickHandle()
    {
        isDrag = true;
    }

    // 미션 성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
