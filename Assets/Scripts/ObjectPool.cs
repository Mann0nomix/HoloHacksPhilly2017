using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public List<GameObject> list;
    public GameObject prefab;

    public ObjectPool(int size, GameObject prefab) {
        list = new List<GameObject>();
        for (int i = 0; i < size; i++) {
            GameObject obj = (GameObject)Instantiate(prefab);
            list.Add(obj);
        }
    }

    public GameObject GetObject() {
        if (list.Count > 0) {
            GameObject obj = list[0];
            list.RemoveAt(0);
            return obj;
        }
        return null;
    }

    public void DestroyObjectPool(GameObject obj) {
        list.Add(obj);
        obj.SetActive(false);
    }

    public void ClearPool() {
        for (int i = list.Count - 1; i > 0; i--) {
            GameObject obj = list[i];
            list.RemoveAt(i);
            Destroy(obj);
        }
        list = null;
    }


    // Use this for initialization
    void Start() {
        ObjectPool myPool = new ObjectPool(20, prefab);
    }
}
