using System.Collections.Generic;
using UnityEngine;

public class StorageOfStagesOfDestruction : MonoBehaviour
{

    [SerializeField] private Sprite _firstStageOfDestruction;
    [SerializeField] private Sprite _secondStateOfDestruction;
    [SerializeField] private Sprite _thirdStateOfDestruction;
    [SerializeField] private Sprite _fourthStateOfDestruction;
    [SerializeField] private Sprite _fifthStateOfDestruction;

    public Sprite FirstStageOfDestruction => _firstStageOfDestruction;
    public Sprite SecondStageOfDestruction => _secondStateOfDestruction;
    public Sprite ThirdStageOfDestruction => _thirdStateOfDestruction;
    public Sprite FourthStageOfDestruction => _fourthStateOfDestruction;
    public Sprite FifthStageOfDestruction => _fifthStateOfDestruction;
    [Space] [Header("Other")]
    
    [SerializeField] private GameObject _objectofDestruction;
    public GameObject ObjectOfDestruction => _objectofDestruction;
}
