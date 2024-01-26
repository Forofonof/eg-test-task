using UnityEngine;
using System;

public class Cube : MonoBehaviour, ICube
{
    public event Action<Cube> OnReachTarget;

    public float Speed { get; private set; }
    public float Distance { get; private set; }

    public void Initialize(float speed, float distance)
    {
        Speed = speed;
        Distance = distance;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += Vector3.forward * Speed * Time.deltaTime;

        HandleDistanceReached();
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
    }

    private void HandleDistanceReached()
    {
        if (transform.position.z >= Distance)
            OnReachTarget?.Invoke(this);
    }
}