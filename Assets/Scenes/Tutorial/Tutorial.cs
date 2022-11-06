using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace OutworldMini
{
    public class Tutorial : MonoBehaviour
    {
        public GameObject obj;
        void Update()
        {
            obj.transform.Translate(new Vector3(0.01f,0,0));
        }
    }
}
