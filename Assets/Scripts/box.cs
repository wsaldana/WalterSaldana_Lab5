using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private Color color;
    public GameObject audioManager;

    void Start()
    {
        color = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.tag == "box") {
                    hit.collider.GetComponent<Rigidbody>().AddForce(-hit.normal*3, ForceMode.Impulse);
                }
            }
        }
    }

    private void OnMouseEnter() {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnMouseExit() {
        GetComponent<MeshRenderer>().material.color = color;
    }

    private void OnTriggerEnter(Collider other) {
        //-132.319
        if (other.gameObject.CompareTag("Player")) {
            if (audioManager) audioManager.GetComponent<audioManager>().playReload();
            Destroy(gameObject);
            GameObject.Find("FirstPersonCharacter").GetComponent<shoot>().reload();
        }
        
    }
}
