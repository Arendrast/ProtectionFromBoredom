using UnityEngine;
using TMPro;
using System.Collections;
public class ScoreCounterRunner : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreCounterText;
    [SerializeField] private TMP_Text BestResultText;
    [SerializeField] private PlayerRunner PlayerRunner;
    private int NumberPoints;
    private int BestResult;
    private float TimeAddingPoints = 1f;

    private void Awake()
    {
        StartCoroutine(nameof(AddingPoints));
        StartCoroutine(nameof(UpdateTimeAddingPoints));
        UpdateBestResultInBegin();
    }
    
    private void UpdateBestResultInBegin()
    {
        if (PlayerPrefs.HasKey("BestResultRunner"))
                BestResult = PlayerPrefs.GetInt("BestResultRunner");
    }

    private IEnumerator AddingPoints()
    {
        yield return new WaitForSeconds(TimeAddingPoints);
        NumberPoints++;
        StartCoroutine(nameof(AddingPoints));
    }

    private void Update()
    {
        if (Time.timeScale == 1) 
            Equating();
        
        IsLose();
    }

    private void IsLose()
    {
        if (PlayerRunner.IsLose)
        {
            SaveBestResult();
            BestResultText.text = ($"{BestResult:0000}m");
            StopCoroutine(nameof(AddingPoints));
        }
    }
    
    private IEnumerator UpdateTimeAddingPoints()
    {
        yield return new WaitForSeconds(15);
        TimeAddingPoints -= 0.05f;
        StartCoroutine(nameof(UpdateTimeAddingPoints));
    }

    private void Equating() => ScoreCounterText.text = $"{NumberPoints:000000}m";
     
    
    private void SaveBestResult()
    {
        if (NumberPoints > BestResult)
        {
            BestResult = NumberPoints;
            PlayerPrefs.SetInt("BestResultRunner", BestResult);
        }
    }
}
