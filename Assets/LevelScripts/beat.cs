using UnityEngine;
using System.Collections;

public class BeatPunchBounce : MonoBehaviour
{
    private float moveDistance = 1.2f;     // Fixed height to rise on each beat
    private float upTime = 0.05f;          // Speed of rising
    private float fallTime = 0.8f;         // Speed of falling
    private float beatInterval = 0.45f;   // Time between beats (1.75 / 3)
    private float setPause = 0.48f;         // Pause after each set

    private Vector3 basePos;
    private Vector3 targetPos;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        basePos = transform.position;
        targetPos = basePos;
        StartCoroutine(BeatPunchLoop());
    }

    void Update()
    {
        // Always fall smoothly back to base position
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, fallTime);
    }

    IEnumerator BeatPunchLoop()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3 currentPos = transform.position;
                Vector3 peakPos = basePos + Vector3.up * moveDistance;

                // If already above the peak, don't rise further
                if (currentPos.y < peakPos.y)
                {
                    float elapsed = 0f;
                    while (elapsed < upTime)
                    {
                        float t = elapsed / upTime;
                        transform.position = Vector3.Lerp(currentPos, peakPos, t);
                        elapsed += Time.deltaTime;
                        yield return null;
                    }
                    transform.position = peakPos;
                }

                // Reset fall target (so it always falls back down)
                targetPos = basePos;

                yield return new WaitForSeconds(beatInterval - upTime);
            }

            yield return new WaitForSeconds(setPause);
        }
    }
}
