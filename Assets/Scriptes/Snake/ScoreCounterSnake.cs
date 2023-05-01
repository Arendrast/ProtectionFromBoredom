using UnityEngine;

public class ScoreCounterSnake : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text TextScoreCounter;
    public int Score;

    private void Update()
    {
        if (Time.timeScale == 1)
            TextScoreCounter.text = Score.ToString();
    }
}
