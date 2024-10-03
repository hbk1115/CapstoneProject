using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] protected GameObject mapsPrefeb;
    protected Dictionary<GameObject, int> mapImageObject;

    List<int> mapList = new();
    List<int> endMapList = new();

    int startPos;//���� ��ġ ��ȣ(����)
    int nextPosNum;//���� ��ǥ�� ��ȣ
    int maxMapSize;//���� �ִ� ������ ? * ? ����
    int mapLength;//���� �ִ� ���� ����

    int endRoomNum;//�� ���� ����

    [Header("�� ������")]
    [SerializeField] protected Sprite startMapIcon;
    [SerializeField] protected Sprite normalMapIcon;
    [SerializeField] protected Sprite shopMapIcon;
    [SerializeField] protected Sprite treasureMapIcon;
    [SerializeField] protected Sprite bossMapIcon;

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

            Vector2 newVec = new Vector2(posX * 80, posY * 80);

            newMapIcon.GetComponent<RectTransform>().localPosition = newVec;
            newMapIcon.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = mapList[i].ToString();

            //mapImageObject.Add(newMapIcon, mapList[i]);

            if (mapList[i] == startPos)
            {
                newMapIcon.GetComponent<Image>().sprite = startMapIcon;
            }
            else
            {
                if (mapList[i] == endMapList[0])
                {
                    newMapIcon.GetComponent<Image>().sprite = shopMapIcon;
                }
                else if(mapList[i] == endMapList[1])
                {
                    newMapIcon.GetComponent<Image>().sprite = treasureMapIcon;
                }
                else if (mapList[i] == endMapList[2])
                {
                    newMapIcon.GetComponent<Image>().sprite = bossMapIcon;
                }
                else
                {
                    newMapIcon.GetComponent<Image>().sprite = normalMapIcon;
                }
            }
            //newMapIcon.SetActive(true);
        }
    }
    private void RandomMapGenerator()
    {
        do
        {
            nextPosNum = startPos;
            mapList.Clear();
            endMapList.Clear();
            mapList.Add(startPos);

            RandomMapCreate();
        } while (!CheckEndRoom());//true�� endRoom�� ������ ���� ��ŭ ����
        EndRoomSort();
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
    private bool CheckEndRoom()//���� üũ �� ���� ����Ʈ ����
    {
        int endCount = 0;

        for (int i = 0; i < mapList.Count; i++)
        {
            if (mapList[i] == startPos)//���۹��� ����
                continue;

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
                endMapList.Add(mapList[i]);
                endCount++;
            }
        }

        Debug.Log("EndCount : " + endCount);
        return endCount == endRoomNum; // ������ 3���� ��� true ��ȯ
    }
    private void EndRoomSort()
    {
        var startCoord = ConvertToCoordinates(startPos);

        List<int> endRoom = new List<int>(endMapList);

        endMapList = endRoom.OrderBy(n => CalculateManhattanDistance(n)).ToList();

        for(int i = 0; i < endMapList.Count; i++)
        {
            Debug.Log("���� : " + endMapList[i]);
        }
    }
    private void SetMapIcon()
    {
        for(int i = 0;  i < mapImageObject.Count; i++)
        {
            
        }
        

    }
    //���ڸ� ��ǥ�� ����
    public (int x, int y) ConvertToCoordinates(int roomNumber)
    {
        int x = roomNumber % 10; // 1�� �ڸ� ���� X ��ǥ
        int y = roomNumber / 10; // 10�� �ڸ� ���� Y ��ǥ
        return (x, y);
    }
    //�Ÿ� ��� �Լ�
    public int CalculateManhattanDistance(int roomNumber)
    {
        var start = ConvertToCoordinates(startPos);
        var end = ConvertToCoordinates(roomNumber);

        return Math.Abs(start.x - end.x) + Math.Abs(start.y - end.y);
    }
}
