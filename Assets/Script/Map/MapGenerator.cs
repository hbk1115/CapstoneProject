using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// �� Ÿ�� ������, �� ���� ������ ��Ÿ���� �� ���
public enum ERoomType
{
    Elite = 0,
    Enemy = 1,
    Merchant = 2,
    Rest = 3,
    Treasure = 4,
    Unknown = 5,
    Size = 6
}

public class MapGenerator : MonoBehaviour
{
    [SerializeField] protected GameObject mapsPrefeb; // �� ������ ������
    protected Dictionary<GameObject, int> mapImageObject = new(); // �� �� �����ܰ� ��ġ ��ȣ�� �����ϴ� ��ųʸ�
    [SerializeField] protected GameObject mapIconTrans; // �� �������� �θ� ��ü (Transform)

    List<int> mapList = new(); // �� �� ��ġ�� �����ϴ� ����Ʈ
    List<int> endMapList = new(); // �� �� ��ġ�� �����ϴ� ����Ʈ

    int startPos; // ���� ��ġ ��ȣ
    int nextPosNum; // ���� ��ǥ ��ġ ��ȣ
    int maxMapSize; // ���� �ִ� ũ��
    int mapLength; // ���� �ִ� ����

    int endRoomNum; // �� ���� ����

    [Header("�� ������")]
    [SerializeField] protected Sprite startMapIcon; // ���� �� ������
    [SerializeField] protected Sprite normalMapIcon; // �Ϲ� �� ������
    [SerializeField] protected Sprite shopMapIcon; // ���� �� ������
    [SerializeField] protected Sprite treasureMapIcon; // ���� �� ������
    [SerializeField] protected Sprite bossMapIcon; // ���� �� ������

    private void Start()
    {
        Init(); // �ʱ�ȭ �Լ� ȣ��
    }

