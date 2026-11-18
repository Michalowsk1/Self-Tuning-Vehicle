using UnityEngine;

public class LapChecker : MonoBehaviour
{
    public static bool lapFinished;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            lapFinished = true;
        }
    }
}
