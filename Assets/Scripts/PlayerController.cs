using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private GameObject focalPoint;
    private Rigidbody playersRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playersRigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 forwardDirection = focalPoint.transform.forward;
        playersRigidbody.AddForce( speed * verticalInput * Time.deltaTime * forwardDirection,
                                                            ForceMode.VelocityChange);
    }
}
