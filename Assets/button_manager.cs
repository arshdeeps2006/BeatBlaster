
using UnityEngine;

public class button_manager : MonoBehaviour
{
    public GameObject player;
    public Zmotion motion;
    public GameObject End;
    void Start()
    {
        motion = player.GetComponent<Zmotion>();
    }
    public void begin()
    {
        motion.enabled = true;
        Destroy(gameObject);
    }
    public void quit()
    {
        Application.Quit();
    }
}
