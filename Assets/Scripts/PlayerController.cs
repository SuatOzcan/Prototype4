using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private GameObject _focalPoint;
    private Rigidbody _playersRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _playersRigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 forwardDirection = _focalPoint.transform.forward;
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rightDirection = _focalPoint.transform.right;
        //_playersRigidbody.AddForce( _speed * verticalInput * Time.deltaTime * forwardDirection,
        //                                                    ForceMode.VelocityChange);

        transform.Translate(_speed * verticalInput * Time.deltaTime * forwardDirection);
        // The same controls move both the camera and the ball. Yet, we have more control over the ball
        // than the method using the rigidbody.
        transform.Translate(_speed * horizontalInput* Time.deltaTime * rightDirection);
    }
}
