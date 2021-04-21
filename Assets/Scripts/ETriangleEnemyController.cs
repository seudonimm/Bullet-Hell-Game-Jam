using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETriangleEnemyController : MonoBehaviour
{
    [SerializeField] Transform shotSpawn;     //where the shot will come from
    [SerializeField] float shotTimer, shotTimerDefault; //interval between which shots will fire
    [SerializeField] int bulletNum;
    [SerializeField] GameObject target;
    [SerializeField] float adjustment;
    [SerializeField] float moveSpeed;
    [SerializeField] int shotBurst;
    [SerializeField] Vector3 playerPos; // intial position of the player

    // Start is called before the first frame update
    void Start()
    {
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

        if (shotTimer <= 0)
        {
            //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GameObject shot = ObjectPooler.SharedInstance.GetPooledObject(ObjectPooler.SharedInstance.triangleProjectiles);
                if (shot != null)
                {
                    StartCoroutine(roundBurst());
                    IEnumerator roundBurst()
                    {
                        for (int i =0; i< shotBurst;i++) 
                        { 
                            GameObject shot = ObjectPooler.SharedInstance.GetPooledObject(ObjectPooler.SharedInstance.triangleProjectiles);
                            shot.transform.position = shotSpawn.transform.position;
                            shot.transform.rotation = shotSpawn.transform.rotation;
                            shot.SetActive(true);
                            yield return new WaitForSecondsRealtime(0.5f);
                        }
                    }
                }
            
            shotTimer = shotTimerDefault;
        }
    }
}
