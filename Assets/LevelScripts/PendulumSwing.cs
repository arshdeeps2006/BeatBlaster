using UnityEngine;

public class PendulumSwing : MonoBehaviour
{
    public float swingAngle = 30f;
    public float swingSpeed = 2f;
    public float PhaseoffestSet = 0f; // phase offset in radians
    private float startAngle;
    private float phaseOffset;

    void Start()
    {
        startAngle = transform.eulerAngles.z;
        phaseOffset = PhaseoffestSet; // random offset in radians
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed + phaseOffset) * swingAngle;
        transform.rotation = Quaternion.Euler(0, 0, startAngle + angle);
    }
}
