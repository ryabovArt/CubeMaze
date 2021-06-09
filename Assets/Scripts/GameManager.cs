using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ball;
    public GameObject[] startPoint;
    internal int index;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        InstantiateBall();
    }

    private void OnEnable()
    {
        Ball.changeLevel += ChangeIndex;
        Ball.changeLevel += InstantiateBall;
        Ball.instantiateBall += InstantiateBall;
    }

    private void OnDisable()
    {
        Ball.changeLevel -= ChangeIndex;
        Ball.changeLevel -= InstantiateBall;
        Ball.instantiateBall -= InstantiateBall;
    }

    public void InstantiateBall()
    {
        StartCoroutine(InstBall());
    }
    IEnumerator InstBall()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(ball, startPoint[index].transform.position, Quaternion.identity);
    }

    public void ChangeIndex()
    {
        index++;
    }
}
