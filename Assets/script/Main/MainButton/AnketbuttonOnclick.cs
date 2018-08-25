using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnketbuttonOnclick : MonoBehaviour {
    
        public void Onclick()
        {
        UserData.instance.lastMode.Push("mainhome");
            SceneManager.LoadScene("ankethome");
        }
    

    }