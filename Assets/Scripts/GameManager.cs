using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    float time = 0.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if(time>30)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    public void Matched()
    {
        if(firstCard.idx==secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if(cardCount==0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
