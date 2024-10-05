using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Plane : MonoBehaviour
{
    [SerializeField] private CubePool _pool;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Cube cube))
        {
            if (cube.IsTouched == false)
            {
                cube.Paint(Random.ColorHSV());

                StartCoroutine(ReturnCube(cube));
            }
        }
    }

    private IEnumerator ReturnCube(Cube cube)
    {
        int minLifeTime = 2;
        int maxLifeTime = 6;

        int lifeTime = Random.Range(minLifeTime, maxLifeTime);

        yield return new WaitForSeconds(lifeTime);

        _pool.Return(cube);
    }
}