    private void Init()
    {
        maxMapSize = 7; // ���� �ִ� ũ�⸦ 7�� ����
        mapLength = 10; // ���� �ִ� ���̸� 10���� ����
        endRoomNum = 3; // �� ���� ������ 3���� ����
        startPos = ((maxMapSize / 2) * 10) + ((maxMapSize / 2) + 1); // ���� ��ġ�� �� �߾����� ����
        nextPosNum = startPos; // ���� ��ǥ ��ġ �ʱ�ȭ
        mapList.Add(startPos); // ���� ��ġ�� �� ����Ʈ�� �߰�
        RandomMapGenerator(); // �������� �� ���� �Լ� ȣ��
    }

<<<<<<< Updated upstream
    public void CreateMap(int num)//�������� ����(1,2,3)
    {
        for(int i = 0; i < mapIconTrans.transform.childCount; i++)
        {
            Destroy(mapIconTrans.transform.GetChild(i).gameObject);//���� ��� �� ������Ʈ �ı�
        }
        maxMapSize = 7;
        mapLength = 8 + (num * 2);
        endRoomNum = 3;
        startPos = ((maxMapSize / 2) * 10) + ((maxMapSize / 2) + 1);//�Ƹ� 34��
        Debug.Log("startPos : " + startPos);
        nextPosNum = startPos;
        mapList.Add(startPos);
        RandomMapGenerator();
    }
=======
>>>>>>> Stashed changes
    private void AddMap()
    {
        for (int i = 0; i < mapList.Count; i++) // �� �� ��ġ�� ����
        {
            GameObject newMapIcon = Instantiate(mapsPrefeb); // �� ������ ����

            newMapIcon.transform.SetParent(mapIconTrans.transform); // �� �������� �θ� ��ü�� ��ġ
            newMapIcon.transform.localScale = Vector3.one; // �� ������ ũ�� ����

            int posX = (mapList[i] % 10) - ((maxMapSize / 2) + 1); // X ��ǥ ���
            int posY = (mapList[i] / 10) - (maxMapSize / 2); // Y ��ǥ ���

            Vector2 newVec = new Vector2(posX * 80, posY * 80); // ������ ��ġ ����

            newMapIcon.GetComponent<RectTransform>().localPosition = newVec; // ������ ��ġ�� UI �� ��ġ
            newMapIcon.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = mapList[i].ToString(); // �����ܿ� �� ��ȣ ǥ��

            mapImageObject.Add(newMapIcon, mapList[i]); // ��ųʸ��� �����ܰ� �� ��ġ ����

            if (mapList[i] == startPos) // ���� ���� ���
            {
<<<<<<< Updated upstream
                newMapIcon.GetComponent<Image>().sprite = startMapIcon;
                OpenMap(newMapIcon);
                Debug.Log(startPos + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
=======
                newMapIcon.GetComponent<Image>().sprite = startMapIcon; // ���� ���������� ����
>>>>>>> Stashed changes
            }
            else
            {
                if (mapList[i] == endMapList[0]) // ù ��° �� ���� ���
                {
<<<<<<< Updated upstream
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
                    newMapIcon.GetComponent<Image>().sprite = shopMapIcon; // ���� ���������� ����
                    newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners(); // ��ư Ŭ�� �̺�Ʈ �ʱ�ȭ
                    newMapIcon.GetComponent<Button>().onClick.AddListener(() => // Ŭ�� �� ������ ���� ���
                    {
                        newMapIcon.GetComponent<Button>().enabled = false; // ��ư ��Ȱ��ȭ
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // �� ����
                        MerchantRoomUI.instance.EnterMerchantRoom(); // ���� ǥ�� �Լ� ȣ��
                        OpenMap(newMapIcon); // �� ����
                        UIManager.instance.SetMapUI(false); // �� UI �ݱ�
                    });
                }
                else if (mapList[i] == endMapList[1])
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
                    newMapIcon.GetComponent<Image>().sprite = treasureMapIcon;
                    newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners();
                    newMapIcon.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        newMapIcon.GetComponent<Button>().enabled = false;
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
                        RewardManager.instance.ShowReward();
                        OpenMap(newMapIcon);
                        UIManager.instance.SetMapUI(false);//�� �ݱ�
=======
                    newMapIcon.GetComponent<Image>().sprite = shopMapIcon; // ���� ���������� ����
                    //newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners(); // ��ư Ŭ�� �̺�Ʈ �ʱ�ȭ
                    //newMapIcon.GetComponent<Button>().onClick.AddListener(() => // Ŭ�� �� ������ ���� ���
                    //{
                    //    newMapIcon.GetComponent<Button>().enabled = false; // ��ư ��Ȱ��ȭ
                    //    newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // �� ����
                    //    MerchantRoomUI.instance.EnterMerchantRoom(); // ���� ǥ�� �Լ� ȣ��
                    //    OpenMap(newMapIcon); // �� ����
                    //    UIManager.instance.SetMapUI(false); // �� UI �ݱ�
                    //});
                }
                else if (mapList[i] == endMapList[1]) // �� ��° �� ���� ���
                {
                    newMapIcon.GetComponent<Image>().sprite = treasureMapIcon; // ���� ���������� ����
                    newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners(); // ��ư Ŭ�� �̺�Ʈ �ʱ�ȭ
                    newMapIcon.GetComponent<Button>().onClick.AddListener(() => // Ŭ�� �� ������ ���� ���
                    {
                        newMapIcon.GetComponent<Button>().enabled = false; // ��ư ��Ȱ��ȭ
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // �� ����
                        RewardManager.instance.ShowReward(); // ���� ǥ�� �Լ� ȣ��
                        OpenMap(newMapIcon); // �� ����
                        UIManager.instance.SetMapUI(false); // �� UI �ݱ�
>>>>>>> Stashed changes
                    });
                }
                else if (mapList[i] == endMapList[2]) // �� ��° �� ���� ���
                {
<<<<<<< Updated upstream
                    newMapIcon.GetComponent<Image>().sprite = bossMapIcon;
                    newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners();
                    newMapIcon.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
                        newMapIcon.GetComponent<Button>().enabled = false;
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
                        RoomManager.instance.EnterRoom(ERoomType.Elite);
                        OpenMap(newMapIcon);
                        UIManager.instance.SetMapUI(false);
                        CreateMap(2);//������ ���鼭 �� ����� ���� >> �ϴ� ����� �־� ��. ���� �ɸ��� �ֱ� ����
                    });
=======
                    newMapIcon.GetComponent<Image>().sprite = bossMapIcon; // ���� ���������� ����
>>>>>>> Stashed changes
                }
                else // �Ϲ� ���� ���
                {
                    newMapIcon.GetComponent<Image>().sprite = normalMapIcon; // �Ϲ� ���������� ����
                    newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners(); // ��ư Ŭ�� �̺�Ʈ �ʱ�ȭ
                    newMapIcon.GetComponent<Button>().onClick.AddListener(() => // Ŭ�� �� ���� ���
                    {
<<<<<<< Updated upstream
                        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
                        newMapIcon.GetComponent<Button>().enabled = false;
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
                        RoomManager.instance.EnterRoom(ERoomType.Enemy);
                        OpenMap(newMapIcon);
                        UIManager.instance.SetMapUI(false);//�� �ݱ�
                        
=======
                        newMapIcon.GetComponent<Button>().enabled = false; // ��ư ��Ȱ��ȭ
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // �� ����
                        RoomManager.instance.EnterRoom(ERoomType.Enemy); // �� �� ����
                        Debug.Log("asd" + newMapIcon); // ����� �޽��� ���
                        OpenMap(newMapIcon); // �� ����
                        UIManager.instance.SetMapUI(false); // �� UI �ݱ�
>>>>>>> Stashed changes
                    });
                }
            }

