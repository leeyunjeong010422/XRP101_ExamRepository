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
        _cubeController.SetPosition();
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}
