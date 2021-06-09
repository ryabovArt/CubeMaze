using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static event Action changeLevel;
    public static event Action instantiateBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fall"))
        {
            Destroy(gameObject);
            instantiateBall?.Invoke();
        }
        if (other.CompareTag("NextLevel"))
        {
            Destroy(gameObject);
            changeLevel?.Invoke();
        }
    }
}
