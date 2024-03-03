using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float moveSpeed = 15;
    public static float leftRightSpeed = 17;
    static public bool canMove = false;
    float originalMoveSpeed; // 이전 코드에서 추가한 변수

    void Start()
    {
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }

            }
        }
    }

    public void IncreaseMoveSpeed()
    {
        moveSpeed += 0.1f;
        if (moveSpeed > 25f) // 최대 속도를 30으로 고정
        {
            moveSpeed = 25f;
        }
    }

    public void ResetMoveSpeed()
    {
        moveSpeed = originalMoveSpeed;
    }
}
