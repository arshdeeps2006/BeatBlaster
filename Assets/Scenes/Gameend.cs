using UnityEngine;

public class Gameend : MonoBehaviour
{
    public Transform player;
    public Zmotion PlayerSpeed;
    public float triggerDistanceZ = 0f;
    
    private bool isOpening = false;

    // Update is called once per frame
    void Update()
    {
        float zDistance = Mathf.Abs(player.position.z - transform.position.z);

        if (zDistance <= triggerDistanceZ)
        {
            isOpening = true;
        }

        if (isOpening)
        {
            //displaythescore = true;
            PlayerSpeed.playerSpeed = 0f;
        }
    }
}
