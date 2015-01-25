using UnityEngine;
using System.Collections;

public class AimHookshot : MonoBehaviour
{
    public Vector2 mousePosition = Vector2.zero;
    public Vector2 position;

    void Start()
    {

    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePosition);
        transform.LookAt(position);
    }
}
