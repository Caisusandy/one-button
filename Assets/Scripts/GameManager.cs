using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace OneButton
{
    /// <summary>
    /// Use this class to initialize the game and start the game
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public float startTime;
        public float decreasing;
        public float minTime;

        public float startMoney;
        public float salary;
        public TMP_Text moneyText;
        public TMP_Text scoreText;
        public TMP_Text timerText;
        public ItemCollections collections;
        public ItemSelectionController selectionController;

        public GameObject optionsParent;
        public GameObject salaryPrefab;

        [Header("Stat")]
        public int turn;
        public float currentMoney;
        public Score score;
        public float currentStartTime;
        public float timer;
        private SelectionPair currentPair;
        [Header("End Game")]
        public bool isEndGame;
        public float endGameDuration;


        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            ResetGame();
        }

        private void Update()
        {
            // end already
            if (isEndGame)
            {
                endGameDuration += Time.deltaTime;
                timerText.text = $"End";
                optionsParent.SetActive(false);
                if (endGameDuration > 3 && Input.GetKeyUp("space"))
                    ResetGame();
                return;
            }

            // display update
            UpdateDisplay();

            timer -= Time.deltaTime;
            if (timer < 0)
            {
                // check end turn
                CheckSelection();
                // check game end
                CheckGameEnd();
                // next turn setup
                currentStartTime = Mathf.Max(minTime, currentStartTime - decreasing);
                timer = currentStartTime;
                // set up next turn
                Setup();
            }
        }

        public void ResetGame()
        {
            isEndGame = false;
            optionsParent.SetActive(true);
            endGameDuration = 0;
            currentMoney = startMoney;
            currentStartTime = startTime;
            timer = currentStartTime;
            turn = 0;
            score = new Score();
            Setup();
        }

        public void Setup()
        {
            // go far away, end the turn
            if (isEndGame)
            {
                return;
            }

            // change this in the future
            currentPair = collections.GetSelectionPair();
            selectionController.Setup(currentPair);

            float salary1 = salary;
            currentMoney += salary1;
            ShowMoneyGain(salary1);
        }

        public void CheckSelection()
        {
            int selection = selectionController.selection;
            switch (selection)
            {
                case 0:
                    currentMoney -= currentPair.first.price;
                    score.h += currentPair.first.happiness;
                    score.p += currentPair.first.physicalHealth;
                    score.m += currentPair.first.mentalHealth;
                    //ShowScoreGain(currentPair.first.happiness);
                    break;
                case 1:
                    currentMoney -= currentPair.second.price;
                    score.h += currentPair.second.happiness;
                    score.p += currentPair.second.physicalHealth;
                    score.m += currentPair.second.mentalHealth;
                    //ShowScoreGain(currentPair.second.happiness);
                    break;
                default:
                    // selection of nothing
                    break;
            }
            UpdateDisplay();
            // trigger something
            turn++;
        }

        private void CheckGameEnd()
        {
            isEndGame = currentMoney < 0
                        || score.h < 0
                        || score.p < 0
                        || score.m < 0;
        }

        private void UpdateDisplay()
        {
            // update ui
            moneyText.text = $"Money: ${currentMoney}";
            scoreText.text = $"Score: {score}";
            // format of timer
            timerText.text = $"Time: {timer:f2}s";
        }

        private TMP_Text CreateText()
        {
            var newInstance = Instantiate(salaryPrefab);
            newInstance.transform.SetParent(transform);
            TMP_Text tMP_Text = newInstance.GetComponent<TMP_Text>();
            return tMP_Text;
        }

        //private async void ShowScoreGain(float score)
        //{
        //    await Task.Yield();
        //    TMP_Text tMP_Text = CreateText();
        //    tMP_Text.transform.position = scoreText.transform.position + new Vector3(100f, 0, 0);
        //    tMP_Text.text = $"+ {score}";
        //}

        private async void ShowMoneyGain(float salary1)
        {
            await Task.Yield();
            TMP_Text tMP_Text = CreateText();
            tMP_Text.transform.position = moneyText.transform.position + new Vector3(100f, 0, 0);
            tMP_Text.text = $"+ ${salary1}";
        }
    }
}
