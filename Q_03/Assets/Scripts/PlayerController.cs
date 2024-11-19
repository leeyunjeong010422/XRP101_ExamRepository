using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    private AudioSource _audio;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    //���� �� �Ҹ�, ��Ȱ��ȭ�� ���� �ع����� �Ҹ� ��� X
    //�Ҹ��� ���� ������ ��ٷȴٰ� ���� �� ��Ȱ��ȭ
    public void Die()
    {
        _audio.Play();
        
        Invoke("PlayerDie", _audio.clip.length);
    }

    private void PlayerDie()
    {
        gameObject.SetActive(false);
    }

    //�÷��̾� �̵�
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * Time.deltaTime * 10f);
    }
}
