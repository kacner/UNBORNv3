using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public List<Transform> Enemies;
    public List<GameObject> Cards;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public GameObject CardSummon()
    {
        int cardTypes = Cards.Count;
        int random = Random.Range(0, cardTypes);
        return Cards[random];
    }
}
