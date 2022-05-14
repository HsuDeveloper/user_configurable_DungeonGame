using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject submenu;
    public Button continue_btn;
    public Button exit_btn;
    // Start is called before the first frame update
    void Start()
    {
        continue_btn.onClick.AddListener(delegate
        {
            Time.timeScale=1;
        });
        
        exit_btn.onClick.AddListener(delegate
        {
            Time.timeScale=1;
             DataManager.instance.StartScene();
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            if(submenu.activeSelf) 
            {
                Time.timeScale=1;
                submenu.SetActive(false);
            }
            else 
            {
                Time.timeScale=0;
                submenu.SetActive(true);
            }
        }
    }
}
