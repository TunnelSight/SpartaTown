using TMPro;
using UnityEngine;

public class Playername : MonoBehaviour
{
    TMP_Text nameText;

    private void Start()
    {
        nameText = GetComponent<TMP_Text>();
        nameText.text = DataManager.instance.userName;
    }
}
