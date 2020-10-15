using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class StaticParalax : MonoBehaviour
{
    [SerializeField] public float ParalaxxEfectMuliply;
    private Transform CamaraTransform;
    private Vector3 lastposCamera;
    private float UnitSizeX;
    private float UnitSIzeY;
    [SerializeField] private bool IsVertical;
    [SerializeField] private bool Tilemap;
    Tilemap _tilemap;
    // Start is called before the first frame update
    private bool InPersecute;
    public bool _InPersecute
    {
        get => InPersecute;
        set => InPersecute = value;
    }
    public void Start()
    {
        CamaraTransform = Camera.main.transform;
        lastposCamera = CamaraTransform.position;
        if (!Tilemap)
        {
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            UnitSizeX = texture.width / sprite.pixelsPerUnit;
            UnitSIzeY = texture.height / sprite.pixelsPerUnit;
        }
        else
        {
            _tilemap = GetComponent<Tilemap>();
            
        }
        
       
      

    }

    private void LateUpdate()
    {

        if (!Tilemap)
        {
            transform.position += new Vector3(Time.deltaTime * ParalaxxEfectMuliply, 0, 0);

            if (!IsVertical)
            {
                if (Mathf.Abs(CamaraTransform.position.x - transform.position.x) >= UnitSizeX)
                {

                    float offsetPosition = (CamaraTransform.position.x - transform.position.x) % UnitSizeX;
                    transform.position = new Vector3(CamaraTransform.position.x + offsetPosition, transform.position.y);
                }
            }
            if (IsVertical)
            {
                if (Mathf.Abs(CamaraTransform.position.y - transform.position.y) >= UnitSIzeY)
                {

                    float offsetPosition = (CamaraTransform.position.y - transform.position.y) % UnitSIzeY;
                    transform.position = new Vector3(transform.position.x, CamaraTransform.position.y + offsetPosition);
                }
            }
        }
        if(Tilemap)
        {
            float xpos = CamaraTransform.position.x * ParalaxxEfectMuliply;
            float Ypos = CamaraTransform.position.y * ParalaxxEfectMuliply;
            _tilemap.transform.position += new Vector3(xpos, _tilemap.transform.position.y, _tilemap.transform.position.z);
            if (InPersecute)
            {
                if (transform.position.x < -23)
                {
                    print("X");
                    transform.position = new Vector3(0, 0, 0);

                }
                else
                {
                    print("Y");
                }
            }
            else
            {
                transform.position = new Vector3(0, 0, 0);
            }
           
        }
     

    }
}

