using System.Collections.Generic;
using UnityEngine;

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

        if (isPlayer1)
        {
            if (CardsPlayer1 == null || CardsPlayer1.Count == 0)
            {
                Debug.LogError("CardsPlayer1 list is null or empty!");
                return null;
            }

            cardTypes = CardsPlayer1.Count;
            random = Random.Range(0, cardTypes);
            return CardsPlayer1[random];
        }
        else
        {
            if (CardsPlayer2 == null || CardsPlayer2.Count == 0)
            {
                Debug.LogError("CardsPlayer2 list is null or empty!");
                return null;
            }

            cardTypes = CardsPlayer2.Count;
            random = Random.Range(0, cardTypes);
            return CardsPlayer2[random];
        }
    }
}