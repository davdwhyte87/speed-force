using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SwitchScreen");
    }

    IEnumerator SwitchScreen(){
        yield return new WaitForSeconds(6.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
