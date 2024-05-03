using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay;
    [SerializeField] private int _step;

    private int _count = 0;
    private Coroutine _countCoroutine;

    private void Start()
    {
        DisplayCount(_count);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_countCoroutine == null)
                Restart();
            else
                Pause();
        }
    }

    private void Restart()
    {
        _countCoroutine = StartCoroutine(Count(_delay, _step));
    }

    private void Pause()
    {
        StopCoroutine(_countCoroutine);
        _countCoroutine = null;
    }

    private IEnumerator Count(float delay, int step)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
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
