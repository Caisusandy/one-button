using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneButton
{
    public class StartGameController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                StartGame();
            }
        }

        public void StartGame()
        {
            SceneManager.LoadSceneAsync("SampleScene");
        }
    }
}