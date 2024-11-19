using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 SetPoint { get;  set; } //private 제거 (private이면 다른 곳에서 쓸 수 없음)

    public void SetPosition()
    {
        transform.position = SetPoint;
    }
}
