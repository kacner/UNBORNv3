using Photon.Pun;
using UnityEngine;

public class CardSystem : MonoBehaviourPun
{
    public float movmentSystem;
    public float followMouseCurserSpeed;

    public bool home;
    public GameObject playerHand;

    void Start()
    {
        GameObject playerHand = GameObject.FindGameObjectWithTag("Deck");
        Debug.Log("godshotmeforihavefileyouforthelasttime");
       /* if (playerHand != null)
            gameObject.SetActive = false;*/
        home = true;
    }

    void Update()
    {
        if (home && playerHand != null)
            HomingToHand();
    }

    void HomingToHand()
    {
        transform.Rotate(0f, followMouseCurserSpeed * Time.deltaTime, 0f);

        transform.position = Vector3.MoveTowards(
            transform.position,
            playerHand.transform.position,
            movmentSystem * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, playerHand.transform.position) < 0.1f)
        {
            home = false;
            transform.SetParent(playerHand.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}
