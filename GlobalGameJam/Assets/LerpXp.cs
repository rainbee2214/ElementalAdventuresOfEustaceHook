using UnityEngine;
using System.Collections;

public class LerpXp : MonoBehaviour
{
    float maxScale = 3f;
    float minScale = 0.5f;

    float delta = 0.25f;
    Vector2 scale;
    public bool growing = true;

    void FixedUpdate()
    {
        float currentScale = growing ? maxScale : minScale;
        scale.Set(Mathf.Lerp(transform.localScale.x, currentScale, Time.deltaTime),
                  Mathf.Lerp(transform.localScale.y, currentScale, Time.deltaTime));
        transform.localScale = scale;

        if (growing && transform.localScale.x + delta > currentScale) growing = false;
        else if (!growing && transform.localScale.x - delta < currentScale) growing = true;
    }
}
