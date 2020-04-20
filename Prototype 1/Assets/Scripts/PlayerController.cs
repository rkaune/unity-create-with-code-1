using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 35f;
    public float TurnSpeed = 30f;
    private float HorizontalInput;
    private float ForwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // movements
        HorizontalInput = Input.GetAxis("Horizontal");
        ForwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * ForwardInput);
        transform.Rotate(Vector3.up, TurnSpeed * HorizontalInput * Time.deltaTime);

    }
}
