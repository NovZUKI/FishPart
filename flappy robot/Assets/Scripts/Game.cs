using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{

    public enum GAME_STATUS
    {
        Ready,
        InGame,
        GameOver
    }
    private GAME_STATUS status;

    public GameObject panelReady;
    public GameObject panelIngame;
    public GameObject panelGameOver;

    public PiplineManager piplineManager;

    public Player player;

    public int score;
    public Text uiScore;
    public Text uiScore2;
    public int Score {
        get { return score; }
        set { this.score = value;
            this.uiScore.text = this.score.ToString();
            this.uiScore2.text = this.score.ToString();
        }
    }

    public GAME_STATUS Status
    {
        get { return status; }
        set { this.status = value;
            this.UpdateUI();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.panelReady.SetActive(true);
        Status = GAME_STATUS.Ready;
        this.player.OnDeath += Player_onDeath;
        this.player.OnScore = OnPlayerScore;
    }
    void OnPlayerScore(int score) {
        this.Score += score;
    }
    private void Player_onDeath() {
        this.Status = GAME_STATUS.GameOver;
        this.piplineManager.StopRun();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        this.Status = GAME_STATUS.InGame;
        Debug.LogFormat("StartGame:{0}",this.Status);
        piplineManager.StartRun();
        player.Fly();
        
    }

    public void UpdateUI() {
        this.panelReady.SetActive(this.Status == GAME_STATUS.Ready);
        this.panelIngame.SetActive(this.Status == GAME_STATUS.InGame);
        this.panelGameOver.SetActive(this.Status == GAME_STATUS.GameOver);
    }

    // This method is called when the quit game button is clicked
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
    public void Restart() {
        this.Status = GAME_STATUS.Ready;
        this.piplineManager.Init();
        this.player.Init();
        score = 0;
        this.uiScore.text = this.score.ToString();
        this.uiScore2.text = this.score.ToString();
    }
}
