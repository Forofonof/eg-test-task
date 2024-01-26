using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputField _inputFieldSpeed;
    [SerializeField] private InputField _inputFieldCount;
    [SerializeField] private InputField _inputFieldDistance;
    [SerializeField] private InputField _inputFieldDelay;

    private int _speed = 2;
    private int _count = 20;
    private int _distance = 10;
    private int _delay = 1;

    public void Initialize()
    {
        Subscribe();
    }

    public int Speed => _speed;
    public int Count => _count;
    public int Distance => _distance;
    public int Delay => _delay;

    private void Subscribe()
    {
        _inputFieldSpeed.onValueChanged.AddListener(OnSpeedUpdated);
        _inputFieldCount.onValueChanged.AddListener(OnCountUpdated);
        _inputFieldDistance.onValueChanged.AddListener(OnDistanceUpdated);
        _inputFieldDelay.onValueChanged.AddListener(OnDelayUpdated);
    }

    private void OnSpeedUpdated(string value)
    {
        if (int.TryParse(value, out _speed))
            Debug.Log($"Speed: {_speed}");
        else
            Debug.Log("Speed is not a number");
    }

    private void OnCountUpdated(string value)
    {
        if (int.TryParse(value, out _count))
            Debug.Log($"Count: {_count}");
        else
            Debug.Log("Count is not a number");
    }

    private void OnDistanceUpdated(string value)
    {
        if (int.TryParse(value, out _distance))
            Debug.Log($"Distance: {_distance}");
        else
            Debug.Log("Distance is not a number");
    }

    private void OnDelayUpdated(string value)
    {
        if (int.TryParse(value, out _delay))
            Debug.Log($"Delay: {_delay}");
        else
            Debug.Log("Delay is not a number");
    }
}