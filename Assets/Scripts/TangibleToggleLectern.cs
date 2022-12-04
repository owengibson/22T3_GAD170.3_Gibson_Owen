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

        public delegate void BridgeEvent();
        public event BridgeEvent LeverDown;
        public event BridgeEvent LeverUp;

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
                        LeverDown?.Invoke();
                        isBridgeTangible = true;
                    }
                    else
                    {
                        LeverUp?.Invoke();
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