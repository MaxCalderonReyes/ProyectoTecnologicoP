using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton : MonoBehaviour
{
    public bool showMenu;
    public static boton instance;

    private void Awake()
    {
        instance = this;
    }


    public void ButtonShowMenu() {

        if (!showMenu) { 
            showMenu = true;
            ActiveOpcion.instance.activate();
        }
        else if (showMenu)
        {
            showMenu = false;
            ActiveOpcion.instance.desactivate();
        }
    } 

}
