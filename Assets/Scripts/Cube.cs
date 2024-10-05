using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    public bool IsTouched { get; private set; }

    public void Paint(Color color)
    {
        IsTouched = color != Color.white;

        GetComponent<Renderer>().material.color = color;
    }
}