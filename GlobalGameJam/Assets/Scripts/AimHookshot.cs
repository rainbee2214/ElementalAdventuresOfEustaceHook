using UnityEngine;
using System.Collections;

public class AimHookshot : MonoBehaviour
{
    public Vector2 mousePosition = Vector2.zero;
    public float z;

    void Start()
    {

    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = Vector2.Distance(mousePosition, transform.position);
        if (x == 0) x = 0.1f;
        float y = mousePosition.y - transform.position.y;
        z = Mathf.Asin(y/x) * 180/Mathf.PI;
        transform.eulerAngles = new Vector3(0f, 0f, z);
    }
}
