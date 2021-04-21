using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESquareEnemyController : MonoBehaviour
{
    [SerializeField] Transform shotSpawn;     //where the shot will come from
    [SerializeField] float shotTimer, shotTimerDefault; //interval between which shots will fire
    [SerializeField] int bulletNum;
    [SerializeField] float currentRot, plus, plusInc;
    [SerializeField] bool rotate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;

        if (shotTimer <= 0)
        {

            for (int i = 0; i <= bulletNum; i++)
            {
                //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GameObject shot = ObjectPooler.SharedInstance.GetPooledObject(ObjectPooler.SharedInstance.squareProjectiles);
                if (shot != null)
                {
                    shot.transform.position = shotSpawn.transform.position;
                    shot.transform.rotation = Quaternion.Euler(0, 0, currentRot += 360 / bulletNum);
                    shot.SetActive(true);
                }
            }
            currentRot = 0 + plus;
            if (rotate)
            {
                plus += plusInc;
            }
            shotTimer = shotTimerDefault;

        }
    }
}
