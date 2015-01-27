using UnityEngine;
using System.Collections;

public class ChangeHeartLocation : MonoBehaviour
{
    Vector2 position;

    void Start()
    {
        position = new Vector2(0f, 220f);
    }

    void Update()
    {
        transform.position = position;
    }
}
