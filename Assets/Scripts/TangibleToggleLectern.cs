using UnityEngine;

namespace OwenGibson
{

    public class TangibleToggleLectern : MonoBehaviour
    {
        [SerializeField] private GameObject leverPanelPrefab;

        private GameObject leverPanel;
        private PlayerRaycast playerRaycast;
        private Canvas canvas;
        private bool isBridgeTangible = false;

        void Start()
        {
            playerRaycast = GameObject.Find("Player/Camera").GetComponent<PlayerRaycast>();
            canvas = FindObjectOfType<Canvas>();
        }


        void Update()
        {
            if(playerRaycast.lookingAt == "Tangible Toggle Lectern")
            {
                if (leverPanel == null) leverPanel = Instantiate(leverPanelPrefab, canvas.transform);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!isBridgeTangible)
                    {
                        EventsManager.TangibilityLeverDown?.Invoke();
                        isBridgeTangible = true;
                    }
                    else
                    {
                        EventsManager.TangibilityLeverUp?.Invoke();
                        isBridgeTangible = false;
                    }
                }
            }
            else
            {
                if (leverPanel != null) Destroy(leverPanel);
            }
        }
    }
}