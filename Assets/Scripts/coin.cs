using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class coin : MonoBehaviour
{
    public GameObject UI;

    void Start() {
        UI = GameObject.Find("GameManager");
    }
    void OnTriggerEnter2D(Collider2D col){

        if (col.CompareTag("Player")) {
           Destroy(gameObject);
           UI.GetComponent<GameManage>().CoinCollect();
        }
    }

}
