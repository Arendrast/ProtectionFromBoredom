using System.Collections.Generic;
using UnityEngine;

public class SegmentsSnake : MonoBehaviour
{
    public List<Transform> SegmentList { get; private set; } = new List<Transform>();
    [SerializeField] private Transform _segmentPrefab;
    private int _initialSize = 4;

    private void Start() => ResetState();
    
    private void FixedUpdate() 
    {
        if (Time.timeScale == 1)
            Move();
    }
    private void Move()
    {
        for (var i = SegmentList.Count - 1; i > 0; i--)
        {
            SegmentList[i].position = SegmentList[i - 1].position;
            SegmentList[i].rotation = SegmentList[i - 1].rotation;
        }
    }
    private void ResetState()
    {
        for (var i = 1; i < SegmentList.Count - 1; i++)
            Destroy(SegmentList[i].gameObject);
        
        SegmentList.Clear();
        SegmentList.Add(gameObject.transform);

            for (var i = 0; i < _initialSize; i++)
                Grow();
    }

    public void Grow()
    {
        var segment = Instantiate(_segmentPrefab);
        segment.position = SegmentList[SegmentList.Count - 1].position;
        SegmentList.Add(segment);
    }
}
