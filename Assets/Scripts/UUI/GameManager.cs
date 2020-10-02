using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instancie;
    [SerializeField] private Slider sliderLive;
    private PlayerMovement player;
    public Enemy[] enemigos;
    
    private void Awake()
    {
        enemigos = new Enemy[20];
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        enemigos = GameObject.FindObjectsOfType<Enemy>();
        sliderLive.value = player.live;
    }

    // Update is called once per frame
    void Update()
    {
        sliderLive.value = player.live;
    }
}
