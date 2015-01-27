using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public string level;
    public bool loadOnClick;
    public float delay;
    float loadTime;

    void Start()
    {
        loadTime = Time.time + delay;
    }

    void Update()
    {
        if (!loadOnClick && Time.time > loadTime) Application.LoadLevel(level);
        else if (loadOnClick) if (Input.GetButtonDown("Jump")) Application.LoadLevel(level);
    }
}
