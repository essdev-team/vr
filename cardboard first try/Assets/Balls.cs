﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=XDAYS-qYe6Y

public class Balls : MonoBehaviour
{
    public float forceMult = 20;
    private Rigidbody rigidbody;
    int[] positions = new int[] { -1, 1, 3 };

    public GameObject ball;
    private const int ballCount = 3;
    public GameObject[] ballArr = new GameObject[ballCount];
    public int currBall = 0;

    public Balls()
    {

    }

    public Balls(Balls source)
    {
        currBall = source.currBall;
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * - forceMult;

        if (currBall == 0)
        {
            generateNewBall();
            //for (int i = 0; i < ballCount; i++)
            //{
            //    ballArr[i] = ball;
            //}
        }

        print("STARTING!");
    }

    private void OnEnable()
    {
        //generateNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        int randomRegenPosistion = UnityEngine.Random.Range(3, 15);

        rigidbody.velocity = transform.forward * - forceMult;
        if (transform.position.z < -5)
        {
            Respawn();
        } else if (transform.position.z == randomRegenPosistion) {
            print("GENRATING NEW BALL!");
            generateNewBall();
        }

    }

    private void generateNewBall()
    {
        if (currBall < (ballCount - 1))
        {
            currBall++;
            int index = UnityEngine.Random.Range(0, 2);
            int randomX = positions[index];

            int distance = UnityEngine.Random.Range(25, 35);

            //ballArr[currBall % ballCount] = ball;
            print(currBall % ballCount + " -> " + currBall);

            ballArr[currBall % ballCount] = Instantiate(ball, new Vector3(randomX, 1, distance), Quaternion.identity);
        }
    }

    private void Respawn()
    {
        //int index = UnityEngine.Random.Range(0, 2);
        //int randomX = positions[index];

        var oldBall = ballArr[(currBall - 1) % ballCount];
        if (currBall > 0)
        {
            currBall--;
        }

        generateNewBall();
        Destroy(oldBall);

        //transform.position = new Vector3(randomX, 1, 20);
        //Destroy(this);
        //Instantiate(ball, new Vector3(randomX, 1, 20), Quaternion.identity);
    }
}
