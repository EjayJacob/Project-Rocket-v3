using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody _rigidbody;
    float speed = 0f;
    [SerializeField] public float mainthrust = 250f;
    [SerializeField] public float rcsthrust = 100f;
    AudioSource _audioSource;
    bool isSoundPlaying;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        isSoundPlaying = false;
    }

    void Update()
    {
        ProcessInput();
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void ProcessInput()
    {
        float rotationSpeed = rcsthrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            print("Rocket up!!");
            _rigidbody.AddRelativeForce(Vector3.up * mainthrust * Time.deltaTime);
            if (!isSoundPlaying)
            {
                _audioSource.Play();
                isSoundPlaying = true;
            }
        }
        else
        {
            _audioSource.Stop();
            isSoundPlaying = false;
        }

        if (Input.GetKey(KeyCode.A))
            {
                print("Rocket left!!");
                transform.Rotate(Vector3.forward * rotationSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                print("Rocket right!!");
                transform.Rotate(-Vector3.forward * rotationSpeed);
            }
        
    }
}
