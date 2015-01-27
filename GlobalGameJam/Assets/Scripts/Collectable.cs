using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
    static Vector2 outOfView = new Vector2(-1000, -1000);

    public virtual void TurnOn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public virtual void Reset()
    {
        gameObject.SetActive(false);
        transform.position = outOfView;
    }
}

