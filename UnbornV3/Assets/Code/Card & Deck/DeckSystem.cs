using System.Collections;
using UnityEngine;
using Photon.Pun;

public class DeckSystem : MonoBehaviourPun
{
    [SerializeField] private GameManager gameManager;
    public int cardsAmount;
    public int cardsMax;
    public float cardsRefreshRateAmount;
    public Transform spawningPoint;

    private bool needCards;
    private bool isAddingCards = false;

    void Start()
    {
        cardsAmount = 0;
        needCards = true;

        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();

        // Add null check for gameManager
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found! Make sure there's a GameManager in the scene.");
            enabled = false;
            return;
        }

        // Add null check for spawning point
        if (spawningPoint == null)
        {
            Debug.LogError("Spawning point is not assigned!");
            enabled = false;
            return;
        }

    }

    void Update()
    {
        if (cardsAmount < cardsMax)
            needCards = true;
        else
            needCards = false;

        if (needCards && !isAddingCards)
            StartCoroutine(AddCardsToDeck());
    }

    IEnumerator AddCardsToDeck()
    {
        isAddingCards = true;

        for (int i = cardsAmount; i < cardsMax; i++)
        {
            bool isPlayer1 = PhotonNetwork.LocalPlayer.ActorNumber == 1;
            GameObject cardPrefab = gameManager.CardSummon(isPlayer1);

            if (cardPrefab != null && spawningPoint != null)
            {
                // Check if the prefab has a PhotonView component
                PhotonView prefabPhotonView = cardPrefab.GetComponent<PhotonView>();
                if (prefabPhotonView == null)
                {
                    Debug.LogError($"Card prefab '{cardPrefab.name}' doesn't have a PhotonView component! " + "Add a PhotonView component to the prefab or use regular Instantiate instead.");

                    GameObject newCard = Instantiate(cardPrefab, spawningPoint.position, spawningPoint.rotation);
                    newCard.transform.SetParent(spawningPoint);
                }
                else
                {
                    // Use PhotonNetwork.Instantiate for networked objects
                    GameObject newCard = PhotonNetwork.Instantiate("Cards/" + cardPrefab.name,spawningPoint.position, spawningPoint.rotation);
                    if (newCard != null)
                    {
                        newCard.transform.SetParent(spawningPoint);
                    }
                    else
                    {
                        Debug.LogError("PhotonNetwork.Instantiate returned null!");
                    }
                }
            }
            else
            {
                if (cardPrefab == null)
                    Debug.LogError("CardSummon returned null prefab!");
                if (spawningPoint == null)
                    Debug.LogError("Spawning point is null!");
            }

            cardsAmount++;
            yield return new WaitForSeconds(cardsRefreshRateAmount);
        }

        needCards = false;
        isAddingCards = false;
    }
}