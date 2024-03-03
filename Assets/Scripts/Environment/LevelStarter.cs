using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public GameObject fadeIn;
    public AudioSource readyFX;
    public AudioSource goFX;

    private Coroutine countCoroutine;
    void Start()
    {
        if (StaticData.IsRetry)
        {
            Retry();
        }
        else
        {
            StaticData.IsAddingStart = true;
            StaticData.IsEnd = false;
            StaticData.IsRetry = false;
            StaticData.IsStart = false; // 변경된 부분
            Time.timeScale = 1.0f; // 게임 속도 초기화
            StartCountdown();
        }
    }

    public static void Init()
    {
        StaticData.IsStart = false;
        StaticData.IsAddingStart = false;
        StaticData.IsEnd = false;
        StaticData.IsRetry = false;
    }


    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDownGo.SetActive(true);
        goFX.Play();

        // 카운트 다운이 끝나고 난 후에 캐릭터를 움직일 수 있도록 PlayerMove.canMove 값을 true로 설정
        yield return new WaitForSeconds(1);
        PlayerMove.canMove = true;

        StaticData.IsStart = true;
        StaticData.IsAddingStart = true;
    
        
    }

    private void StartCountdown()
    {
        countCoroutine = StartCoroutine(CountSequence());

        StaticData.IsStart = true; // 수정된 부분

        PlayerMove.moveSpeed = 15f;

        // 카운트 다운이 끝난 후에 LevelDistance 스크립트에서 점수가 올라가도록 StartAddingDis 함수 호출
        LevelDistance levelDistance = GetComponent<LevelDistance>();
        if (levelDistance != null)
        {
            levelDistance.disRun = 0;
            if (!levelDistance.disDisplay.activeSelf) levelDistance.disDisplay.SetActive(true);
            levelDistance.StartAddingDis();
        }
    }

    public void Retry()
    {
        if (countCoroutine != null)
        {
            StopCoroutine(countCoroutine);
        }

        // 카운트 다운이 다시 시작하기 전에 캐릭터를 움직일 수 없도록 PlayerMove.canMove 값을 false로 설정
        PlayerMove.canMove = false;

        countDown3.SetActive(false);
        countDown2.SetActive(false);
        countDown1.SetActive(false);
        countDownGo.SetActive(false);

        LevelDistance levelDistance = GetComponent<LevelDistance>();
        levelDistance.disRun = 0;
        if (!levelDistance.disDisplay.activeSelf) levelDistance.disDisplay.SetActive(true);

        // 초기화 추가
        StaticData.IsStart = false;
        StaticData.IsAddingStart = false;
        StaticData.IsEnd = false;
        StaticData.IsRetry = true;
        Time.timeScale = 1.0f; // 게임 속도 초기화

        // 카운트 다운이 끝난 후에 점수가 올라가도록 LevelDistance 스크립트에서 StartAddingDis() 함수 호출
        StartCountdown();
    }




}
