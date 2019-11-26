using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketTank.Generics
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T instance;
        public static T Instance{get{ return instance; }}
        protected virtual void Awake()
        {
            if(instance == null || instance != this)
            {
                instance = (T)this;
            }
            else
            {
                Debug.LogWarning("Duplicate instance is being created");
                Destroy(this);
            }
        }
    }
}
