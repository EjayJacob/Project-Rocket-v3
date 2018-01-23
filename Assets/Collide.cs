using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    bool toggle;
    void Start()
    {
        print(transform.position);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            toggle = true;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Obstacle") && (!toggle))
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
