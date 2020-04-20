using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject DogSnout;
    public Transform SnoutAnchor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Balls"))
        {   // Get location of the dog snout
            other.transform.SetParent(SnoutAnchor);
            other.transform.localPosition = Vector3.zero;

            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
