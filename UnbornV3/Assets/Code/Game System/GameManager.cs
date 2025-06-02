using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> Enemies;

    [Header("Charicters View")]
    public List<GameObject> Player1CardsUi;
    public List<GameObject> Player2CardsUi;

    [Header("Cards")]
    public List<GameObject> CardsPlayer1;
    public List<GameObject> CardsPlayer2;

    public static GameManager Instance { get; private set; }

    [HideInInspector] public bool isPlayer1;

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

    public void UiActivashon(bool isPlayer1)
    {
        if (isPlayer1 == true)
        {
            for (int i = 0; i < Player1CardsUi.Count; i++)
            {
                Player1CardsUi[i].SetActive(true);
                Player2CardsUi[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < Player1CardsUi.Count; i++)
            {
                Player1CardsUi[i].SetActive(false);
                Player2CardsUi[i].SetActive(true);
            }
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