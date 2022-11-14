using System;
using System.Collections;
using UnityEngine;

namespace OutworldMini
{
    public class Tutorial : MonoBehaviour
    {
       [SerializeField] private float speed;
       [SerializeField] private float dps;

       private void Update()
        {
            transform.Translate(Vector3.up*speed);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(mytimer());
            }
        }

        IEnumerator mytimer()
        { 
            dps = GetDPSFromLevel(5);
            yield return new WaitForSeconds(dps);

            SpawnBullet(dps);
        }

        private float GetDPSFromLevel(int i)
        {
            switch (i)
            {
                case 1: return 5; break;
                case 2: return 10; break;
                case 3: return 12; break;
                case 4: return 18; break;
            };
            return 0;
        }

        private void SpawnBullet(float dps)
        {
            throw new NotImplementedException();
        }
    }
}