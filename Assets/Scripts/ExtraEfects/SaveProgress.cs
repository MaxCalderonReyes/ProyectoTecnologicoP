
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEngine.SceneManagement;
[SerializeField]
public class SaveProgress : MonoBehaviour
{
    [HideInInspector] public string Path;
    void Start()
    {
        Path = Application.dataPath + "Datos.json";
        BaseDatosNivel bd = new BaseDatosNivel(SceneManager.GetActiveScene().buildIndex);
        string content = JsonUtility.ToJson(bd, true);
        File.WriteAllText(Path, content);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
