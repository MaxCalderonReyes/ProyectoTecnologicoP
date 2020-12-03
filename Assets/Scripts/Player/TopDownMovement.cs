using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class TopDownMovement : MonoBehaviour
{
   
    private Rigidbody2D rgbd;
    [SerializeField]private float speed;
    public static TopDownMovement instancia;
    [SerializeField] private Joystick joystick;

    //Guardar informacion en Jsons
    public BaseDatosNivel Dts;
    private string Path;
    private void Awake()
    {
        
        if (instancia == null)
        {
            instancia = this;
        }
     
    }
    void Start()
    {
        Path = Application.dataPath + "Datos.json";
        rgbd = GetComponent<Rigidbody2D>();
        if (File.Exists(Path))
        {
            string datos = File.ReadAllText(Path);
            Dts = JsonUtility.FromJson<BaseDatosNivel>(datos);
            print(Dts.level);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        rgbd.velocity = new Vector2(x * speed, y * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Puerta" &&Dts.level<3)
        {
            SceneManager.LoadScene(2);
        }else if(collision.gameObject.tag == "Puerta" && Dts.level <7&&Dts.level>3)
        {
            SceneManager.LoadScene(5);
        }
        else if(collision.gameObject.tag == "Puerta" && Dts.level <10&&Dts.level>6)
        {
            SceneManager.LoadScene(8);
        }
        else if (collision.gameObject.tag == "Puerta" && Dts.level < 13 && Dts.level > 9)
        {
            SceneManager.LoadScene(11);
        }
        else if (collision.gameObject.tag == "Puerta" && Dts.level < 17 && Dts.level >12)
        {
            SceneManager.LoadScene(14);
        }
    }
}
