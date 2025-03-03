using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField]
    public int coins;
    [SerializeField]
    public int lives;
    [SerializeField]
    public int time;
=======
    private int coins;
    private int lives;
    private int time;       
    private int score;
    private bool isSmall = true;
    private int initialLives = 3;
    private int initialCoins = 0;
    private int initialTime = 300;
    private int initialScore = 0;

    public static GameManager Instance { get; private set; }

    public int Lives { get { return lives; } }
    public int Coins { get { return coins; } }
    public int Time { get { return time; } }
    public int Score { get { return score; } }
public bool IsSmall 
{ 
    get { return isSmall; } 
    set { isSmall = value; }
}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        this.lives = 3;
        this.coins = 0;
        this.time = 300;

    }
    public void SubstractLives()
    {
        this.lives--;
       
    }
    public void addLives()
    {
        this.lives++;
    }
    
    public void addCoins()
    {
        this.coins += 1;
    }
    public void SubstractTime(){
        this.time--;
    }
    public void AddScore(){
        this.score += 100;
    }
public void KillMario()
{
    if (isSmall) // Si Mario es pequeño, pierde una vida
    {
        SubstractLives();

        if (lives > 0) // Si aún tiene vidas, Respawnea en la parte izquierda de donde esté la cámara
        {
            RespawnMario();
        }
        else // Si no tiene vidas, reinicia el nivel
        {
            RestartLevel();
        }
    }
    else
    {
        isSmall = true; // Mario se vuelve pequeño en lugar de morir
    }
}

// Método para respawnear a Mario
private void RespawnMario()
{
    Debug.Log("Respawneando a Mario...");
    GameObject mario = GameObject.FindGameObjectWithTag("Player");

    if (mario != null)
    {
        Mario marioScript = mario.GetComponent<Mario>();

        if (marioScript != null)
        {
           marioScript.PlayDeathAnimation(); // Ejecuta la animación de muerte
           marioScript.Invoke(nameof(marioScript.Respawn), 1.5f); // Espera un rato para respawnear
        }
    }
}

private void RestartLevel()
{
    // Restablece valores iniciales en GameManager
    GameManager.Instance.lives = GameManager.Instance.initialLives;
    GameManager.Instance.coins = GameManager.Instance.initialCoins; 
    GameManager.Instance.score = GameManager.Instance.initialScore; 
    GameManager.Instance.time = GameManager.Instance.initialTime; 

    // Cargar la escena
    UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    // Esperar hasta que Mario esté disponible para asignarlo a la cámara
    StartCoroutine(ReassignCameraTarget());
}

private IEnumerator ReassignCameraTarget()
{
    yield return null; // Espera un frame para que la escena termine de cargar

    // Busca a Mario en la nueva escena
    Mario mario = FindObjectOfType<Mario>(); 

    while (mario == null) 
    {
        yield return null; // Sigue esperando hasta que Mario aparezca
        mario = FindObjectOfType<Mario>();
    }

    // Reasignar la posición de Mario
    mario.transform.position = new Vector3(-7.7f, -2.0f, 0);

    // Reasignar el objetivo de la cámara
    var mainCamera = Camera.main.GetComponent<MainCamera>();
    if (mainCamera != null)
    {
        mainCamera.SetMario(mario.transform);
    }
}

>>>>>>> 1daa5d0 (Cambios finales)
}
