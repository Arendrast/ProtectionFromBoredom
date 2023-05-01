using System.Collections.Generic;
using UnityEngine;

public class SegmentsSnake : MonoBehaviour
{
    [SerializeField] private Transform SegmentPrefab;
    public List<Transform> Segments;
    private int InitialSize = 4;

    private void Start() => ResetState();
    
    private void FixedUpdate() 
    {
        if (Time.timeScale == 1)
            Move();
    }
    private void Move()
    {
        for (var i = Segments.Count - 1; i > 0; i--)
        {
            Segments[i].position = Segments[i - 1].position;
            Segments[i].rotation = Segments[i - 1].rotation;
        }
    }
    private void ResetState()
    {
        for (var i = 1; i < Segments.Count; i++)
            Destroy(Segments[i].gameObject);
        
        Segments.Clear();
        Segments.Add(gameObject.transform);

        for (var i = 0; i < InitialSize; i++)
            Grow();
    }

    public void Grow()
    {
        var segment = Instantiate(SegmentPrefab);
        segment.position = Segments[Segments.Count - 1].position;
        Segments.Add(segment);
    }
}
