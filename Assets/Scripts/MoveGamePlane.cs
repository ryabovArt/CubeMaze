using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGamePlane : MonoBehaviour
{
    public float speed;
    public float speedPlaneRotation;
    public GameObject plane;

    private void OnEnable()
    {
        Ball.changeLevel += RotatePlane;
    }

    private void OnDisable()
    {
        Ball.changeLevel -= RotatePlane;
    }

    private void FixedUpdate()
    {
        MovePlane();
    }

    private void MovePlane()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 10), speed * Time.deltaTime);
        }
        else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -10), speed * Time.deltaTime);
        }
        else if (vertical > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-10, 0, 0), speed * Time.deltaTime);
        }
        else if (vertical < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(10, 0, 0), speed * Time.deltaTime);
        }
        else if (vertical == 0 && horizontal == 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), speed * Time.deltaTime);
        }
    }

    public void RotatePlane()
    {
        StartCoroutine(Rotate());
    }
    IEnumerator Rotate()
    {
        var duration = 0.5f;
        var startTime = Time.time;

        var startRotation = Quaternion.identity;
        var endRotation = Quaternion.Euler(-90f, 0, 0);

        while (true)
        {
            var k = (Time.time - startTime) / duration;

            if (k >= 1) break;

            plane.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, k);

            yield return null;

        }
        //plane.transform.localRotation = endRotation;
    }
}
