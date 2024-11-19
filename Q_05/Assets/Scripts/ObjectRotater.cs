using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private void Update()
    {
        if (Time.timeScale > 0)  //게임이 실행중일 때만 회전하도록 함
        {
            transform.Rotate(Vector3.up * GameManager.Instance.Score);
        }
    }
}
