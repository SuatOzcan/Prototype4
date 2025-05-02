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
        _playersRigidbody.AddForce( _speed * verticalInput * Time.deltaTime * forwardDirection,
                                                            ForceMode.VelocityChange);
    }
}
