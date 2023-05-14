using UnityEngine;
using TMPro;
using System.Collections;
public class ScoreCounterCosmos : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCounterText;
    [SerializeField] private TMP_Text _bestResultText;
    
    [SerializeField] private PlayerCosmos _player;
    
    [SerializeField] private float _unitSpeedAddingPoints = 0.05f;
    
    private int _numberPoints;
    private int _bestResult;
    
    private float _timeAddingPoints = 0.5f;
    private float _updateFrequencyOfTimeOfAddingPoints = 15f;

    private void Awake()
    {
        StartCoroutine(nameof(AddingPoints));
        StartCoroutine(nameof(UpdateTimeAddingPoints));
        UpdateBestResultInBegin();
    }
    private void UpdateBestResultInBegin()
    {
        if (PlayerPrefs.HasKey("BestResultCosmos"))
                _bestResult = PlayerPrefs.GetInt("BestResultCosmos");
    }

    private IEnumerator UpdateTimeAddingPoints()
    {
        yield return new WaitForSeconds(_updateFrequencyOfTimeOfAddingPoints);
        _timeAddingPoints -= _unitSpeedAddingPoints;
        StartCoroutine(nameof(UpdateTimeAddingPoints));
    }

    private IEnumerator AddingPoints()
    {
        yield return new WaitForSeconds(_timeAddingPoints);
        _numberPoints++;
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
        if (_player.IsLose)
        {
                SaveBestResult();
                _bestResultText.text = ($"{_bestResult:0000}km");
                StopCoroutine(nameof(AddingPoints));
        }
    }
    private void Equating() => _scoreCounterText.text = $"{_numberPoints:000000}km";
    private void SaveBestResult()
    { 
        if (_numberPoints > _bestResult)
        { 
            _bestResult = _numberPoints; 
            PlayerPrefs.SetInt("BestResultCosmos", _bestResult);
        }
    }
}
