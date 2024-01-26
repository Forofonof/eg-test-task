using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    [Header("References Class")]
    [SerializeField] private InputManager _inputManager;
    [Header("Prefabs")]
    [SerializeField] private GameObject _cubePrefab;

    private PoolBase<GameObject> _cubePool;

    private bool _isSpawnCube = true;

    public void Initialize()
    {
        _cubePool = new PoolBase<GameObject>(Preload, GetAction, ReturnAction, _inputManager.Count);

        StartCoroutine(SpawnCubeDelay());
    }

    public void SpawnObject()
    {
        Cube cube = _cubePool.Get().GetComponent<Cube>();
        cube.Initialize(_inputManager.Speed, _inputManager.Distance);

        Subscribe(cube);
    }

    public GameObject Preload() => Instantiate(_cubePrefab);

    public void DestroyObjects(GameObject cube) => _cubePool.Return(cube);

    public void GetAction(GameObject cube) => cube.SetActive(true);

    public void ReturnAction(GameObject cube) => cube.SetActive(false);

    private void HandleReachTarget(Cube cube)
    {
        cube.Reset();
        DestroyObjects(cube.gameObject);
        Unsubscribe(cube);
    }

    private IEnumerator SpawnCubeDelay()
    {
        while (_isSpawnCube)
        {
            SpawnObject();
            yield return new WaitForSeconds(_inputManager.Delay);
        }
    }

    private void Subscribe(Cube cube) => cube.OnReachTarget += HandleReachTarget;
    private void Unsubscribe(Cube cube) => cube.OnReachTarget -= HandleReachTarget;
}