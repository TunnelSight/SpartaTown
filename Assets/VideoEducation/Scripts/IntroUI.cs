using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{   
    //OK 버튼을 누르면 인풋 필드에 입력된 이름 가져오기
    public InputField inputField;

    public Sprite[] characterImage;
    public Image selectedCharacter;

    public void ChoiceCharacter(int num)
    {
        selectedCharacter.sprite = characterImage[num];
        DataManager.instance.characterNum = num;
    }

    public void OnClickBtn()
    {
        Debug.Log(inputField.text);
        if (inputField.text.Length < 2 || inputField.text.Length > 10)
        {
            return;
        }

        DataManager.instance.userName = inputField.text;

        SceneManager.LoadScene(1);
    }
}
