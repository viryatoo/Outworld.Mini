using UnityEngine;
using System.Collections;

namespace OutworldMini
{
    public interface ICorutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(IEnumerator routine);
    }
}