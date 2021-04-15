using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform shotSpawn;     //where the shot will come from


    //[SerializeField] GameObject shot;

    [SerializeField] float shotTimer, shotTimerDefault; //interval between which shots will fire

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && shotTimer <= 0)
        {
            //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GameObject shot = ObjectPooler.SharedInstance.GetPooledObject(ObjectPooler.SharedInstance.playerProjectiles);

            shotTimer = shotTimerDefault;

            if (shot != null)
            {
                shot.transform.position = shotSpawn.transform.position;
                shot.transform.rotation = shotSpawn.transform.rotation;
                shot.SetActive(true);
            }
        }
    }
}
