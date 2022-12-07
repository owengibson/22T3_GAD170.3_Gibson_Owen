using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace OwenGibson
{
    public class DrowningCollision : MonoBehaviour
    {
        [SerializeField] private GameObject drownPanelPrefab;
        private GameObject player;
        private GameObject panel;
        private Canvas canvas;

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision");
            if (collision.gameObject.CompareTag("Player") && panel == null)
            {
                
                Debug.Log("You have drowned.");

                panel = Instantiate(drownPanelPrefab, canvas.transform);
                player.GetComponent<PlayerMovement>().DisableMovement();

                Cursor.visible = true;
            }
        }

        private void Start()
        {
            player = GameObject.Find("Player");
            canvas = FindObjectOfType<Canvas>();
        }
    }
}
