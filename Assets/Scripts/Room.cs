using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Room : MonoBehaviour
{
    public bool closeWhenEntered, openWhenEnemiesCleared;
    public GameObject[] doors;

    public List<GameObject> enemies = new List<GameObject>();

    private bool roomActive;

    void Update()
    {
        if(enemies.Count > 0 && roomActive && openWhenEnemiesCleared){
            for(int i=0; i<enemies.Count; i++){
                if(enemies[i] == null){
                    enemies.RemoveAt(i);
                    i--;
                }
            }

            if(enemies.Count == 0){
                foreach(GameObject door in doors){
                    door.SetActive(false);

                    closeWhenEntered = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            CameraController.instance.ChangeTarget(transform);

            if(closeWhenEntered){
                foreach(GameObject door in doors){
                    door.SetActive(true);
                }
            }
        }

        roomActive = true; 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            roomActive = false;
        }
    }

    // public bool doorCloseOnEnter;
    // public bool closeWhenEntered, openWhenEnemiesClear;
    // public GameObject[] doors;

    // public List<GameObject> enemies = new List<GameObject>();

    // void Update()
    // {
    //     if(!(PlayerIsHere() && openWhenEnemiesClear)){
    //         return;
    //     }

    //     for (int i=0; i<enemies.Count; i++){
    //         if(enemies[i] == null){
    //             enemies.RemoveAt(i);
    //             i--;
    //         }
    //     }
        
    //     if(enemies.Count == 0){
    //         RemoveDoors();
    //     }
        
    // }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(!other.CompareTag("Player")){
    //         return;
    //     }

    //     LevelManager.instance.CurrentRoom = this;
    //     MoveCameraToHere();
    //     MaybeActivateDoors();  
    // }

    // private void MaybeActivateDoors(){
    //     if(!doorCloseOnEnter){
    //         return;
    //     }

    //     // foreach(GameObject door in doors){
    //     //     door.SetActive(true);
    //     // }

    //     foreach (var door in doors){
    //         door.SetActive(true);
    //     }
    // }

    // private void MoveCameraToHere(){
    //     // CameraController.instance.ChangeTarget(transform); 
    //     CameraController.instance.SetTarget(transform.position); 
    // }

    // private void RemoveDoors(){
    //     foreach (var door in doors){
    //         door.SetActive(false);
    //     }
    //     doorCloseOnEnter = false;
    // }

    // private bool PlayerIsHere(){
    //     return LevelManager.instance.CurrentRoom == this;
    // }
}
