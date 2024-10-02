using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] protected GameObject mapsPrefeb;

    List<int> mapList = new();
    List<int> allRoomList = new();
    List<int> endRoomList = new();
    List<int> normalRoomList = new();

    int startPos;//���� ��ġ ��ȣ(����)
    int nextPosNum;//���� ��ǥ�� ��ȣ
    int maxMapSize;//���� �ִ� ������ ? * ? ����
    int mapLength;//���� �ִ� ���� ����

    int endRoomNum;//�� ���� ����

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        maxMapSize = 7;
        mapLength = 10;
        endRoomNum = 3;
        startPos = ((maxMapSize / 2) * 10) + ((maxMapSize / 2) + 1);//�Ƹ� 34��
        nextPosNum = startPos;
        mapList.Add(startPos);
        RandomMapGenerator();
    }
    private void AddMap()
    {
        for(int i = 0; i < mapList.Count; i++)
        {
            GameObject newMapIcon = Instantiate(mapsPrefeb);

            newMapIcon.transform.SetParent(transform);

            int posX = (mapList[i] % 10) - ((maxMapSize / 2) + 1);
            int posY = (mapList[i] / 10) - (maxMapSize / 2);

            Vector2 newVec = new Vector2(posX * 64, posY * 64);

            newMapIcon.GetComponent<RectTransform>().localPosition = newVec;

            //newMapIcon.SetActive(true);
        }
    }
    private void RandomMapGenerator()
    {
        do
        {
            nextPosNum = startPos;
            mapList.Clear();
            mapList.Add(startPos);

            RandomMapCreate();
        } while (!CheckEndRoom());//true�� endRoom�� ������ ���� ��ŭ ����

        AddMap();
    } 
    private void RandomMapCreate()
    {
        while(mapList.Count < mapLength)//���ϴ� �� ���� ���� �� ����
        {
            int random;//���� ���� ����
            int nextNum = 0;
            do
            {
                random = UnityEngine.Random.Range(0, 4);

                switch (random)
                {
                    case 0:
                        nextNum = 10;//�Ʒ�
                        break;
                    case 1:
                        nextNum = -10;//��
                        break;
                    case 2:
                        nextNum = 1;//������
                        break;
                    case 3:
                        nextNum = -1;//����
                        break;
                }

            } while (((nextPosNum + nextNum) / 10) < 0 || ((nextPosNum + nextNum) / 10) > maxMapSize - 1 || ((nextPosNum + nextNum) % 10) < 1 || ((nextPosNum + nextNum) % 10) > maxMapSize);

            nextPosNum += nextNum;//�������� �̵��� ��ġ�� ����

            if (mapList.Contains(nextPosNum))//�̹� �ִ� ��ȣ��� �����ϰ� �ٽ�
            {
                continue;
            }

            if (CheckMapList(nextPosNum))//false�� �̵� �Ұ����� ��ġ��, true�� �̵� ����
            {
                mapList.Add(nextPosNum);
            }
            else
            {
                int RandomMapListNum = UnityEngine.Random.Range(0, mapList.Count);
                nextPosNum = mapList[RandomMapListNum];//������ ��ġ�� �̵����ѹ���
                continue;
            }

        }
    }

    private bool CheckMapList(int mapNum)//���� ���������� ���������� Ȯ��
    {
        List<int> compareValues = new List<int> { mapNum + 10, mapNum - 10, mapNum + 1, mapNum - 1 };

        // mapList���� compareValues�� ���� �� �� �ִ��� ī��Ʈ
        int matchCount = 0;

        foreach (int value in compareValues)
        {
            // mapList�� �ִ� ���� ���� �ش� ���� �����ϸ� matchCount ����
            if (mapList.Contains(value))
            {
                matchCount++;
            }
        }

        // matchCount�� 2�� �̻��̸� false, �׷��� ������ true ��ȯ
        return matchCount < 2;
    }
    private bool CheckEndRoom()
    {
        int endCount = 0;

        for (int i = 0; i < mapList.Count; i++)
        {
            List<int> compareValues = new List<int> { mapList[i] + 10, mapList[i] - 10, mapList[i] + 1, mapList[i] - 1 };

            int matchCount = 0;

            // compareValues ���� mapList�� �� �� �����ϴ��� Ȯ��
            foreach (int value in compareValues)
            {
                if (mapList.Contains(value))
                {
                    matchCount++;
                }
            }

            // ������ ���� 1���� ��츸 �������� ����
            if (matchCount == 1)
            {
                endCount++;
            }
        }

        Debug.Log("EndCount : " + endCount);
        return endCount == endRoomNum; // ������ 3���� ��� true ��ȯ
    }
}
