using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    private LevelManager levelManager;



    private GameObject HUDGameObject;
    private GameObject menuGameObject;

    void Start()
    {
        levelManager = LevelManager.instance;

        HUDGameObject = transform.Find("HUD").gameObject;
        menuGameObject = transform.Find("Menu").gameObject;

        menuGameObject.SetActive(false);
    }

    void Update()
    {
        if (InputHandler.pressed(act.togglePause))
        {
            if (menuGameObject.activeInHierarchy)
            {
                menuGameObject.SetActive(false);
                levelManager.togglePause();
            }
            else
            {
                menuGameObject.SetActive(true);
                levelManager.togglePause();
            }
        }
    }
}
