using System.Collections;
using UnityEngine;
public class DeckSystem : MonoBehaviour
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
        for (int i = cardsAmount; i < cardsMax; i++) // spawns the cards
        {
            GameObject newCard = gameManager.CardSummon(); // gets the card
            if (newCard != null && spawningPoint != null) // summons the card as child
                Instantiate(newCard, spawningPoint.position, spawningPoint.rotation, spawningPoint);
            cardsAmount++;
            yield return new WaitForSeconds(cardsRefreshRateAmount);
        }
        needCards = false;
        isAddingCards = false;
        yield return null;
    }
}