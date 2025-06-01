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

        // Disable this component for other players
        if (!photonView.IsMine)
            enabled = false;
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
                GameObject newCard = PhotonNetwork.Instantiate(cardPrefab.name, spawningPoint.position, spawningPoint.rotation);
                newCard.transform.SetParent(spawningPoint); // Optional parenting
            }

            cardsAmount++;
            yield return new WaitForSeconds(cardsRefreshRateAmount);
        }

        needCards = false;
        isAddingCards = false;
        yield return null;
    }
}
