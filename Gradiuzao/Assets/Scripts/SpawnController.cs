using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public GameObject enemyBalance;
    public GameObject enemyShooter;
    public GameObject balanceRotater;
    public GameObject shooterRotater;
    GameObject balance_spawn;
    GameObject balance_spawn2;
    GameObject shooter_spawn;
    int basecounter = 0;
    int counter = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitToSpawn());
	}
	
	// Update is called once per frame
	void Update () {

    }
    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(23);
        StartCoroutine(Spawns());
    }
    IEnumerator Spawns()
    {
        yield return new WaitForSeconds(1.8f); 
        if (!DeathStar.boss)
        {
            balance_spawn = (GameObject)Instantiate(enemyBalance, enemyBalance.transform.position = new Vector3(transform.position.x, Random.Range(transform.position.y + 4.5f, transform.position.y - 2.5f), transform.position.z), enemyBalance.transform.rotation);
            balance_spawn.transform.parent = balanceRotater.transform;
            if (balance_spawn.transform.position.x > 1)
                balance_spawn2 = (GameObject)Instantiate(enemyBalance, enemyBalance.transform.position = new Vector3(transform.position.x, balance_spawn.transform.position.y - 4, transform.position.z), enemyBalance.transform.rotation);
            else
                balance_spawn2 = (GameObject)Instantiate(enemyBalance, enemyBalance.transform.position = new Vector3(transform.position.x, balance_spawn.transform.position.y + 3, transform.position.z), enemyBalance.transform.rotation);
            balance_spawn2.transform.parent = balanceRotater.transform;
        }
        counter += 1;
        if (counter.Equals(3))
        {
            shooter_spawn = (GameObject)Instantiate(enemyShooter, enemyShooter.transform.position = new Vector3(transform.position.x, Random.Range(transform.position.y + 2.5f, transform.position.y - 6), transform.position.z), enemyShooter.transform.rotation);
            shooter_spawn.transform.parent = shooterRotater.transform;
            counter = 0;
        }
        StartCoroutine(Spawns());
    }
}
