using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private void Update()
    {
        if (Time.timeScale > 0)  //������ �������� ���� ȸ���ϵ��� ��
        {
            transform.Rotate(Vector3.up * GameManager.Instance.Score);
        }
    }
}
