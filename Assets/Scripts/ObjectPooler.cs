using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> playerProjectiles;
    public List<GameObject> triangleProjectiles;
    public List<GameObject> circleProjectiles;
    public List<GameObject> squareProjectiles;

    public GameObject playerProj, triangleProj, circleProj, squareProj;

    public int playerProjAmount, triangleProjAmount, circleProjAmount, squareProjAmount;


    void Awake()
    {
        SharedInstance = this;

    }

    // Start is called before the first frame update
    private void Start()
    {

        playerProjectiles = new List<GameObject>(playerProjAmount);
        triangleProjectiles = new List<GameObject>(triangleProjAmount);
        circleProjectiles = new List<GameObject>(circleProjAmount);
        squareProjectiles = new List<GameObject>(squareProjAmount);

        PoolObjects(playerProjectiles, playerProjAmount, playerProj);
        PoolObjects(triangleProjectiles, triangleProjAmount, triangleProj);
        PoolObjects(circleProjectiles, circleProjAmount, circleProj);
        PoolObjects(squareProjectiles, squareProjAmount, squareProj);

    }


    public void PoolObjects(List<GameObject> pool, int amountToPool, GameObject objectToPool)
    {
        Debug.Log("lkisdjifhlkisjh");


        //pool = new List<GameObject>();

        GameObject tmp;

        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pool.Add(tmp);
        }
    }

    public GameObject GetPooledObject(List<GameObject> pool)
    {
        for (int i = 0; i < pool.Capacity; i++)
        {
            if (!pool[i].activeInHierarchy)
            {

                return pool[i];
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
