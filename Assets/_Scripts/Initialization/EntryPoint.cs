using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private InputManager _inputManager;

    private void Start()
    {
        _objectSpawner.Initialize();
        _inputManager.Initialize();
    }
}