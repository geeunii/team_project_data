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
            StaticData.IsStart = false; // ����� �κ�
            Time.timeScale = 1.0f; // ���� �ӵ� �ʱ�ȭ
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

        // ī��Ʈ �ٿ��� ������ �� �Ŀ� ĳ���͸� ������ �� �ֵ��� PlayerMove.canMove ���� true�� ����
        yield return new WaitForSeconds(1);
        PlayerMove.canMove = true;

        StaticData.IsStart = true;
        StaticData.IsAddingStart = true;
    
        
    }

    private void StartCountdown()
    {
        countCoroutine = StartCoroutine(CountSequence());

        StaticData.IsStart = true; // ������ �κ�

        PlayerMove.moveSpeed = 15f;

        // ī��Ʈ �ٿ��� ���� �Ŀ� LevelDistance ��ũ��Ʈ���� ������ �ö󰡵��� StartAddingDis �Լ� ȣ��
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

        // ī��Ʈ �ٿ��� �ٽ� �����ϱ� ���� ĳ���͸� ������ �� ������ PlayerMove.canMove ���� false�� ����
        PlayerMove.canMove = false;

        countDown3.SetActive(false);
        countDown2.SetActive(false);
        countDown1.SetActive(false);
        countDownGo.SetActive(false);

        LevelDistance levelDistance = GetComponent<LevelDistance>();
        levelDistance.disRun = 0;
        if (!levelDistance.disDisplay.activeSelf) levelDistance.disDisplay.SetActive(true);

        // �ʱ�ȭ �߰�
        StaticData.IsStart = false;
        StaticData.IsAddingStart = false;
        StaticData.IsEnd = false;
        StaticData.IsRetry = true;
        Time.timeScale = 1.0f; // ���� �ӵ� �ʱ�ȭ

        // ī��Ʈ �ٿ��� ���� �Ŀ� ������ �ö󰡵��� LevelDistance ��ũ��Ʈ���� StartAddingDis() �Լ� ȣ��
        StartCountdown();
    }




}
