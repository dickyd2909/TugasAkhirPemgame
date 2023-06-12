using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    public static bool InventoryisOn = false;
    // public Player playerInstanceInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowInventoryMenu();
    }

     private void ShowInventoryMenu () {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventoryisOn)
            {
                ShowInventory();
            }else{
                HideInventory();
            }
        }
    }

    public void ShowInventory()
    {
        InventoryMenu.SetActive(false);
        InventoryisOn = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
        }

    void HideInventory()
    {
        InventoryMenu.SetActive(true);
        InventoryisOn = true;
        Time.timeScale = 0f;
        // Cursor.lockState = CursorLockMode.Confined;
    }

}
