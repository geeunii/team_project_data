using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveDis;
    public GameObject endScreen;

    [SerializeField] private LevelDistance levelDistance;
    [SerializeField] private List<TMP_Text> rankingTexts; // ���� 5�� ���ھ ǥ���� �ؽ�Ʈ ������Ʈ ����Ʈ
    [SerializeField] private TMP_Text currentScoreText; // ���� ���ھ ǥ���� �ؽ�Ʈ ������Ʈ
    [SerializeField] private TMP_Text lastRecordText; // ���� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private List<int> rankingScores; // ��ŷ ������ �����ϴ� ����Ʈ

    private int currentScore; // ���� �÷��̾��� ���ھ�

    public IEnumerator EndSequence()
    {
        currentScore = levelDistance.disRun;
        UpdateRanking();

        currentScoreText.text = currentScore.ToString();

        liveDis.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(5);
    }

    private void UpdateRanking()
    {
        rankingScores = GetRankingScores();

        int previousScore = PlayerPrefs.GetInt("PreviousScore");
        if (previousScore != 0 && !rankingScores.Contains(previousScore))
        {
            rankingScores.Add(previousScore);
        }

        if (!rankingScores.Contains(currentScore))
            rankingScores.Add(currentScore);

        rankingScores.Sort((a, b) => b.CompareTo(a)); // ������������ ����

        // ���� 5�� ���ھ� ǥ��
        for (int i = 0; i < rankingTexts.Count; i++)
        {
            if (i < rankingScores.Count)
                rankingTexts[i].text = rankingScores[i].ToString();
            else
                rankingTexts[i].text = "-";
        }

        // ���� ��� ǥ��
        lastRecordText.text = previousScore.ToString();

        // ���� ���ھ� ����
        PlayerPrefs.SetInt("PreviousScore", currentScore);
        PlayerPrefs.Save();
    }

    private List<int> GetRankingScores()
    {
        List<int> scores = new List<int>();

        if (PlayerPrefs.HasKey("RankingScores"))
        {
            string scoresJson = PlayerPrefs.GetString("RankingScores");
            scores = JsonUtility.FromJson<List<int>>(scoresJson);
        }

        return scores;
    }

    private void SaveRankingScores(List<int> scores)
    {
        string scoresJson = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("RankingScores", scoresJson);
        PlayerPrefs.Save();

        Debug.Log("Saved Ranking Scores: " + scoresJson);
    }
}

