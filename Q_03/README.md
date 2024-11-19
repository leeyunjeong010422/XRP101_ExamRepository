# 3번 문제

주어진 프로젝트 는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Turret
- Trigger 범위 내로 플레이어가 들어왔을 때 1.5초에 한번씩 플레이어를 바라보면서 총알을 발사한다
- Trigger 범위 바깥으로 플레이어가 나가면 발사를 중지한다.
- 오브젝트 풀을 사용해 총알을 관리한다.

### 2. Bullet :
- 20만큼의 힘으로 전방을 향해 발사된다
- 발사 후 5초 경과 시 비활성화 처리된다
- 플레이어를 가격했을 경우 2의 데미지를 준다

### 3. Player
- 총알과 충돌했을 때, 데미지를 입는다
- 체력이 0 이하가 될 경우 효과음을 재생하며 비활성화된다.
- 플레이어의 이동은 씬 뷰를 사용해 이동하도록 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- 총알 발사 오류: 총알에 리지드바디, 콜라이더 추가하여 해결
- 아래 코드에서 NullReferenceException: Object reference not set to an instance of an object 오류 발생
```
private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other
                .GetComponent<PlayerController>()
                .TakeHit(_damageValue);
        }
```
#### 해결코드
PlayerController 할당해줌
```
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        playerController.TakeHit(_damageValue);
    }
}
```

- 범위 밖으로 나가면 Turret 공격 중지 안됨 오류 (공격이 중지되고 있지 않았음)
  - 애초에 범위 밖으로 나갔을 때 발사를 그만두는 코드 로직 존재 X --> 코드 추가로 해결
```
private void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        StopFiring();
    }
}

private void StopFiring()
{
    StopCoroutine(_coroutine);
}
```

- 플레이어 체력 감소 오류
  - 위에서 PlayerController를 할당해 주었는데도 로그를 찍어보니 총알에 닿았을 때 PlayerController 가 null이 떠서 PlayerController의 위치를 player가 아니라 body로 옮김

- 플레이어 사망 효과음 재생 오류
  - Die()에서 소리와 비활성화를 한번에 처리해서 죽으면 비활성화되기때문에 소리 재생X
  - 소리가 끝날 때까지 기다렸다가 끝난 후 비활성화 처리로 수정
```
public void Die()
{
    _audio.Play();
    
    Invoke("PlayerDie", _audio.clip.length);
}

private void PlayerDie()
{
    gameObject.SetActive(false);
}
```

- 플레이어가 비활성화 되었음에도 불구하고 Turret이 계속해서 공격함
  - 공격하는 코루틴에 조건 추가로 해결 (타겟이 활성화 되어있을 때만 실행)
```
target != null && target.gameObject.activeSelf
```

