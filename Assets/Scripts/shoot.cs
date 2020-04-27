using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class shoot : MonoBehaviour
{

    public Slider healthBar;
    public TextMeshProUGUI healthValue;
    public int count;
    public Button nextLevel;
    public Image aim;

    void Start(){
        count = 0;
        healthBar = GameObject.FindGameObjectWithTag("healthBar").GetComponent<Slider>();
        healthValue = GameObject.FindGameObjectWithTag("healthCounter").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        Ray ray = gameObject.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.tag == "lb_bird") {
                    if (count < 3) {
                        count += 1;
                        updateBar();
                    }
                    hit.collider.gameObject.SetActive(false);
                    //Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void updateBar() {
        if (healthBar) {
            healthBar.value = count;
            healthValue.text = count.ToString() + "/3";
        }
    }
}
