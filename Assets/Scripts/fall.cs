using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour{

    public GameObject audioManager;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            if (audioManager) audioManager.GetComponent<audioManager>().playDeath();
    }
}
