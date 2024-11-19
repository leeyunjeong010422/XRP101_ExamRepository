using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    //_cubeSetPoint를 초기화 후에 SetCubePosition를 사용해야 함
    private void Awake()
    {
        _cubeSetPoint = new Vector3(3, 0, 3);
    }

    private void Start()
    {
        CreateCube();

        //SetCubePosition로 큐브 위치 설정
        SetCubePosition(_cubeSetPoint.x, _cubeSetPoint.y, _cubeSetPoint.z);
    }

    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;

        _cubeController.SetPoint = _cubeSetPoint; //여기서 SetPoint에 _cubeSetPoint 값을 미리 설정 후 SetPosition을 호출해야 함
        _cubeController.SetPosition(); //얘가 뭔지 아무 설정없이 바로 사용하고 있음 이렇게 되면 기본값으로 위치 변경
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        //_cubeSetPoint = _cubeController.SetPoint;
        //이 코드를 여기에 이렇게 작성하게 되면 Awake에서 저장된 (3,0,3)이 Start에서 CreateCube();가 호출될 때
        //덮어씌워지기 때문에 (0,0,0)으로 위치를 이동하게 된다.
    }
}
