using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManag : MonoBehaviour
{
    Scene activeScene;
    public int actSceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        actSceneIndex = activeScene.buildIndex;
        Debug.Log("NIVEL >>>>  : " + actSceneIndex);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
