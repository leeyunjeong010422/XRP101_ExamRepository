using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    //����Ƽ �����Ϳ��� Run ���� �� �����쿡���� Stack Overflow�� �߻��ϰ�, MacOS�� ����Ƽ������ �����Ͱ� ��������ȴ�.
    //��� ������ �Ʒ����� MoveSpeed�� �ڱ� �ڽ��� �����ϰ� �־ ��� ȣ���ϱ� �����̴�.
    //public float MoveSpeed
    //{
    //    get => MoveSpeed;
    //    private set => MoveSpeed = value;
    //}

    //�� �ڵ�� ���� _moveSpeed�� ȣ�������ν� Stack Overflow �ذ�
    private float _moveSpeed;

    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
