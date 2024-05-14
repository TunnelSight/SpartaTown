using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target; //타겟
    public float moveSpeed;
    private Vector3 targetPosition;

    private void Start()
    {
        
    }

    void LateUpdate()
    {
        if (target == null) return;

       
        targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

        
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}