using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _coitainer;
    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initializate(GameObject prefub)
    {
        _camera = Camera.main;
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefub, _coitainer.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);

        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0,0.5f));

        foreach (var item in _pool)
        {
            if(item.activeSelf == true)
            {
                if (item.transform.position.x < disablePoint.x)
                    item.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
