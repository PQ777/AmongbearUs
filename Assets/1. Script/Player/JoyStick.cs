using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1 . 스틱 드래그 + 제한
// 2. 드래그한만큼 캐릭터 이동
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
    // 스틱을 누르면 호출

    private void Update()
    {
        // 드래그 하는 동안
        if(isDrag)
        {
            Vector2 vec = Input.mousePosition - backGround.position;
           stick.localPosition =  Vector2.ClampMagnitude(vec, limit);

            Vector3 dir = (stick.position - backGround.position).normalized;
            transform.position += dir * playerCtrl_script.speed * Time.deltaTime;

            // 드래그 끝나면
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
