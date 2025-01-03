# 2번 문제

주어진 프로젝트 내에서 제공된 스크립트(클래스)는 다음의 책임을 가진다
- PlayerStatus : 플레이어 캐릭터가 가지는 기본 능력치를 보관하고, 객체 생성 시 초기화한다
- PlayerMovement : 유저의 입력을 받고 플레이어 캐릭터를 이동시킨다.

프로젝트에는 현재 2가지 문제가 있다.
- 유니티 에디터에서 Run 실행 시 윈도우에서는 Stack Overflow가 발생하고, MacOS의 유니티에서는 에디터가 강제종료된다.
- 플레이어 캐릭터가 X, Z축의 입력을 동시입력 받아서 대각선으로 이동 시 하나의 축 기준으로 움직일 때 보다 약 1.414배 빠르다.

두 가지 문제가 발생한 원인과 해결 방법을 모두 서술하시오.

## 답안
#### 1번 문제 원인과 해결방법
```
public float MoveSpeed
{
    get => MoveSpeed;
    private set => MoveSpeed = value;
}
```
이 코드에서 get, set 메서드가 자기 자신을 참조하고 있기 때문에 무한 호출되는 것
따라서 아래 코드로 수정하여 _moveSpeed를 호출하게 함으로써 Stack Overflow해결
```
private float _moveSpeed;

public float MoveSpeed
{
    get => _moveSpeed;
    set => _moveSpeed = value;
}
```
#### 2번 문제 원인과 해결방법
정규화가 되어 있지 않아 발생하는 문제임
```
direction = direction.normalized;
```
으로 해결
