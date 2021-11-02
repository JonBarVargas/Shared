using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour
{
    public int scene;
    // Start is called before the first frame update
    public void BtnNewScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
