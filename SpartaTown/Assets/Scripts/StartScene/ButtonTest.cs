using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public GameObject wizzard;
    public GameObject penguin;
    public GameObject SelectBox;
    public GameObject char1;    //1번을 선택했을 떄 나올 캐릭터
    public GameObject char2;    //1번을 선택했을 떄 나올 캐릭터

    public void ActivateObject()
    {
        if (SelectBox != null)
        {
            SelectBox.SetActive(true);
        }
        else
        {
            Debug.LogError("Target object is not assigned.");
        }
    }

    public void OnClickWizzard()
    {
        CharMaker.instance.selectedNum = 1;
        SelectBox.SetActive(false);
        char1.SetActive(true);
        char2.SetActive(false);
    }

    public void OnClickPenguin()
    {
        CharMaker.instance.selectedNum = 2;
        SelectBox.SetActive(false);
        char1.SetActive(false);
        char2.SetActive(true);
    }

}