using System.Collections.Generic;
using UnityEngine;

public class StorageOfAsteroidTypes : MonoBehaviour
{
    [SerializeField] private Sprite _firstTypeOfAsteroid;
    [SerializeField] private Sprite _secondTypeOfAsteroid;
    [SerializeField] private Sprite _thirdTypeOfAsteroid;
    [SerializeField] private Sprite _fourthTypeOfAsteroid;
    [SerializeField] private Sprite _fifthTypeOfAsteroid;
    [SerializeField] private Sprite _sixthTypeOfAsteroid;
    [SerializeField] private Sprite _seventhTypeOfAsteroid;
    [SerializeField] private Sprite _eightTypeOfAsteroid;
    public List<Sprite> ListSpritesTypeOfAsteroid { get; private set; } = new List<Sprite>();
    public Sprite FirstTypeOfAsteroid => _firstTypeOfAsteroid;
    public Sprite SecondTypeOfAsteroid => _secondTypeOfAsteroid;
    public Sprite ThirdTypeOfAsteroid => _thirdTypeOfAsteroid;
    public Sprite FourthTypeOfAsteroid => _fourthTypeOfAsteroid;
    public Sprite FifthTypeOfAsteroid => _fifthTypeOfAsteroid;
    public Sprite SixthTypeOfAsteroid => _sixthTypeOfAsteroid;
    public Sprite SeventhTypeOfAsteroid => _seventhTypeOfAsteroid;
    public Sprite EighthTypeOfAsteroid => _eightTypeOfAsteroid;

    private void Awake() => AddElementsInList();

    private void AddElementsInList()
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
}