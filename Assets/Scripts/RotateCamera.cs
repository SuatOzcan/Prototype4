using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float reverseDirection = - horizontalinput;
        transform.Rotate( Vector3.up , reverseDirection * _rotationSpeed * Time.deltaTime);
    }
}
