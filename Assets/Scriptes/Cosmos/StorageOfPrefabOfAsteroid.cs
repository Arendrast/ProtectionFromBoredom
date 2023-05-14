using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageOfPrefabOfAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundAsteroid;
    [SerializeField] private GameObject _asteroid;

    public GameObject BackgroundAsteroid => _backgroundAsteroid;
    public GameObject Asteroid => _asteroid;
}
