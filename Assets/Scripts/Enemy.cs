using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    private GameObject _player;
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
        Vector3 _enemyFollowVector3 = _player.transform.position - transform.position;
        _enemiesRigidbody.AddForce(_speed * Time.deltaTime * _enemyFollowVector3.normalized,
                                                                ForceMode.VelocityChange);
        //_enemiesRigidbody.transform.Translate(_speed * Time.deltaTime 
        //                                                                        * _enemyFollowVector3.normalized);
    }
}
