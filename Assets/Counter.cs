using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;

    private bool _isCounting = false;
    private float _currentValue = 0;
    private Coroutine _counterCoroutine = null;
    private WaitForSeconds wait = new WaitForSeconds(0.5f);

    void Update()
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
            _currentValue += 1;
            DisplayTime(_currentValue);
            yield return wait;
        }
    }

    private void DisplayTime(float currentValue)
    {
        _countText.text = currentValue.ToString("");
    }
}