            newMapIcon.SetActive(false); // �������� ��Ȱ��ȭ
        }
        var key_main = mapImageObject.FirstOrDefault(x => x.Value == startPos).Key; // ���� �� ������ �˻�
        OpenMap(key_main); // ���� �� ����
    }

    private void RandomMapGenerator()
    {
        do
        {
<<<<<<< Updated upstream
            nextPosNum = startPos;
            mapList.Clear();
            endMapList.Clear();
            mapList.Add(startPos);
            mapImageObject.Clear();
=======
            nextPosNum = startPos; // ���� ��ġ�� �ʱ�ȭ
            mapList.Clear(); // �� ����Ʈ �ʱ�ȭ
            endMapList.Clear(); // �� �� ����Ʈ �ʱ�ȭ
            mapList.Add(startPos); // ���� �� �߰�

            RandomMapCreate(); // �������� �� ����
        } while (!CheckEndRoom()); // �� ���� ������ ������ŭ ���� ������ �ݺ�
        EndRoomSort(); // �� �� ����
        AddMap(); // �� ������ �߰�
    }
>>>>>>> Stashed changes

    private void RandomMapCreate()
    {
        while (mapList.Count < mapLength) // �� ���̸�ŭ �ݺ�
        {
            int random; // ���� ���� ����
            int nextNum = 0; // ���� �� ��ȣ

            do
            {
                random = UnityEngine.Random.Range(0, 4); // ���� ���� ����

                switch (random)
                {
                    case 0:
                        nextNum = 10; // �Ʒ�
                        break;
                    case 1:
                        nextNum = -10; // ��
                        break;
                    case 2:
                        nextNum = 1; // ������
                        break;
                    case 3:
                        nextNum = -1; // ����
                        break;
                }

            } while (((nextPosNum + nextNum) / 10) < 0 || ((nextPosNum + nextNum) / 10) > maxMapSize - 1 || ((nextPosNum + nextNum) % 10) < 1 || ((nextPosNum + nextNum) % 10) > maxMapSize);

            nextPosNum += nextNum; // ���� ��ġ�� �̵�

            if (mapList.Contains(nextPosNum)) // �̹� ���Ե� ��ġ�� ����
            {
                continue;
            }

            if (CheckMapList(nextPosNum)) // �̵� ������ ��ġ���� Ȯ��
            {
                mapList.Add(nextPosNum); // �̵� �����ϸ� ����Ʈ�� �߰�
            }
            else
            {
                int RandomMapListNum = UnityEngine.Random.Range(0, mapList.Count);
                nextPosNum = mapList[RandomMapListNum]; // ������ ��ġ�� �̵�
                continue;
            }
        }
    }

    private bool CheckMapList(int mapNum) // ���� ���� ���¸� Ȯ��
    {
        List<int> compareValues = new List<int> { mapNum + 10, mapNum - 10, mapNum + 1, mapNum - 1 };

        int matchCount = 0; // ����� �� ����

        foreach (int value in compareValues)
        {
            if (mapList.Contains(value)) // ����� ���� �ִ��� Ȯ��
            {
                matchCount++;
            }
        }

        return matchCount > 1; // �� �� �̻��� ���� ����Ǿ�� ��
    }

    private bool CheckEndRoom() // �� �� ������ Ȯ��
    {
        int count = 0;
        foreach (int map in mapList)
        {
            int connectCount = 0;

            if (mapList.Contains(map + 10)) connectCount++;
            if (mapList.Contains(map - 10)) connectCount++;
            if (mapList.Contains(map + 1)) connectCount++;
            if (mapList.Contains(map - 1)) connectCount++;

            if (connectCount == 1) count++; // ����� ���� �ϳ��� �� ��
            if (count == endRoomNum) return true; // �� �� ���� ���� �� true ��ȯ
        }
        return false;
    }

    private void EndRoomSort() // �� ���� ����Ʈ�� �߰��ϰ� ����
    {
        foreach (int map in mapList)
        {
            int connectCount = 0;

            if (mapList.Contains(map + 10)) connectCount++;
            if (mapList.Contains(map - 10)) connectCount++;
            if (mapList.Contains(map + 1)) connectCount++;
            if (mapList.Contains(map - 1)) connectCount++;

            if (connectCount == 1) // �� ������ ����
            {
                endMapList.Add(map);
            }
        }

        endMapList.Sort(); // �� �� ����Ʈ ����
    }

    private void OpenMap(GameObject openMapIcon) // �� ������ ����
    {
        openMapIcon.SetActive(true);
    }
}
