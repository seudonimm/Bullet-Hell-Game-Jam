using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletPlayer : MonoBehaviour
{
    [SerializeField] Transform _transform;

    [SerializeField] float moveSpeed;

    [SerializeField] Vector2 shotTrajectory;
    [SerializeField] float shotJitter; //closer this is to 0, the better the accuaracy


    private void Awake()
    {
        PlayerEnemyStats.PlayerAccuracy = shotJitter;
    }
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;

        shotTrajectory = new Vector2(Random.Range(-shotJitter, shotJitter), 1);

    }

    // Update is called once per frame
    void Update()
    {
        _transform.Translate(shotTrajectory * Time.deltaTime * moveSpeed);

        shotJitter = PlayerEnemyStats.PlayerAccuracy;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Destroy Box"))
        {
            gameObject.SetActive(false);
        }
    }
}