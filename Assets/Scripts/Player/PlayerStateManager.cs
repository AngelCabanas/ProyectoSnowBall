using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public GameObject player;
    public string currentNameMode;

    public GameObject manSkin;
    public GameObject ballSkin;

    public Transform center;

    public GameObject topBall;
    private Vector3 topBallStartPos;
    public GameObject rightArm;
    private Vector3 rightArmStartPos;
    public GameObject leftArm;
    private Vector3 leftArmStartPos;

    void Start()
    {
        topBallStartPos = topBall.transform.localPosition;
        rightArmStartPos = rightArm.transform.localPosition;
        leftArmStartPos = leftArm.transform.localPosition;

        SetMode("Man");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(currentNameMode!= "Ball")
            {
                SetMode("Ball");
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (currentNameMode == "Ball")
            {
                SetMode("Man");
            }
        }
    }

    void SetMode(string nameMode)
    {
        if(nameMode == "Man")
        {
            print("man !");
            currentNameMode = "Man";
            BallTransformationAnimation(false);
        }
        else if(nameMode == "Ball")
        {
            print("ball !");
            currentNameMode = "Ball";
            BallTransformationAnimation(true);
        }
    }

    void BallTransformationAnimation(bool playForward)
    {
        if (playForward)
        {
            //topBall.transform.localPosition = Vector3.Lerp(topBall.transform.localPosition, center.localPosition, 0.5f);
            //rightArm.transform.localPosition = Vector3.Lerp(rightArm.transform.localPosition, center.localPosition, 0.5f);
            //leftArm.transform.localPosition = Vector3.Lerp(leftArm.transform.localPosition, center.localPosition, 0.5f);

            topBall.transform.localPosition = center.localPosition;
            rightArm.transform.localPosition = center.localPosition;
            leftArm.transform.localPosition = center.localPosition;
        }
        else
        {
            //topBall.transform.localPosition = Vector3.Lerp(topBall.transform.localPosition, topBallStartPos, 0.5f);
            //rightArm.transform.localPosition = Vector3.Lerp(rightArm.transform.localPosition, rightArmStartPos, 0.5f);
            //leftArm.transform.localPosition = Vector3.Lerp(leftArm.transform.localPosition, rightArmStartPos, 0.5f);

            topBall.transform.localPosition = topBallStartPos;
            rightArm.transform.localPosition = rightArmStartPos;
            leftArm.transform.localPosition = leftArmStartPos;
        }
    }
}
