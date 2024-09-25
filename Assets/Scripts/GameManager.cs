using TMPro;
using UnityEngine;

namespace OneButton
{
    /// <summary>
    /// Use this class to initialize the game and start the game
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public float startTime;
        public float decreasing;

        public float startMoney;
        public TMP_Text moneyText;
        public TMP_Text scoreText;
        public TMP_Text timerText;
        public ItemCollections collections;
        public ItemSelectionController selectionController;

        [Header("Stat")]
        public int turn;
        public float currentMoney;
        public int currentScore;
        public float currentStartTime;
        public float timer;
        private SelectionPair currentPair;

        private void Start()
        {
            currentStartTime = startTime;
            timer = currentStartTime;
            Setup();
        }

        private void Update()
        {
            // end already
            if (turn >= collections.items.Count)
            {
                timerText.text = "0";
            }
            timer -= Time.deltaTime;
            // format of timer
            timerText.text = $"Time: {timer}s";

            if (timer < 0)
            {
                // check end turn
                CheckSelection();
                currentStartTime -= decreasing;
                timer = currentStartTime;
                // set up next turn
                Setup();
            }
        }

        public void Setup()
        {
            // go far away, end the turn
            if (turn >= collections.items.Count)
            {
                return;
            }

            // change this in the future
            currentPair = collections.items[turn];
            selectionController.Setup(currentPair);
        }

        public void CheckSelection()
        {
            int selection = selectionController.selection;
            switch (selection)
            {
                case 0:
                    currentMoney -= currentPair.first.price;
                    currentScore += currentPair.first.score;
                    break;
                case 1:
                    currentMoney -= currentPair.second.price;
                    currentScore += currentPair.second.score;
                    break;
                default:
                    // selection of nothing
                    break;
            }
            // update ui
            moneyText.text = "Money: " + currentMoney.ToString();
            scoreText.text = "Score: " + currentScore.ToString();
            // trigger something
            turn++;
        }
    }
}
