using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    private GameObject _focalPoint;
    private Rigidbody _playersRigidbody;
    private bool _hasPowerUp = false;
    private float _powerUpStrength = 100.0f;
    [SerializeField]
    private GameObject _powerUpIndicator;
    [SerializeField]
    private float powerupTimer = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        _playersRigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("FocalPoint");

        // This is how we make an enumerable form an enumerator
        //SimpleCollection simple = new SimpleCollection();
        //foreach (var item in simple)
        //{
        //    //Debug.Log(item);
        //}
        
    }

    // This is how we make an enumerable from an enumerator. The GetEnumerator method is necessary.
    public class SimpleCollection : IEnumerable<WaitForSeconds>  //IEnumerable<T>
    {
        public IEnumerator<WaitForSeconds> GetEnumerator() // IEnumerator>T>
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("This is the first log.");
            yield return new WaitForSeconds(1.0f);
            Debug.Log("This is the second log.");
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 forwardDirection = _focalPoint.transform.forward;
       // float horizontalInput = Input.GetAxis("Horizontal");
        //Vector3 rightDirection = _focalPoint.transform.right;
        _playersRigidbody.AddForce(_speed * verticalInput * Time.deltaTime * forwardDirection,
                                                            ForceMode.Impulse);

        //transform.Translate(_speed * verticalInput * Time.deltaTime * forwardDirection);
        // The same controls move both the camera and the ball. Yet, we have more control over the ball
        // than the method using the rigidbody.
        // transform.Translate(_speed * horizontalInput * Time.deltaTime * rightDirection);

        _powerUpIndicator.transform.position = this.transform.position - new Vector3(0.0f, 0.3f,0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _hasPowerUp = true;
            Destroy(other.gameObject);
            _powerUpIndicator.gameObject.gameObject.SetActive(true);
            //StartCoroutine(nameof(VoidMethodForRoutine));
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && _hasPowerUp == true)
        {
            Rigidbody enemiesRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            //enemiesRigidbody.velocity = _powerUpStrength * awayFromPlayer ;
            enemiesRigidbody.AddForce( _powerUpStrength  * awayFromPlayer, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to: " +
                                _hasPowerUp);

        }
    }

    private IEnumerator PowerUpCountDownRoutine()
    {
        //yield return new WaitForSeconds(1.0f);
        //Debug.Log("First one waited for 1 second.");
        //yield return new WaitForSeconds(2.0f);
        //Debug.Log("The second one. Waited for 2 seconds.");
        //Debug.Log("TIt will wait for 7 seconds now.");
        yield return new WaitForSeconds(powerupTimer);
        _hasPowerUp = false;
        _powerUpIndicator.SetActive(false);
    }
}
