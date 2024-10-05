using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
     
    private Stack<Cube> _cubes = new Stack<Cube>();

    public void Return(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.Paint(Color.white);

        _cubes.Push(cube);
    }

    public Cube GetCube(Vector3 position)
    {
        if (_cubes.TryPop(out Cube cube))
        {
            cube.transform.position = position;
            cube.gameObject.SetActive(true);

            return cube;
        }

        return Instantiate(_cubePrefab, position, Quaternion.identity);
    }
}