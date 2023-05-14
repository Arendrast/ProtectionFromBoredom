using System.Collections.Generic;
using UnityEngine;

public class StorageOfLocationOfStars : MonoBehaviour
{
    [SerializeField] private Sprite _firstLocationOfStars;
    [SerializeField] private Sprite _secondLocationOfStars;
    [SerializeField] private Sprite _thirdLocationOfStars;
    [SerializeField] private Sprite _fourthLocationOfStars;
    [SerializeField] private Sprite _fifthLocationOfStars;
    [SerializeField] private Sprite _sixthLocationOfStars;
    [SerializeField] private Sprite _seventhLocationOfStars;
    [SerializeField] private Sprite _eightLocationOfStars;
    public List<Sprite> ListOfStarLocations { get; private set; } = new List<Sprite>();
    public Sprite FirstLocationOfStars => _firstLocationOfStars;
    public Sprite SecondLocationOfStars => _secondLocationOfStars;
    public Sprite ThirdLocationOfStars => _thirdLocationOfStars;
    public Sprite FourthLocationOfStars => _fourthLocationOfStars;
    public Sprite FifthLocationOfStars => _fifthLocationOfStars;
    public Sprite SixthLocationOfStars => _sixthLocationOfStars;
    public Sprite SeventhLocationOfStars => _seventhLocationOfStars;
    public Sprite EighthLocationOfStars => _eightLocationOfStars;

    private void Awake() => AddElementsInList();

    private void AddElementsInList()
    {
        ListOfStarLocations.Add(FirstLocationOfStars);
        ListOfStarLocations.Add(SecondLocationOfStars);
        ListOfStarLocations.Add(ThirdLocationOfStars);
        ListOfStarLocations.Add(FourthLocationOfStars);
        ListOfStarLocations.Add(FifthLocationOfStars);
        ListOfStarLocations.Add(SixthLocationOfStars);
        ListOfStarLocations.Add(SeventhLocationOfStars);
        ListOfStarLocations.Add(EighthLocationOfStars);
    }
}
