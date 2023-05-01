using UnityEngine;
using TMPro;
using System.Collections;
public class ScoreCounterCosmos : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreCounterText;
    [SerializeField] private TMP_Text BestResultText;
    [SerializeField] private PlayerCosmos PlayerCosmos;
    private int NumberPoints;
    private int BestResult;
    private float TimeAddingPoints = 0.5f;

    private void Awake()
    {
        StartCoroutine(nameof(AddingPoints));
        StartCoroutine(nameof(UpdateTimeAddingPoints));
        UpdateBestResultInBegin();
    }
    private void UpdateBestResultInBegin()
    {
        if (PlayerPrefs.HasKey("BestResultCosmos"))
                BestResult = PlayerPrefs.GetInt("BestResultCosmos");
    }

    private IEnumerator UpdateTimeAddingPoints()
    {
        yield return new WaitForSeconds(15);
        TimeAddingPoints -= 0.05f;
        StartCoroutine(nameof(UpdateTimeAddingPoints));
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
        if (PlayerCosmos.IsLose)
        {
                SaveBestResult();
                BestResultText.text = ($"{BestResult:0000}km");
                StopCoroutine(nameof(AddingPoints));
        }
    }
    private void Equating() => ScoreCounterText.text = $"{NumberPoints:000000}km";
    private void SaveBestResult()
    { 
        if (NumberPoints > BestResult)
        { 
            BestResult = NumberPoints; 
            PlayerPrefs.SetInt("BestResultCosmos", BestResult);
        }
    }
}
