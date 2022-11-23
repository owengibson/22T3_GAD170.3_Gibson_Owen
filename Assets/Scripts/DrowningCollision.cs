using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OwenGibson
{
    public class DrowningCollision : MonoBehaviour
    {
        [SerializeField] private GameObject drownPanel;
        private GameObject player;
        private SceneManagerScript sceneManager;
        private GameObject panel;

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision");
            if (collision.gameObject.CompareTag("Player") && panel == null)
            {
                
                Debug.Log("You have drowned.");

                panel = Instantiate(drownPanel, FindObjectOfType<Canvas>().transform);
                player.GetComponent<PlayerMovement>().DisableMovement();
                panel.GetComponentInChildren<Button>().onClick.AddListener(sceneManager.RestartScene);

                Cursor.visible = true;
            }
        }

        private void Start()
        {
            player = GameObject.Find("Player");
            sceneManager = FindObjectOfType<SceneManagerScript>();
        }
    }
}
