using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _increasValue = 1;

    private bool _isCounting = false;
    private float _currentValue = 0;
    private Coroutine _counterCoroutine = null;
    private WaitForSeconds _wait = new WaitForSeconds(0.5f);

    public float CurrentValue => _currentValue;

    private void Update()
    {
        ClickVerification();
    }

    private void ClickVerification() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCounter();
            }
            else
            {
                StartCounter();
            }
        }
    }

    private void StartCounter()
    {
        if (_counterCoroutine == null)
        {
            _isCounting = true;
            _counterCoroutine = StartCoroutine(UpdateCounter());
        }
    }

    private void StopCounter()
    {
        if (_counterCoroutine != null)
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;
            _isCounting = false;
        }
    }

    private IEnumerator UpdateCounter ()
    {
        while (true)
        {
            IncreasValue();
            yield return _wait;
        }
    }

    private void IncreasValue()
    {
        _currentValue += _increasValue;
    }
}
