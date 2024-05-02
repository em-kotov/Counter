using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay;
    [SerializeField] private int _step;

    private int _count = 0;
    private bool _isActive = false;
    private bool _wasPressed = false;

    private void Start()
    {
        _text.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isActive = !_isActive;
            _wasPressed = true;
        }

        if (_isActive && _wasPressed)
        {
            StartCoroutine(Count(_delay, _step));
            _wasPressed = false;
        }
        else
        {
            StopCoroutine(Count(_delay, _step));
        }
    }

    private IEnumerator Count(float delay, int step)
    {
        var wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            _count += step;
            DisplayCount(_count);

            yield return wait;
        }
    }

    private void DisplayCount(int count)
    {
        _text.text = count.ToString();
    }
}
