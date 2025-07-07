using UnityEngine;

public class songmanager : MonoBehaviour
{
    private AudioSource audiosource;
    private bool hasPlayed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (audiosource == null)
        {
            audiosource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPlayed && transform.position.z >= 72f)
        {
            audiosource.Play();
            hasPlayed = true;
        }
    }
}
