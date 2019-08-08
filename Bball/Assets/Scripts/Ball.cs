using OculusSampleFramework;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int scoreAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, 2f);
        }
    }
}
