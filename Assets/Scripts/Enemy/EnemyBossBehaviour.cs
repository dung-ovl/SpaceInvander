using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossBehaviour : GameMonoBehaviour
{
    [SerializeField] private float speed = 0.5f;


    private Vector3 centerPos = new Vector3(0, 3f, 0);
    private Vector3 centerRot = new Vector3(0, 0, 0);
    private Vector3 leftPos = new Vector3(-2, 1, 0);
    private Vector3 leftRot = new Vector3(0, 0, 90f);
    private Vector3 rightPos = new Vector3(2, 1, 0);
    private Vector3 rightRot = new Vector3(0, 0, -90f);



    protected override void Start()
    {
        base.Start();
        this.FirstMovement();
    }
    private void FirstMovement()
    {
        StartCoroutine(DownwardsRoutine());
    }

    private void StateSelector()
    {
        int random = UnityEngine.Random.Range(0, 3);

        switch (random)
        {
            case 0:
                StartCoroutine(DownwardsRoutine());
                break;
            case 1:
                StartCoroutine(LeftToRightRoutine());
                break;
            case 2:
                StartCoroutine(RightToLeftRoutine());
                break;
        }
    }

    private IEnumerator RightToLeftRoutine()
    {
        transform.parent.position = rightPos;
        transform.parent.rotation = Quaternion.Euler(rightRot);

        while (transform.parent.position.x > leftPos.x)
        {
            transform.parent.Translate(Vector3.down * speed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        this.StateSelector();
    }

    private IEnumerator LeftToRightRoutine()
    {
        transform.parent.position = leftPos;
        transform.parent.rotation = Quaternion.Euler(leftRot);

        while (transform.parent.position.x < rightPos.x)
        {
            Debug.Log("i");
            transform.parent.Translate(Vector3.down * speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        this.StateSelector();
    }

    private IEnumerator DownwardsRoutine()
    {
        transform.parent.position = centerPos;
        transform.parent.rotation = Quaternion.Euler(centerRot);

        while (transform.parent.position.y > 1f)
        {
            transform.parent.Translate(Vector3.down * speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(3f);

        while (transform.parent.position.y < 3f)
        {
            transform.parent.Translate(Vector3.up * speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        this.StateSelector();
    }
}
