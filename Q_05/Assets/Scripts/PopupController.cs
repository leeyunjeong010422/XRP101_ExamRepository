using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    private WaitForSeconds _wait;
    private Button _popupButton;

    [SerializeField] private GameObject _popup;

    private bool _isCoroutineRunning = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _popupButton = GetComponent<Button>();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _popupButton.onClick.AddListener(Activate);
    }

    private void Activate()
    {
        if (_isCoroutineRunning) return; 
        _isCoroutineRunning = true;

        _popup.gameObject.SetActive(true);
        GameManager.Instance.Pause();
        StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
    }

    private IEnumerator DeactivateRoutine()
    {
        Debug.Log("�ڷ�ƾ ����");
        //WaitForSecondsRealtime �̰� ��������Ʈ���� ����� ������ �־��µ�
        //�ð��� ������ �� �ڷ�ƾ�� ����ϸ� �ڷ�ƾ �����۵� X (WaitForSeconds�� �ð��� ���߸� �������� ����)
        //WaitForSecondsRealtime���� �ؾ� �ڷ�ƾ�� ���ư�
        yield return new WaitForSecondsRealtime(_deactiveTime);
        _isCoroutineRunning = false;
        Deactivate();
        Time.timeScale = 1f;
    }
}
