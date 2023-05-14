using UnityEngine;
using TMPro;
using System.Collections;
public class ScoreCounterRunner : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCounterText;
    [SerializeField] private TMP_Text _bestResultText;
    [SerializeField] private PlayerRunner _playerRunnerScript;

    [SerializeField] private float _unitSpeedAddingPoints = 0.05f;
    
    private float _timeAddingPoints = 1f;
    private float _updateFrequencyOfTimeOfAddingPoints = 15f;
    
    private int _numberPoints;
    private int _bestResult;
    
    private void Awake()
    {
        StartCoroutine(nameof(AddingPoints));
        StartCoroutine(nameof(UpdateTimeAddingPoints));
        UpdateBestResultInBegin();
    }
    
    private void UpdateBestResultInBegin()
    {
        if (PlayerPrefs.HasKey("BestResultRunner"))
                _bestResult = PlayerPrefs.GetInt("BestResultRunner");
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
        if (_playerRunnerScript._isLose)
        {
            SaveBestResult();
            _bestResultText.text = ($"{_bestResult:0000}m");
            StopCoroutine(nameof(AddingPoints));
        }
    }
    
    private IEnumerator UpdateTimeAddingPoints()
    {
        yield return new WaitForSeconds(_updateFrequencyOfTimeOfAddingPoints);
        _timeAddingPoints -= _unitSpeedAddingPoints;
        StartCoroutine(nameof(UpdateTimeAddingPoints));
    }

    private void Equating() => _scoreCounterText.text = $"{_numberPoints:000000}m";
     
    
    private void SaveBestResult()
    {
        if (_numberPoints > _bestResult)
        {
            _bestResult = _numberPoints;
            PlayerPrefs.SetInt("BestResultRunner", _bestResult);
        }
    }
}
