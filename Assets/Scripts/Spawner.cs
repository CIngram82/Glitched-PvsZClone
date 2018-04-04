using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	

	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    private bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSeconds = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSeconds * Time.deltaTime /5;
        if (Random.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker =  Instantiate(myGameObject);
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position; 
    }
}
