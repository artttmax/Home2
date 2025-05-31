using TMPro;
using UnityEngine;

public class Viewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Counter _counter;

    void Update()
    {
        DisplayTime(_counter.CurrentValue);
    }

    private void DisplayTime(float currentValue)
    {
        _countText.text = currentValue.ToString("");
    }
}
