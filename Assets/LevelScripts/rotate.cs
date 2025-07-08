using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private bool spin = false;
    public float rotationSpeed = 25f; // degrees per second
    public GameObject player;

    void Start()
    {
        // Set initial rotation
        transform.rotation = Quaternion.Euler(123.798f, 90f, -90f);
    }

    void Update()
    {
        // Check if the z-distance is 37 and spin hasn't already started
        if (!spin && Mathf.Abs((transform.position.z - player.transform.position.z) - 37f) < 0.1f)
        {
            spin = true;
        }

        if (spin)
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
    }
}
