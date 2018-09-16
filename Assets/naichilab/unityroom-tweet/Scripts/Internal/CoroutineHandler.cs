using System.Collections;
using UnityEngine;

namespace naichilab.Scripts.Internal
{
    public class CoroutineHandler : MonoBehaviour
    {
        static protected CoroutineHandler m_Instance;

        static public CoroutineHandler instance
        {
            get
            {
                if (m_Instance == null)
                {
                    GameObject o = new GameObject("CoroutineHandler");
                    DontDestroyOnLoad(o);
                    m_Instance = o.AddComponent<CoroutineHandler>();
                }

                return m_Instance;
            }
        }

        public void OnDisable()
        {
            if (m_Instance)
                Destroy(m_Instance.gameObject);
        }

        static public Coroutine StartStaticCoroutine(IEnumerator coroutine)
        {
            return instance.StartCoroutine(coroutine);
        }
    }
}