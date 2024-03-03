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
    private int speedUpThreshold = 25; //disrun(����) �� �ö󰥶� ���� �ӵ� ����

    public float maxTimeScale = 1.5f; // �ִ� Time.timeScale ��
    public float timeScaleIncrement = 0.15f; // Time.timeScale ������
    private float savedTimeScale = 1.5f; // ������ ����

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

        if (!StaticData.IsRetry)   // retry ��ư�� ������ �� ĳ���͸� �������� �ʵ���
        {
            PlayerMove.canMove = false;
        }

        if (addingDis) return; // �ڷ�ƾ�� �̹� ���� ���̸� �ٽ� �������� ����

        addingDis = true;
        StartCoroutine(AddDis());
        savedTimeScale = Time.timeScale; // ����

        // ���� �ӵ��� ���� ������ �ϱ� ���� Time.timeScale ���� ������Ŵ
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
            disRun += 1; // �������� 1�� ����
            disDisplay.GetComponent<TMP_Text>().text = "" + disRun;

            if (disRun % speedUpThreshold == 0)
            {
                if (Time.timeScale < maxTimeScale)
                {
                    Time.timeScale += timeScaleIncrement;
                }

                // �ִ� �ӵ��� 30���� ����
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
