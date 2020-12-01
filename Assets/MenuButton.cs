using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    //eventually if there was a server this would take you to a login remember a loading screen
    public void LoginButton(){
        SceneManager.LoadScene(1);
    }

    //eventually if there was a server this would take you to a login remember a loading screen
    public void NewAccountButton(){ 
        SceneManager.LoadScene(1);
    }

    public void Fight(){
        SceneManager.LoadScene(2);
    }
}
