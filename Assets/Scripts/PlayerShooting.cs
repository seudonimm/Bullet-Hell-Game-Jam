using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform shotSpawn;     //where the shot will come from


    //[SerializeField] GameObject shot;

    [SerializeField] float shotTimer, shotTimerDefault; //interval between which shots will fire
    [SerializeField] float currentRot;

    // Start is called before the first frame update
    void Start()
    {
        PlayerEnemyStats.PlayerRateOfFire = shotTimerDefault;
        currentRot = shotSpawn.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        shotTimerDefault = PlayerEnemyStats.PlayerRateOfFire;

        shotTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && shotTimer <= 0)
        {
            currentRot = shotSpawn.rotation.eulerAngles.z;

            //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            for (int i = 0; i <= PlayerEnemyStats.PlayerShotCount; i++)
            {
                GameObject shot = ObjectPooler.SharedInstance.GetPooledObject(ObjectPooler.SharedInstance.playerProjectiles);

                shotTimer = shotTimerDefault;

                if (shot != null)
                {
                    shot.transform.position = shotSpawn.transform.position;
                    if (i % 2 == 0)
                    {
                        shot.transform.rotation = Quaternion.Euler(0, 0, currentRot += 45 * (i) / (PlayerEnemyStats.PlayerShotCount + 1));
                    }
                    else
                    {
                        shot.transform.rotation = Quaternion.Euler(0, 0, currentRot += 45 * (-i) / (PlayerEnemyStats.PlayerShotCount + 1));
                    }
                    shot.SetActive(true);
                }
            }

        }
    }
}
