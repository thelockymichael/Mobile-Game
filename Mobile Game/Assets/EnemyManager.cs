using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject frog;                // prefab von Shark
    public GameObject instanceFrog;        // globale Instanzvariable von Shark
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public float spawnTime = 3f;            // How long between each spawn.
    public int maximumFrogs = 2;
    private int currentFrogs;
    public int healthFrog; // current Health von Shark
    public int startingHealthFrog = 200;
    public float sinkSpeed = 2.5f;
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        healthFrog  = startingHealthFrog ;
        currentFrogs  = 0;
    }


    void Update()
    {
        if (currentFrogs  <= maximumFrogs)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
        Debug.Log(currentFrogs);

        if (healthFrog <= 0)
        {  //tot
            Death();
            Debug.Log("Frog died");
        }
        Debug.Log(healthFrog);
    }


    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        instanceFrog  = Instantiate(instanceFrog , spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;

        currentFrogs  ++;
        if (currentFrogs  >= maximumFrogs )
        {
            CancelInvoke("Spawn");
        }
    }

    public void Damage(int damage)
    {
        healthFrog -= damage;
        Debug.Log("FROG HAS TAKEN DAMAGE");
    }

    public void AddDamageToShark(int neuDamageWert) // Addiere zu damage. Public function, können andre scripts auch aufrufen
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        //healthFrog  -= neuDamageWert;

       
    }

    void Death()
    {

        // The enemy is dead.
        isDead = true;
        currentFrogs --;
        Destroy(instanceFrog);
        Debug.Log("dead?");
        return;
    }
}
