using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public int disRun = 0;
    private bool addingDis = false;
    public float disDelay = 0.35f;
    private float startDelay = 4.6f;
    private int speedUpThreshold = 25; //disrun(점수) 가 올라갈때 마다 속도 관련

    public float maxTimeScale = 1.5f; // 최대 Time.timeScale 값
    public float timeScaleIncrement = 0.15f; // Time.timeScale 증가량
    private float savedTimeScale = 1.5f; // 저장할 변수

    private void Start()
    {
        disRun = 0;
    }

    public void StartAddingDistanceFromLevelStarter()
    {
        StartAddingDis();
    }

    public void StartAddingDis()
    {
        if (!StaticData.IsStart) return;

        if (!StaticData.IsRetry)   // retry 버튼을 눌렀을 때 캐릭터를 움직이지 않도록
        {
            PlayerMove.canMove = false;
        }

        if (addingDis) return; // 코루틴이 이미 실행 중이면 다시 실행하지 않음

        addingDis = true;
        StartCoroutine(AddDis());
        savedTimeScale = Time.timeScale; // 저장

        // 게임 속도를 점점 빠르게 하기 위해 Time.timeScale 값을 증가시킴
        if (Time.timeScale < maxTimeScale)
        {
            Time.timeScale += timeScaleIncrement;
        }

        if (Time.timeScale > maxTimeScale)
        {
            Time.timeScale = maxTimeScale;
        }
    }

    IEnumerator AddDis()
    {
        yield return new WaitForSeconds(startDelay);

        while (!StaticData.IsEnd)
        {
            disRun += 1; // 증가량을 1로 고정
            disDisplay.GetComponent<TMP_Text>().text = "" + disRun;

            if (disRun % speedUpThreshold == 0)
            {
                if (Time.timeScale < maxTimeScale)
                {
                    Time.timeScale += timeScaleIncrement;
                }

                // 최대 속도를 30으로 고정
                if (Time.timeScale > maxTimeScale)
                {
                    Time.timeScale = maxTimeScale;
                }
            }

            yield return new WaitForSeconds(disDelay);
        }

        addingDis = false;
    }
}
