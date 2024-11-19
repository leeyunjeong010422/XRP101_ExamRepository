using System.Collections;
using UnityEngine;

public class BulletController : PooledBehaviour
{
    [SerializeField] private float _force; //힘 = 20
    [SerializeField] private float _deactivateTime; //비활성화 하는 시간 = 5초
    [SerializeField] private int _damageValue; //데미지 = 2

    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateRoutine());
    }

    //NullReferenceException: Object reference not set to an instance of an object 오류 발생으로 코드 수정
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.TakeHit(_damageValue);
            ReturnPool(); //플레이어랑 충돌 후 총알 반환

        }
    }

    private void Init()
    {
        _wait = new WaitForSeconds(_deactivateTime);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Fire()
    {
        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait;
        ReturnPool();
    }

    public override void ReturnPool()
    {
        Pool.Push(this);
        gameObject.SetActive(false);
    }

    public override void OnTaken<T>(T t)
    {
        if (!(t is Transform)) return;

        transform.LookAt((t as Transform));
        Fire();
    }
}
