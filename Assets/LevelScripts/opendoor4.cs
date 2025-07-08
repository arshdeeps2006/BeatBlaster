using UnityEngine;

public class opendoor4 : MonoBehaviour
{
    public Transform player;          // Assign your Player GameObject here
    public float triggerDistanceZ = 10f;
    public float slideDistance = 2f;  // How far the door should slide right
    public float slideSpeed = 3f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * slideDistance;
    }

    void Update()
    {
        float zDistance = Mathf.Abs(player.position.z - transform.position.z);

        if (zDistance <= triggerDistanceZ)
        {
            isOpening = true;
        }

        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, slideSpeed * Time.deltaTime);
        }
    }
}
