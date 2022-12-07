using Mono.CompilerServices.SymbolWriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class PauseMenu : MonoBehaviour
    {
        private bool isGamePaused = false;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private SceneManagerScript sceneManagerScript;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isGamePaused) Pause();
                else Resume();
            }
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            isGamePaused = false;
            Time.timeScale = 1f;
            playerMovement.enabled = true;
        }

        private void Pause()
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            isGamePaused = true;
            Time.timeScale = 0f;
            playerMovement.enabled = false;

        }

        public void Restart()
        {
            Time.timeScale = 1f;
            sceneManagerScript.RestartScene();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}