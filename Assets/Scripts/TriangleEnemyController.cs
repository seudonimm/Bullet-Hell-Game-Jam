using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleEnemyController : MonoBehaviour
{
    [SerializeField] Transform shotSpawn;     //where the shot will come from


    [SerializeField] float shotTimer, shotTimerDefault; //interval between which shots will fire

    [SerializeField] int bulletNum;
    [SerializeField] float currentRot, plus, plusInc;

    [SerializeField] bool rotate;
    [SerializeField] GameObject target;
    [SerializeField] float adjustment;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 playerPos; // intial position of the player

    // Start is called before the first frame update
    void Start()
    {
        PlayerEnemyStats.EnemyAtkSpeed = shotTimerDefault;

        target = GameObject.Find("Player");
        //transform.LookAt(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;
        var dir = (Vector2)target.transform.position - (Vector2)transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + adjustment;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        if (shotTimer <= 0 )
        {

            for (int i = 0; i <= bulletNum; i++)
            {


                //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GameObject shot = ObjectPooler.SharedInstance.GetPooledObject(ObjectPooler.SharedInstance.triangleProjectiles);


                if (shot != null)
                {
                    shot.transform.position = shotSpawn.transform.position;
                    shot.transform.rotation = shotSpawn.transform.rotation;
                    shot.SetActive(true);


                }
                
            }
            shotTimer = PlayerEnemyStats.EnemyAtkSpeed;
        }
    }
}
