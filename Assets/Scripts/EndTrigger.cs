using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class EndTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject endScreenPrefab;
        private GameObject endScreen;
        private bool hasPlayerWon = false;

        private Canvas canvas;
        private SceneManagerScript sceneManagerScript;

        private void Start()
        {
            canvas = FindObjectOfType<Canvas>();
            sceneManagerScript = FindObjectOfType<SceneManagerScript>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && endScreen == null)
            {
                endScreen = Instantiate(endScreenPrefab, canvas.transform);
                hasPlayerWon = true;
            }
        }

        private void Update()
        {
            if (hasPlayerWon && Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Reloading scene");
                sceneManagerScript.RestartScene();
            }

            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.Return)) // cheat code
            {
                if (endScreen == null) endScreen = Instantiate(endScreenPrefab, canvas.transform);
                hasPlayerWon = true;
            }
        }
    }
}