using UnityEngine;

namespace OneButton
{
    public class Diminish : MonoBehaviour
    {
        public Vector3 velocity;
        public float scale;

        public float currentScale;

        private void Start()
        {
            currentScale = 1;
        }

        private void Update()
        {
            currentScale -= scale * Time.deltaTime;
            transform.position += velocity;
            transform.localScale = Vector3.one * scale;

            if (currentScale < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}