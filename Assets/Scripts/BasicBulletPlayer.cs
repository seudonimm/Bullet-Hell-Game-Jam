using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletPlayer : MonoBehaviour
{
    [SerializeField] Transform _transform;

    [SerializeField] float moveSpeed;

    [SerializeField] Vector2 shotTrajectory;
    [SerializeField] float shotJitter;

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

    }
}
