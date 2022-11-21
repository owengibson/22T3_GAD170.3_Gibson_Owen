using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TryAgainButton : MonoBehaviour
{
    private Button button;
    private SceneManagerScript sceneManager;

    // Start is called before the first frame update
    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManagerScript>();

        button = GetComponent<Button>();
        button.onClick.AddListener(sceneManager.RestartScene);
    }
}
