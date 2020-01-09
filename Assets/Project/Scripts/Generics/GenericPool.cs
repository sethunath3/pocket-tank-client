using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketTank.Generics
{
    public class GenericPool<T> : GenericSingleton<GenericPool<T>> where T : class
    {
        private List<PooledItem<T>> poolList = new List<PooledItem<T>>();

        public T GetItem()
        {
            PooledItem<T> item = new PooledItem<T>();
            if(poolList.Count > 0)
            {
                item = poolList.Find(i => i.isInUse == false);
                if(item != null)
                {
                    item.isInUse = true;
                    return item.pooledItem;
                }
            }
            item.pooledItem = CreateNewItem();
            item.isInUse = true;
            poolList.Add(item);
            return item.pooledItem;
        }

        public void ReturnItem(T returnItem)
        {
            PooledItem<T> item = poolList.Find(i => i.pooledItem.Equals(returnItem));
            if(item != null)
            {
                item.isInUse = false;
            }
        }

        public virtual T CreateNewItem()
        {
            return (T)null;
        }
    }

    public class PooledItem<T>
    {
        public bool isInUse;
        public T pooledItem;
    }
}
