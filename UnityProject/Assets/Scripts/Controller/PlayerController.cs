using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : BaseController
{
    // �浹 ���� ����
    float EnvCollectDist { get; set; } = 1.0f;

    void Start()
    {

    }

    private void Update()
    {
        FindBox();
    }

    void FindBox()
    {
        float sqrCollectDist = EnvCollectDist * EnvCollectDist;

        List<BoxController> boxs = Managers.Object.Boxs.ToList();

        //foreach(var go in boxs)
        //{
        //    BoxController box = go.GetComponent<BoxController>();

        //    Vector3 dir = box.transform.position - transform.position;

        //    // �ڽ����� �Ÿ��� �������� �������� ���������
        //    if(dir.sqrMagnitude <= sqrCollectDist)
        //    {
        //        // ������Ʈ ����
        //        Managers.Object.Despawn(box);
        //    }
        //}

        //Debug.Log($"Total Box ({boxs.Count})");

        var findBoxs = GameObject.Find("@Grid").GetComponent<GridController>().GatherObjects(transform.position , EnvCollectDist + 2.5f);

        foreach (var go in findBoxs)
        {
            BoxController box = go.GetComponent<BoxController>();

            Vector3 dir = box.transform.position - transform.position;

            // �ڽ����� �Ÿ��� �������� �������� ���������
            if (dir.sqrMagnitude <= sqrCollectDist)
            {
                // ������Ʈ ����
                Managers.Object.Despawn(box);
            }
        }

        Debug.Log($"Search Box {findBoxs.Count} : Total Box ({boxs.Count}");
    }

}
