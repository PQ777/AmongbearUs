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
            // �巡��
            if (isDrag)
            {
                handle.position = Input.mousePosition;
                rect_handle.anchoredPosition = new Vector2(184, Mathf.Clamp(rect_handle.anchoredPosition.y, -195, 195));

                

                // �巡�� ��
                if (Input.GetMouseButtonUp(0))
                {
                    // ���� ���� ü��
                    if(rect_handle.anchoredPosition.y > -5 && rect_handle.anchoredPosition.y < 5)
                    {
                        Invoke("MissionSuccess", 0.2f);
                        isPlay = false;
                    }
                    isDrag = false;
                    
                }
            }

            rotate.eulerAngles = new Vector3(0, 0, 90 * rect_handle.anchoredPosition.y / 195);

            // �� ����
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

    // �̼ǽ���
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        // �ʱ�ȭ
        rand = 0;

        // ����
        rand = Random.Range(-195, 195);
        while(rand >=-10 && rand >=10)
        {
            rand = Random.Range(-195, 195);
        }

        rect_handle.anchoredPosition = new Vector2(184, rand);

        isPlay = true;

    }

    // X��ư ������ ȣ��
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }

    // ������ ������ ȣ��
    public void ClickHandle()
    {
        isDrag = true;
    }

    // �̼� �����ϸ� ȣ��
    public void MissionSuccess()
    {
        ClickCancle();
    }
}