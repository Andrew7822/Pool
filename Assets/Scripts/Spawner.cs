using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private int _sleepingFrequency;

    public void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            SpawnCube();
            yield return new WaitForSeconds(_sleepingFrequency);
        }
    }

    private void SpawnCube()
    {
        int spawningHeight = 15;

        _cubePool.GetCube(GetRandomPosition(transform.position.y + spawningHeight));
    }

    private Vector3 GetRandomPosition(float y)
    {
        float x = Random.Range(transform.position.x - Random.Range(0, _collider.bounds.extents.x), transform.position.x + Random.Range(0, _collider.bounds.extents.x));
        float z = Random.Range(transform.position.z - Random.Range(0, _collider.bounds.extents.z), transform.position.z + Random.Range(0, _collider.bounds.extents.z));

        return new(x, y, z);
    }
}
