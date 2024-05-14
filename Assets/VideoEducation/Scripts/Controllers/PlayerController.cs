using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;

    private SpriteRenderer spriteRenderer;

    public Transform bow;

    public GameObject[] characters;

    
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        int SelectNum;
        if (DataManager.instance == null) SelectNum = 0; else SelectNum = DataManager.instance.characterNum;
        characters[SelectNum].SetActive(true);
    }

    void Update()
    {   
        //1.유저의 입력을 받아옴
        float x = Input.GetAxisRaw("Horizontal"); //수평 a,d
        float y = Input.GetAxisRaw("Vertical"); //수직 w,s

        //2.입력에 따라 움직임
        transform.position += (new Vector3(x, y)).normalized * speed * Time.deltaTime;

        //(마우스 위치 가져오는방법) 이런 방법이 있음
        //Input.GetAxis("Mouse X");
        //Input.GetAxis("Mouse Y");
        //둘중에 하나
        //Vector3 mousePos = Input.mousePosition;

        //마우스가 스크린 너비의 중간 이상이면 true
        spriteRenderer.flipX = (Input.mousePosition.x < Screen.width / 2);

        //3.활이 바라보게 만들기
        //Vector3.forward 쓰는 이유: z축 회전 시킬려고
        //이렇게 쓰지 말라는 이유: 기능분리를 해야되는데 이렇게 쓰면 기능분리가 안됨
        //써도 될 때 = 프로토타입에서 너무 빨리 테스트해야될 때만
        bow.LookAt((Camera.main.ScreenToWorldPoint(Input.mousePosition)), Vector3.forward);

    }
}
