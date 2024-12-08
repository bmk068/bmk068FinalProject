using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Room : MonoBehaviour
{
    public bool closeWhenEntered /*, openWhenEnemiesCleared*/;
    public GameObject[] doors;
    // public List<GameObject> enemies = new List<GameObject>();

    [HideInInspector]
    public bool roomActive;

    public GameObject mapHider;

    void Update(){
        /*if (enemies.Count > 0 && roomActive && openWhenEnemiesCleared){
            for (int i = 0; i < enemies.Count; i++){
                if (enemies[i] == null){
                    enemies.RemoveAt(i);
                    i--;
                }
            }
            if (enemies.Count == 0){
                foreach (GameObject door in doors){
                    door.SetActive(false);
                    closeWhenEntered = false;
                }
            }
        }*/
    }

    public void OpenDoors(){
        foreach (GameObject door in doors){
            door.SetActive(false);
            closeWhenEntered = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            CameraController.instance.ChangeTarget(transform);
            if (closeWhenEntered){
                foreach (GameObject door in doors){
                    door.SetActive(true);
                }
            }
        }
        roomActive = true;

        mapHider.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player"){
            roomActive = false;
        }
    }

    public List<float> GenerateRandomStats(int length){
        float targetSum = length / 2.0f;
        List<float> randomValues = new List<float>(length);
        System.Random rand = new System.Random();

        for (int i = 0; i < length; i++){ // random values
            randomValues.Add((float)rand.NextDouble());
        }
        float currentSum = randomValues.Sum();
        float scaleFactor = targetSum / currentSum;
        for (int i = 0; i < randomValues.Count; i++){
            randomValues[i] *= scaleFactor;
        }
        return randomValues;
    }

    void Start(){
        List<float> stats = GenerateRandomStats(10);
        Debug.Log("Generated Stats List:");
        foreach (float stat in stats){
            Debug.Log(stat);
        }
        Debug.Log("Sum of Generated Stats: " + stats.Sum());
    }
}
