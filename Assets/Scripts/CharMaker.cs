using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMaker : MonoBehaviour
{
    public static CharMaker instance = null;

    void Awake()
    {
        //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출
    public static CharMaker Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public int selectedNum = 1;
    public string charName = "";
}
