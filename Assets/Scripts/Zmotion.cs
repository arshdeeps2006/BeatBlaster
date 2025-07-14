using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Zmotion : MonoBehaviour
{
    [SerializeField]
    public float playerSpeed = 3f; // Units per second
    private CapsuleCollider colider;
    private bool isSlidingUp = false;
    public GameObject Uiend;
    void Start()
    {
        Uiend.SetActive(false);
        colider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if(transform.position.z <= 360 )
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        else
        Uiend.SetActive(true);

        // Trigger upward slide when z >= 173
        if (!isSlidingUp && transform.position.z >= 173f)
        {
            StartCoroutine(SlideUpY(-4.5f, -3.9f, 0.8f)); // from -4.5 to -3.9 over 1 second
            isSlidingUp = true;
        }
    }

    IEnumerator SlideUpY(float startY, float endY, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float newY = Mathf.Lerp(startY, endY, t);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Snap to exact Y
        transform.position = new Vector3(transform.position.x, endY, transform.position.z);
    }
}
