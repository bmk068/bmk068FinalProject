using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public float waitForAnyKey = 2f;
    public GameObject anyKeyText;
    public string mainMenuScene;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitForAnyKey > 0){
            waitForAnyKey -= Time.deltaTime;
            if(waitForAnyKey <= 0){
                anyKeyText.SetActive(true);
            }
        }else{
            if(Input.anyKeyDown){
                SceneManager.LoadScene(mainMenuScene);
            }
        }
    }
}



// Room.cs
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;
// using Unity.VisualScripting;

// public class Room : MonoBehaviour
// {
//     public bool closeWhenEntered, openWhenEnemiesCleared;
//     public GameObject[] doors;
//     public List<GameObject> enemies = new List<GameObject>();
//     private bool roomActive;

//     void Update()
//     {
//         if(enemies.Count > 0 && roomActive && openWhenEnemiesCleared){
//             for(int i=0; i<enemies.Count; i++){
//                 if(enemies[i] == null){
//                     enemies.RemoveAt(i);
//                     i--;
//                 }
//             }

//             if(enemies.Count == 0){
//                 foreach(GameObject door in doors){
//                     door.SetActive(false);

//                     closeWhenEntered = false;
//                 }
//             }
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if(other.tag == "Player"){
//             CameraController.instance.ChangeTarget(transform);

//             if(closeWhenEntered){
//                 foreach(GameObject door in doors){
//                     door.SetActive(true);
//                 }
//             }
//         }

//         roomActive = true; 
//     }

//     private void OnTriggerExit2D(Collider2D other)
//     {
//         if(other.tag == "Player"){
//             roomActive = false;
//         }
//     }
// }
