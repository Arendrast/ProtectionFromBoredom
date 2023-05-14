using UnityEngine;

public class ScoreCounterSnake : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _textScoreCounter;
    private int _score; 

    private void Update()
    {
        if (Time.timeScale == 1)
            _textScoreCounter.text = _score.ToString();
    }

    public void AddPoint() => _score++;

}
