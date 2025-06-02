using UnityEngine;
using Photon.Pun;

public class spawner : MonoBehaviourPun
{
    public GameObject prefab;

    public void spawn()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject spawn = PhotonNetwork.Instantiate(prefab.name, transform.position, Quaternion.identity);
            GameManager.Instance.Enemies.Add(spawn.transform);
        }
    }
}