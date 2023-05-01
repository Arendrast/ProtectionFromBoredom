using System.Collections.Generic;
using UnityEngine;

public class SharedListLibrary : MonoBehaviour
{
    [Header("Sprites Asteroid")] public Sprite FirstTypeOfAsteroid;
    public Sprite SecondTypeOfAsteroid;
    public Sprite ThirdTypeOfAsteroid;
    public Sprite FourthTypeOfAsteroid;
    public Sprite FifthTypeOfAsteroid;
    public Sprite SixthTypeOfAsteroid;
    public Sprite SeventhTypeOfAsteroid;
    public Sprite EighthTypeOfAsteroid;

    [Space] [Header("Sprites Locations Stars")]
    public Sprite FirstLocationOfStars;
    public Sprite SecondLocationOfStars;
    public Sprite ThirdLocationOfStars;
    public Sprite FourthLocationOfStars;
    public Sprite FifthLocationOfStars;
    public Sprite SixthLocationOfStars;
    public Sprite SeventhLocationOfStars;
    public Sprite EighthLocationOfStars;

    [Space] [Header("Stages Of Destruction")]
    public Sprite FirstStageOfDestruction;
    public Sprite SecondStageOfDestruction;
    public Sprite ThirdStageOfDestruction;
    public Sprite FourthStageOfDestruction;
    public Sprite FifthStageOfDestruction;

    [Space] [Header("Lists")]
    public List<Sprite> ListSpritesTypeOfAsteroid;
    public List<GameObject> ListBackground;
    public List<Sprite> ListOfStarLocations;
    [Space] [Header("Other")] public GameObject Asteroid;
    public GameObject BackgroundAsteroid;
    public GameObject ObjectDestruction;

    private void Awake()
    {
        AddingElementsInListSpritesOfTypeAsteroid();
        AddingElementsInListOfStarLocations();
    }
    private void AddingElementsInListSpritesOfTypeAsteroid()
    {
        ListSpritesTypeOfAsteroid.Add(FirstTypeOfAsteroid);
        ListSpritesTypeOfAsteroid.Add(SecondTypeOfAsteroid);
        ListSpritesTypeOfAsteroid.Add(ThirdTypeOfAsteroid);
        ListSpritesTypeOfAsteroid.Add(FourthTypeOfAsteroid); 
        ListSpritesTypeOfAsteroid.Add(FifthTypeOfAsteroid);
        ListSpritesTypeOfAsteroid.Add(SixthTypeOfAsteroid);
        ListSpritesTypeOfAsteroid.Add(SeventhTypeOfAsteroid);
        ListSpritesTypeOfAsteroid.Add(EighthTypeOfAsteroid); 
    }
    private void AddingElementsInListOfStarLocations()
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
