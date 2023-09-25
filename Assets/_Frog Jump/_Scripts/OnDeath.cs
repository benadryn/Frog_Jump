using UnityEngine;

public class OnDeath : MonoBehaviour
{
    public Transform startPos;

    public float resetYPos = -3.0f;

    public static bool IsDead = false;

    public static OnDeath Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (transform.position.y < resetYPos)
        {
            transform.position = startPos.position;
            transform.rotation = Quaternion.identity;
            IsDead = true;
        }
    }
    
}
