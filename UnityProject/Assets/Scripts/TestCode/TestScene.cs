using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class TestScene : MonoBehaviour
{
    // Start is called before the first frame update

    public int Count = 0;
    void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
        {
            Debug.Log("key : " + key + " Count : " + count + " totalCount : " + totalCount);
            if (count == totalCount)
            {
                Managers.Data.Init();
                Managers.Game.Init();
                Init();
            }
        });
    }

    void Init()
    {
        for (int i = 0; i < 100; i++)
        {
            Managers.Object.Spawn<BoxController>(new Vector3(Random.Range(0, 50), 0, Random.Range(0, 50)));

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            Count++;
            Managers.UI.ShowToast(Count.ToString());
        }
        if (Input.GetKeyUp(KeyCode.F3))
        {
            Managers.Object.Spawn<MonsterController>(new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)));
        }

        if (Input.GetKeyUp(KeyCode.F5))
        {
            Managers.Game.Gold += 1;
        }

        if (Input.GetKeyUp(KeyCode.F6))
        {
            Managers.Game.AddEquipment("1");
        }

        if (Input.GetKeyUp(KeyCode.F7))
        {
            Managers.Game.AddMaterialItem(ID_BRONZE_KEY, 1);
            Managers.Game.AddMaterialItem(ID_SILVER_KEY, 1);
            Managers.Game.AddMaterialItem(ID_GOLD_KEY, 1);
        }

        if (Input.GetKeyUp(KeyCode.F9))
        {
            Managers.Object.Spawn<BoxController>(new Vector3(Random.Range(0, 50), 0, Random.Range(0, 50)));
        }
    }
}
