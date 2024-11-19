# 1번 문제

주어진 프로젝트 내에서 CubeManager 객체는 다음의 책임을 가진다
- 해당 객체 생성 시 Cube프리팹의 인스턴스를 생성한다
- Cube 인스턴스의 컨트롤러를 참조해 위치를 변경한다.

제시된 소스코드에서는 큐브 인스턴스 생성 후 아래의 좌표로 이동시키는 것을 목표로 하였다
- x : 3
- y : 0
- z : 3

제시된 소스코드에서 문제가 발생하는 `원인을 모두 서술`하시오.

## 답안
- _cubeSetPoint를 초기화 후에 SetCubePosition를 사용해야 하는데 Awake()나 Start() 부분에서 초기화 시켜주지 않았음
- SetCubePosition로 큐브 위치 설정을 하지도 않고 큐브를 옮기려고 하고 있음
- SetCubePosition()에서 SetPoint에 _cubeSetPoint 값을 미리 설정 후 SetPosition을 호출해야하는데 바로 _cubeController.SetPosition();를 사용하고 있음
- CreateCube()에 _cubeSetPoint = _cubeController.SetPoint;를 하고 있는데 이렇게 하게 되면 Awake에서 저장된 (3,0,3)이 Start에서 CreateCube();가 호출될 때 덮어씌워지기 때문에 (0,0,0)으로 위치를 이동하게 됨 (삭제)
- CubeController.cs에서 set 메소드가 private로 되어 있으면 CubeManager에서 가져다 쓸 수 없음
