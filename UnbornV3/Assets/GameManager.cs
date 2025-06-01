using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.GPUSort;

public class GameManager : MonoBehaviour
{
    public List<Transform> Enemies;
    public List<GameObject> CardsPlayer1;
    public List<GameObject> CardsPlayer2;

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


    public GameObject CardSummon(bool isPlayer1)
    {
        int cardTypes;
        int random;

        if (isPlayer1) // pick the platy
        {
            cardTypes = CardsPlayer1.Count;
            random = Random.Range(0, cardTypes);
            return CardsPlayer1[random];
        }
        else
        {
            cardTypes = CardsPlayer1.Count;
            random = Random.Range(0, cardTypes);
            return CardsPlayer1[random];
        }
    }
}
