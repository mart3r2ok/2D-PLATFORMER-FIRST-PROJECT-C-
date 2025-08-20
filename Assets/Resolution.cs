using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Start()
    {
        Camera.main.orthographicSize = 4.5f * Mathf.Max(16f / 9f / ((float)Screen.width / Screen.height), 1f);
    }
}
