using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveDis;
    public GameObject endScreen;

    [SerializeField] private LevelDistance levelDistance;
    [SerializeField] private List<TMP_Text> rankingTexts; // 상위 5개 스코어를 표시할 텍스트 컴포넌트 리스트
    [SerializeField] private TMP_Text currentScoreText; // 현재 스코어를 표시할 텍스트 컴포넌트
    [SerializeField] private TMP_Text lastRecordText; // 직전 기록을 표시할 텍스트 컴포넌트

    private List<int> rankingScores; // 랭킹 점수를 저장하는 리스트

    private int currentScore; // 현재 플레이어의 스코어

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

        rankingScores.Sort((a, b) => b.CompareTo(a)); // 내림차순으로 정렬

        // 상위 5개 스코어 표시
        for (int i = 0; i < rankingTexts.Count; i++)
        {
            if (i < rankingScores.Count)
                rankingTexts[i].text = rankingScores[i].ToString();
            else
                rankingTexts[i].text = "-";
        }

        // 직전 기록 표시
        lastRecordText.text = previousScore.ToString();

        // 이전 스코어 저장
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

