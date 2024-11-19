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
        Debug.Log("코루틴 시작");
        //WaitForSecondsRealtime 이거 팀프로젝트때도 사용한 경험이 있었는데
        //시간을 멈췄을 때 코루틴을 사용하면 코루틴 정상작동 X (WaitForSeconds가 시간을 멈추면 동작하지 않음)
        //WaitForSecondsRealtime으로 해야 코루틴이 돌아감
        yield return new WaitForSecondsRealtime(_deactiveTime);
        _isCoroutineRunning = false;
        Deactivate();
        Time.timeScale = 1f;
    }
}
