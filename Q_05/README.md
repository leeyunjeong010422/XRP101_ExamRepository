# 5번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 01. Main Scene
- 실행 시, Start 버튼을 누르면 게임매니저를 통해 게임 씬이 로드된다.

### 02. Game Scene
- Go to Main을 누르면 메인 씬으로 이동한다
- `+`버튼을 누르면 큐브 오브젝트의 회전 속도가 증가한다
- `-`버튼을 누르면 큐브 오브젝트의 회전 속도가 감소한다 (-가 될 경우 역방향으로 회전한다)
- Popup 버튼을 누르면 게임 오브젝트가 정지(큐브의 회전이 정지)하며, Popup창을 출력한다. 이 때 출력된 팝업창은 2초 후 자동으로 닫힌다.

### 공통 사항
- 게임 실행 중 씬 전환 시에도 큐브 오브젝트의 회전 속도는 저장되어 있어야 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- 메인씬과 게임씬에서 버튼이 작동되지 않는 오류 발생 --> EventSystem 추가로 해결
- 씬 전환 시에도 회전 속도를 저장하기 위해 https://docs.unity3d.com/kr/2022.3/ScriptReference/PlayerPrefs.GetFloat.html 사용
- 팝업 버튼을 눌렀을 때 큐브가 정지해야 함
  
```  
  if (Time.timeScale > 0)  //게임이 실행중일 때만 회전하도록 함
{
    transform.Rotate(Vector3.up * GameManager.Instance.Score);
}
```
ObjectRotater.cs에 조건을 달아 Time.timeScale = 1일때만 회전하도록 함

- 팝업창이 자동으로 닫히지 않는 문제 --> 팝업창을 열었을 때 Time.timeScale = 0으로 해주는데 게임이 멈추면 코루틴 작동 X
```
yield return new WaitForSecondsRealtime(_deactiveTime);
```
으로 변경해 줌으로써 시간을 멈췄을 때도 코루틴이 정상작동 하도록 수정함

#### 결론: WaitForSeconds는 시간을 멈추면 동작하지 않고 WaitForSecondsRealtime으로 해야 코루틴이 돌아감
