using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anaMenu : MonoBehaviour
{
   
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

   public void oyunaGit()
    {
        SceneManager.LoadScene("level");
    }

    public void oyundanCik()
    {
        Application.Quit();
    }
}
