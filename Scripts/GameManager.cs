using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{  
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

 public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    public AudioSource audio;


      
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        Application.targetFrameRate = 60;

        Pause();

          audio.clip = clip1;
          
        audio.loop =true;
        audio.Play();
    }

    public void Play()
    {
        audio.Pause();
        audio.clip = clip2;
          
        audio.loop =true;
         audio.Play();
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver() 
    {

        audio.Pause();
        audio.clip = clip3;
        audio.Play();
        audio.loop =true;

        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore() 
    {
        score++;
        scoreText.text = score.ToString();
    }

}

