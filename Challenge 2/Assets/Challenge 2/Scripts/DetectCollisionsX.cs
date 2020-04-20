using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    public GameObject DogsSnout;

    /// <summary>
    /// Add more dogs if dog hit the balls
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Dog"))
        {
            PlayerControllerX.Instance.BallHitDog();
        }
    }
}
