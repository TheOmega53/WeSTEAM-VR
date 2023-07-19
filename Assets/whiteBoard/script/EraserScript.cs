using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class EraserScript : MonoBehaviour{
 [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize= 200;
    private Renderer _renderer;
    
    private Color[] _colors;
    private float _tipHeight;
    private RaycastHit _touch;
    private whiteBoard _whiteboard;
    private Vector2 _touchPos , _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;
    private Texture2D transparentTexture;
    void Start()
    {
        // transparentTexture = new Texture2D(5, 5, TextureFormat.RGBA32, false);
        // Color32[] pixels = new Color32[5 * 5];
        // for (int i = 0; i < pixels.Length; i++)
        // {
        //     pixels[i] = new Color32(0, 0, 0, 0); 
        // }
        // transparentTexture.SetPixels32(pixels);
        // transparentTexture.Apply();
        _renderer =  _tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }
    private void Draw(){
        // Texture2D blankTexture = new Texture2D(256,256);
        if(Physics.Raycast(_tip.position,transform.up,out _touch,_tipHeight)){
            if(_touch.transform.CompareTag("whiteBoard")){
                if(_whiteboard == null){
                    _whiteboard = _touch.transform.GetComponent<whiteBoard>();
                }
                _touchPos= new Vector2(_touch.textureCoord.x,_touch.textureCoord.y);
                int x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize/2));
                int y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize/2));

                if(y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x){return;}

                // int x_whiteBoard =(int)_whiteboard.textureSize.x;
                // int y_whiteBoard = (int)_whiteboard.textureSize.x;
                // Debug.Log(xesh);
                // Debug.Log(y);
                if(_touchedLastFrame)
                {
                    _colors = Enumerable.Repeat(_whiteboard.texture.GetPixel(0, 0), _penSize * _penSize).ToArray();
                    for(float f = 0.01f;f<1.00f;f+=0.01f){
                        var lerpX = (int) Mathf.Lerp(_lastTouchPos.x , x , f);
                        var lerpY = (int) Mathf.Lerp(_lastTouchPos.y , y , f);
                        // pixelColor = _whiteboard.texture.GetPixel(lerpX, lerpY);
                        // Debug.Log(_colors);
                        _whiteboard.texture.SetPixels(lerpX, lerpY,_penSize,_penSize,_colors);
                       
                    }
                    // transform.rotation = _lastTouchRot;
                    _whiteboard.texture.Apply();
                }
                _lastTouchPos = new Vector2(x,y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }
        _whiteboard = null;
        _touchedLastFrame=false;
    }
}
