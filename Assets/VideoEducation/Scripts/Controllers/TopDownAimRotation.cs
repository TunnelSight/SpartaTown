using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    TopDownCharacterController controller;
    [SerializeField] GameObject[] characters;
    SpriteRenderer characterRenderer;

    private void Awake()
    {
        controller = GetComponent<TopDownCharacterController>();
    }

    private void Start()
    {
        characters[DataManager.instance.characterNum].SetActive(true);
        characterRenderer = characters[DataManager.instance.characterNum].GetComponent<SpriteRenderer>();

        Debug.Log(controller == null);
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f; //Z축이 90도가 넘으면 뒤집어라

        //armRenderer.flipY = characterRenderer.flipX; //활은 상하대칭인데 스태프는 대칭이 아니라서 넣음
        //armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}