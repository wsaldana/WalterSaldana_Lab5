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
    public TextMeshProUGUI killValue;
    public int count;
    public int killCount;
    public Button nextLevel;
    public Image aim;
    public GameObject audioManager;

    void Start(){
        count = 3;
        killCount = 0;
        healthBar = GameObject.FindGameObjectWithTag("healthBar").GetComponent<Slider>();
        healthValue = GameObject.FindGameObjectWithTag("healthCounter").GetComponent<TextMeshProUGUI>();
        killValue = GameObject.FindGameObjectWithTag("killValue").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        
        if (Input.GetMouseButtonDown(0)) {
            if (count > 0) {
                Ray ray = gameObject.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                RaycastHit hit;

                if (audioManager) audioManager.GetComponent<audioManager>().playShot();
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.gameObject.tag == "lb_bird") {
                        hit.collider.gameObject.SetActive(false);
                        killCount += 1;
                        killValue.text = killCount.ToString();
                        //Destroy(hit.collider.gameObject);
                    }
                }
                count -= 1;
                updateBar();
            }
        }
    }

    private void updateBar() {
        if (healthBar) {
            healthBar.value = count;
            healthValue.text = count.ToString() + "/3";
        }
    }

    public void reload() {
        count = 3;
        updateBar();
    }
}
