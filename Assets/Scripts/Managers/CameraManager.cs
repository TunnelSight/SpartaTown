using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target; //타겟
    public float moveSpeed;
    private Vector3 targetPosition;

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 Pos = target.transform.position;


        targetPosition.Set(Pos.x, Pos.y, this.transform.position.z);
        
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}