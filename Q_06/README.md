# 6번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### FPS 조작 구현
- 실행 시, 마우스 커서가 비활성화되며 마우스 회전으로 플레이어의 시야가 회전한다.
- 현재 바라보고 있는 방향 기준으로 W, A, S, D로 전, 후, 좌, 우 이동을 수행한다
- 마우스 좌클릭 시, 시야 정면 방향으로 레이를 발사하고 레이캐스트에 검출된 적의 이름을 콘솔에 로그로 출력한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- 카메라 위치 수정: 플레이어 자식으로 변경
- 레이캐스트 발사 오류
  1. 레이캐스트를 발사하는 방향도 위치 설정해주었을 때처럼 origin으로 해야 함
  2. _targetLayer가 nothing으로 되어있었음 Enemy로 수정
```
public void Fire(Transform origin)
{ 
    Ray ray = new(origin.position, origin.forward);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, _range, _targetLayer))
    {
        Debug.Log($"{hit.transform.name} Hit!!");
    }
}
```
