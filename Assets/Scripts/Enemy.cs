using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Rigidbody _enemiesRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _enemiesRigidbody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forceVector3 = _player.transform.position - transform.position;
        _enemiesRigidbody.AddForce( forceVector3 , ForceMode.VelocityChange);
    }
}
