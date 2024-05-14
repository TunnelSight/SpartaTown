using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 요소를 사용하기 위해 필요
using UnityEngine.SceneManagement;

public class ButtonClickHandler : MonoBehaviour
{
    private int selectedNum = 1;

    public InputField inputName;
    public Text errorText;
    public Button decideBtn;
    public GameObject CurrentSelectedCharBox; //클릭하면 ShowCurrentCharPanel 띄우기
    public GameObject ShowSelectCharPanel; //선택창 1,2의 부모 패널
    public GameObject show1;    //선택창: 1번 선택
    public GameObject show2;    //선택창: 2번 선택
    public GameObject char1;    //1번을 선택했을 떄 나올 캐릭터
    public GameObject char2;    //1번을 선택했을 떄 나올 캐릭터

    public GameObject PlayerChar_1; //1번 캐릭터 프리팹
    public GameObject PlayerChar_2; //2번 캐릭터 프리팹


    void Start()
    {
        // 버튼에 OnClick 이벤트 리스너 추가
        decideBtn.onClick.AddListener(OnDecideBtnClick);
        show1.GetComponent<Button>().onClick.AddListener(OnShow1Click);
        show2.GetComponent<Button>().onClick.AddListener(OnShow2Click);
        //CurrentSelectedCharBox.GetComponent<Button>().onClick.AddListener(OnSelectCurrentSelectedCharBox);
    }

    void OnSelectCurrentSelectedCharBox()
    {
        ShowSelectCharPanel.SetActive(true);
    }

    void OnDecideBtnClick() //결정 버튼
    {
        string inputText = inputName.text;

        // 입력 조건 검사
        if (inputText.Length >= 2 && inputText.Length <= 10 && !HasSpecialChars(inputText))
        {

            Vector3 startPosition = Vector3.zero; // 초기 위치
            Quaternion startRotation = Quaternion.identity; // 초기 회전

            // 조건을 만족하면
            SceneManager.LoadScene("MainScene");
            Debug.Log(CharMaker.instance.selectedNum);

            if (CharMaker.instance.selectedNum == 1)
            {
                Instantiate(PlayerChar_1, startPosition, startRotation);
            }
            else if (CharMaker.instance.selectedNum == 2)
            {
                Instantiate(PlayerChar_2, startPosition, startRotation);
            }
        }
        else
        {
            // 조건을 만족하지 못할 경우
            errorText.gameObject.SetActive(true);
            StartCoroutine(DisableAfterSeconds(2));
        }
    }
   

    IEnumerator DisableAfterSeconds(float seconds) //n초 후 비활성화
    {
        yield return new WaitForSeconds(seconds); // n초 대기
        errorText.gameObject.SetActive(false);
    }
    public void OnShow1Click() //캐릭터 1번 선택
    {
        // show1 클릭 시
        char1.SetActive(true);
        char2.SetActive(false);
        ShowSelectCharPanel.SetActive(false);

    }

    public void OnShow2Click() //캐릭터 2번 선택
    {
        // show2 클릭 시
        char1.SetActive(false);
        char2.SetActive(true);
        ShowSelectCharPanel.SetActive(false);
    }

    private bool HasSpecialChars(string str) //특수문자 존재여부 검사
    {
        foreach (char c in str)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}