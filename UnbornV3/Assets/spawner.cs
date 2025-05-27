using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefag;

    public void spawn()
    {
        GameObject spawn = Instantiate(prefag, transform.position, Quaternion.identity);
        GameManager.Instance.Enemies.Add(spawn.transform);
    }
}
