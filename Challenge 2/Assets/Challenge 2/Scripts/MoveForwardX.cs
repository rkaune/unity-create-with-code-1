using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public static MoveForwardX Instance { get; private set; }
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
