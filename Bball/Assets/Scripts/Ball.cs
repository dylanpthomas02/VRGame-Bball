using OculusSampleFramework;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int scoreAmount;
    bool hit = false;

    private void Awake()
    {
        //transform.hideFlags = HideFlags.None;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !hit)
        {
            hit = true;
            Destroy(gameObject, 2f);
            GameManager.instance.balls--;
        }
    }
}
