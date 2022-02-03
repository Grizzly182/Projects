using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class BallScript : MonoBehaviour {
    [Header("UI")]
    [SerializeField] private Text leftScore;
    [SerializeField] private Text rightScore;
    [SerializeField] private Text startScreenText;
    [SerializeField] private Text winner;
    [SerializeField] private GameObject winLoseTab;

    [Space(5f)]
    [Header("GAME OBJECTS")]
    [SerializeField] private RectTransform ball;
    [SerializeField] private Pong script;
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private Rigidbody2D rb;

    [HideInInspector]
    public int player1Score, player2Score;

    public static Transform Player;

    private readonly Vector3 ballStartPos = new Vector3(Screen.width / 2f, Screen.height / 2f, 226);
    private float StartBallSpeed;
    private float SpeedMultiply;
    private const float SpeedMultiplier = 0.09f;
    private TrailRenderer trail;

    private void Start() {
        CameraRect.CorrectResolution();
        //ballStartPos = ball.position;
        ball.position = Vector2.zero;
        StartBallSpeed = Screen.width * 20;
        SpeedMultiply = 1;
        trail = GetComponent<TrailRenderer>();
        Player = null;
        Reset();
    }

    //Активирует бонус


    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag) {

            case "Player1": {
                    SpeedMultiply += SpeedMultiplier;
                    rb.velocity = Vector2.zero;
                    transform.eulerAngles = Vector3.zero;
                    Vector2 force = new Vector2(2.0f, Random.Range(-1f, 2f));
                    rb.AddRelativeForce(StartBallSpeed * SpeedMultiply * force);
                    Player = col.gameObject.transform;
                    break;
                }

            case "Player2": {
                    SpeedMultiply += SpeedMultiplier;
                    rb.velocity = Vector2.zero;
                    transform.eulerAngles = Vector3.zero;
                    Vector2 force = new Vector2(-2.0f, Random.Range(-1f, 2f));
                    rb.AddRelativeForce(StartBallSpeed * SpeedMultiply * force);
                    Player = col.gameObject.transform;
                    break;
                }

            case "RightCol": {
                    player1Score++;
                    leftScore.text = player1Score.ToString();
                    if (player1Score == 15) { FinishGame(winLoseTab, true); }
                    SpeedMultiply = 1;
                    Reset();
                    break;
                }

            case "LeftCol": {   
                    player2Score++;
                    rightScore.text = player2Score.ToString();
                    if(player2Score == 15) { FinishGame(winLoseTab, false); }
                    SpeedMultiply = 1;
                    Reset();
                    break;
                }
        }
        rb.MoveRotation(Random.Range(0, 360));
        Instantiate(particlePrefab, col.GetContact(0).point, Quaternion.identity);
    }

    public void Reset() {
        Application.targetFrameRate = 30;
        ball.position = ballStartPos;
        rb.Sleep();
        SpeedMultiply = 1;
        startScreenText.text = "Tap to start";
        script.canLaunch = true;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        trail.Clear();
    }

    //player == true in Player1
    //player == false is Player2
    private void FinishGame(GameObject tab, bool player) {
        tab.SetActive(true);
        
        Time.timeScale = 0;
    }
}