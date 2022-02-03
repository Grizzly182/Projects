using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Pong : MonoBehaviour
{
    public bool canLaunch;

    [Space(5f)]
    [Header("PLAYERS")]
    public GameObject Player1;
    public GameObject Player2;

    [Space(5f)]
    [Header("MISC")]
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Text player2ScoreText;
    [SerializeField] private Text startScreenText;
    [SerializeField] private BallScript script;
    [SerializeField] private Rigidbody2D rb;

    private float StartBallSpeed;
    private float Limit;
    //TODO: Make player size reset after bonus effect ended.
    private int Player1OriginalSize;
    private int Player2OriginalSize;
    private Vector3 player1StartPos;

    private readonly Vector2[] directions = {
            new Vector2(1, 1), new Vector2(-1, 1),
            new Vector2(1, -1), new Vector2(-1, -1)
    };

    private void Awake() {
        Application.targetFrameRate = 30;
    }
    
    private void Start()
    {
        CameraRect.CorrectResolution();
        StartBallSpeed = Screen.width * 20;
        player1StartPos = Player1.transform.position;
        canLaunch = true;
        Limit = Screen.width / 2f;
    }

    private void Update()
    {
        //Установить позицию платформы на месте нажатия
        if(Input.touchCount > 0 && Input.GetTouch(0).position.x <= Limit) {
            Vector2 pos = Input.GetTouch(0).position;
            rb.MovePosition(new Vector3(player1StartPos.x, pos.y, 226));
        }

        if (Input.GetMouseButtonDown(0)) {
            Launch();
        }
    }
    
    //Запускается после конца раунда при
    //нажатии на экран.
    //запускает мяч и разблокирует управление
    public void Launch()
    {
        switch (canLaunch)
        {
            case true:
                startScreenText.text = "";
                ball.WakeUp();
                ball.AddRelativeForce(directions[Random.Range(0 ,3)] * StartBallSpeed);
                canLaunch = false;
                break;
            default:
                return;
        }
    }
    public void RestartGame(GameObject tab) {
        script.player1Score = 0;
        script.player2Score = 0;
        player1ScoreText.text = player2ScoreText.text = "0";
        script.Reset();
        tab.SetActive(false);
        Time.timeScale = 1;
        Application.targetFrameRate = 30;
    }

    public void ContinueGame(GameObject tab) {
        tab.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home1P(GameObject tab) {
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync("1PlayerScene");
        RestartGame(tab);
    }

    public void Home2P(GameObject tab) {
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync("2PlayersScene");
        RestartGame(tab);
    }

    public void Pause(GameObject tab) {
        tab.SetActive(true);
        Time.timeScale = 0;
    }
}