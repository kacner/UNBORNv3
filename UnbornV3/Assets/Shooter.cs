using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject skått;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float ShootCooldown = 0.5f;
    [SerializeField] private List<Transform> targets;
    private void Start()
    {
        targets = GameManager.Instance.Enemies;
    }
    private void FixedUpdate()
    {
        if (target == null)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i] != null)
                {
                    target = targets[i];
                    break;
                }
            }
        }

        if (target == null)
            return;
        Vector2 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.x, targetDir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        if (canShoot)
        StartCoroutine(shoot(targetDir));
    }

    IEnumerator shoot(Vector2 dir)
    {
        canShoot = false;
        GameObject spawn = Instantiate(skått, transform.position, Quaternion.identity);
        spawn.transform.right = dir;
        Rigidbody2D rb = spawn.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * 100);
        yield return new WaitForSeconds(ShootCooldown);
        canShoot = true;
    }
}
