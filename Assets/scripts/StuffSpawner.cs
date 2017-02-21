﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    public float velocity;

    public FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;
    public Rigidbody Body { get; private set; }
    public Material stuffMaterial;

    public Stuff[] stuffPrefabs;

    [System.Serializable]
    public struct FloatRange {

        public float min, max;

        public float RandomInRange {
            get {
                return Random.Range(min, max);
            }
        }
    }
           

    float currentSpawnDelay;
    float timeSinceLastSpawn;

    void FixedUpdate () {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay) {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }
    }

    void SpawnStuff () {
        Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
        Stuff spawn = Instantiate<Stuff>(prefab);

        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = Vector3.one * scale.RandomInRange;
        spawn.transform.localRotation = Random.rotation;

        spawn.Body.velocity = transform.up * velocity +
            Random.onUnitSphere * randomVelocity.RandomInRange;
        spawn.Body.angularVelocity =
            Random.onUnitSphere * angularVelocity.RandomInRange;
        spawn.GetComponent<MeshRenderer>().material = stuffMaterial;
    }

}
