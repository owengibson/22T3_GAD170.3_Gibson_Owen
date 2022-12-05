using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{

    public class InvisibleCube : MonoBehaviour
    {
        private Canvas canvas;
        private MeshRenderer meshRenderer;
        private GameObject cat;
        [SerializeField] private GameObject catPrefab;

        [SerializeField] private Material skybox;
        private Color defaultFogColor = new Color32(195, 142, 97, 255);

        [SerializeField] private float onFogDensity = 0.18f;

        private void Start()
        {
            canvas = FindObjectOfType<Canvas>();
            meshRenderer = GetComponent<MeshRenderer>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                OnInvisibleCube();
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            OffInvisibleCube();
        }

        private void OnDisable()
        {
            OffInvisibleCube();
        }

        private void OnInvisibleCube()
        {
            meshRenderer.enabled = true;

            if (cat == null) cat = Instantiate(catPrefab, canvas.transform);

            skybox.SetColor("_Tint", new Color(1, 0, 0));
            RenderSettings.fogColor = new Color32(255, 0, 0, 255);
            RenderSettings.fogDensity = onFogDensity;
        }

        private void OffInvisibleCube()
        {
            meshRenderer.enabled = false;
            Destroy(cat);
            skybox.SetColor("_Tint", new Color(0.4f, 0.4f, 0.4f));
            RenderSettings.fogColor = defaultFogColor;
            RenderSettings.fogDensity = 0.025f;
        }
    }
}