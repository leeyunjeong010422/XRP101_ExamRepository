using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    //유니티 에디터에서 Run 실행 시 윈도우에서는 Stack Overflow가 발생하고, MacOS의 유니티에서는 에디터가 강제종료된다.
    //라는 문제는 아래에서 MoveSpeed가 자기 자신을 참조하고 있어서 계속 호출하기 때문이다.
    //public float MoveSpeed
    //{
    //    get => MoveSpeed;
    //    private set => MoveSpeed = value;
    //}

    //이 코드로 수정 _moveSpeed를 호출함으로써 Stack Overflow 해결
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
