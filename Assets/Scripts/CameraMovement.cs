using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutworldMini
{
    public class CameraMovement : MonoBehaviour
    {

        private bool isMouseButtonPressed;
        private Rect gameArea;
        private Camera gameCamera;
        [SerializeField] private float sensitivy;
        public void Init(Rect area)
        {
            gameArea = area;
            gameCamera = GetComponent<Camera>();
            CalculateBounds();
        }

        private void Awake() 
        {
         Debug.Log("Awake");  
        }
        private void Start()
        {
            Debug.Log("Start");
        }
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                isMouseButtonPressed = true;
            }
            if(Input.GetMouseButtonUp(0))
            {
                isMouseButtonPressed = false;
            }

            if(isMouseButtonPressed)
            {
                Vector3 pos = new Vector3(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"),0) * -1*sensitivy;
                transform.Translate(pos);
                CalculateBounds();
                
            }
        }

        private void CalculateBounds()
        {
            Vector3 pos0 = gameCamera.ScreenToWorldPoint(Vector3.zero);
            Vector3 pos1 = gameCamera.ScreenToWorldPoint(new Vector3(gameCamera.pixelWidth,gameCamera.pixelHeight));

            Vector3 offset = Vector3.zero;
            if(pos0.x<gameArea.xMin)
            {
                offset.x = gameArea.xMin-pos0.x;
            }
            else if(pos1.x>gameArea.xMax)
            {
                offset.x = gameArea.xMax-pos1.x;
            }
            if(pos0.y<gameArea.yMin)
            {
                offset.y = gameArea.yMin-pos0.y;
            }
            else if(pos1.y>gameArea.yMax)
            {
                offset.y = gameArea.yMax-pos1.y;
            }

            if(offset!=Vector3.zero)
            {
                transform.position = transform.position+offset;
            }

        }


    }
}
