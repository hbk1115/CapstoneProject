using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// 방 타입 열거형, 각 방의 종류를 나타내는 데 사용
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
    [SerializeField] protected GameObject mapsPrefeb; // 맵 아이콘 프리팹
    protected Dictionary<GameObject, int> mapImageObject = new(); // 각 맵 아이콘과 위치 번호를 연결하는 딕셔너리
    [SerializeField] protected GameObject mapIconTrans; // 맵 아이콘의 부모 객체 (Transform)

    List<int> mapList = new(); // 맵 방 위치를 저장하는 리스트
    List<int> endMapList = new(); // 끝 방 위치를 저장하는 리스트

    int startPos; // 시작 위치 번호
    int nextPosNum; // 다음 목표 위치 번호
    int maxMapSize; // 맵의 최대 크기
    int mapLength; // 맵의 최대 길이

    int endRoomNum; // 끝 방의 개수

    [Header("맵 아이콘")]
    [SerializeField] protected Sprite startMapIcon; // 시작 방 아이콘
    [SerializeField] protected Sprite normalMapIcon; // 일반 방 아이콘
    [SerializeField] protected Sprite shopMapIcon; // 상점 방 아이콘
    [SerializeField] protected Sprite treasureMapIcon; // 보물 방 아이콘
    [SerializeField] protected Sprite bossMapIcon; // 보스 방 아이콘

    private void Start()
    {
        Init(); // 초기화 함수 호출
    }

    private void Init()
    {
        maxMapSize = 7; // 맵의 최대 크기를 7로 설정
        mapLength = 10; // 맵의 최대 길이를 10으로 설정
        endRoomNum = 3; // 끝 방의 개수를 3으로 설정
        startPos = ((maxMapSize / 2) * 10) + ((maxMapSize / 2) + 1); // 시작 위치를 맵 중앙으로 설정
        nextPosNum = startPos; // 다음 목표 위치 초기화
        mapList.Add(startPos); // 시작 위치를 맵 리스트에 추가
        RandomMapGenerator(); // 랜덤으로 맵 생성 함수 호출
    }

<<<<<<< Updated upstream
    public void CreateMap(int num)//스테이지 받음(1,2,3)
    {
        for(int i = 0; i < mapIconTrans.transform.childCount; i++)
        {
            Destroy(mapIconTrans.transform.GetChild(i).gameObject);//먼저 모든 맵 오브젝트 파괴
        }
        maxMapSize = 7;
        mapLength = 8 + (num * 2);
        endRoomNum = 3;
        startPos = ((maxMapSize / 2) * 10) + ((maxMapSize / 2) + 1);//아마 34임
        Debug.Log("startPos : " + startPos);
        nextPosNum = startPos;
        mapList.Add(startPos);
        RandomMapGenerator();
    }
=======
>>>>>>> Stashed changes
    private void AddMap()
    {
        for (int i = 0; i < mapList.Count; i++) // 각 맵 위치에 대해
        {
            GameObject newMapIcon = Instantiate(mapsPrefeb); // 맵 아이콘 생성

            newMapIcon.transform.SetParent(mapIconTrans.transform); // 맵 아이콘을 부모 객체에 배치
            newMapIcon.transform.localScale = Vector3.one; // 맵 아이콘 크기 설정

            int posX = (mapList[i] % 10) - ((maxMapSize / 2) + 1); // X 좌표 계산
            int posY = (mapList[i] / 10) - (maxMapSize / 2); // Y 좌표 계산

            Vector2 newVec = new Vector2(posX * 80, posY * 80); // 아이콘 위치 설정

            newMapIcon.GetComponent<RectTransform>().localPosition = newVec; // 아이콘 위치를 UI 상에 배치
            newMapIcon.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = mapList[i].ToString(); // 아이콘에 맵 번호 표시

            mapImageObject.Add(newMapIcon, mapList[i]); // 딕셔너리에 아이콘과 맵 위치 저장

            if (mapList[i] == startPos) // 시작 방인 경우
            {
<<<<<<< Updated upstream
                newMapIcon.GetComponent<Image>().sprite = startMapIcon;
                OpenMap(newMapIcon);
                Debug.Log(startPos + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
=======
                newMapIcon.GetComponent<Image>().sprite = startMapIcon; // 시작 아이콘으로 설정
>>>>>>> Stashed changes
            }
            else
            {
                if (mapList[i] == endMapList[0]) // 첫 번째 끝 방인 경우
                {
<<<<<<< Updated upstream
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
                    newMapIcon.GetComponent<Image>().sprite = shopMapIcon; // 상점 아이콘으로 설정
                    newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners(); // 버튼 클릭 이벤트 초기화
                    newMapIcon.GetComponent<Button>().onClick.AddListener(() => // 클릭 시 실행할 동작 등록
                    {
                        newMapIcon.GetComponent<Button>().enabled = false; // 버튼 비활성화
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // 색 변경
                        MerchantRoomUI.instance.EnterMerchantRoom(); // 상점 표시 함수 호출
                        OpenMap(newMapIcon); // 맵 열기
                        UIManager.instance.SetMapUI(false); // 맵 UI 닫기
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
                        UIManager.instance.SetMapUI(false);//맵 닫기
=======
                    newMapIcon.GetComponent<Image>().sprite = shopMapIcon; // 상점 아이콘으로 설정
                    //newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners(); // 버튼 클릭 이벤트 초기화
                    //newMapIcon.GetComponent<Button>().onClick.AddListener(() => // 클릭 시 실행할 동작 등록
                    //{
                    //    newMapIcon.GetComponent<Button>().enabled = false; // 버튼 비활성화
                    //    newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // 색 변경
                    //    MerchantRoomUI.instance.EnterMerchantRoom(); // 상점 표시 함수 호출
                    //    OpenMap(newMapIcon); // 맵 열기
                    //    UIManager.instance.SetMapUI(false); // 맵 UI 닫기
                    //});
                }
                else if (mapList[i] == endMapList[1]) // 두 번째 끝 방인 경우
                {
                    newMapIcon.GetComponent<Image>().sprite = treasureMapIcon; // 보물 아이콘으로 설정
                    newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners(); // 버튼 클릭 이벤트 초기화
                    newMapIcon.GetComponent<Button>().onClick.AddListener(() => // 클릭 시 실행할 동작 등록
                    {
                        newMapIcon.GetComponent<Button>().enabled = false; // 버튼 비활성화
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // 색 변경
                        RewardManager.instance.ShowReward(); // 보상 표시 함수 호출
                        OpenMap(newMapIcon); // 맵 열기
                        UIManager.instance.SetMapUI(false); // 맵 UI 닫기
>>>>>>> Stashed changes
                    });
                }
                else if (mapList[i] == endMapList[2]) // 세 번째 끝 방인 경우
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
                        CreateMap(2);//보스방 들어가면서 맵 만들기 시작 >> 일단 만들어 둬야 함. 오래 걸릴수 있기 때문
                    });
=======
                    newMapIcon.GetComponent<Image>().sprite = bossMapIcon; // 보스 아이콘으로 설정
>>>>>>> Stashed changes
                }
                else // 일반 방인 경우
                {
                    newMapIcon.GetComponent<Image>().sprite = normalMapIcon; // 일반 아이콘으로 설정
                    newMapIcon.GetComponent<Button>().onClick.RemoveAllListeners(); // 버튼 클릭 이벤트 초기화
                    newMapIcon.GetComponent<Button>().onClick.AddListener(() => // 클릭 시 동작 등록
                    {
<<<<<<< Updated upstream
                        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
                        newMapIcon.GetComponent<Button>().enabled = false;
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
                        RoomManager.instance.EnterRoom(ERoomType.Enemy);
                        OpenMap(newMapIcon);
                        UIManager.instance.SetMapUI(false);//맵 닫기
                        
=======
                        newMapIcon.GetComponent<Button>().enabled = false; // 버튼 비활성화
                        newMapIcon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // 색 변경
                        RoomManager.instance.EnterRoom(ERoomType.Enemy); // 적 방 입장
                        Debug.Log("asd" + newMapIcon); // 디버그 메시지 출력
                        OpenMap(newMapIcon); // 맵 열기
                        UIManager.instance.SetMapUI(false); // 맵 UI 닫기
>>>>>>> Stashed changes
                    });
                }
            }

            newMapIcon.SetActive(false); // 아이콘을 비활성화
        }
        var key_main = mapImageObject.FirstOrDefault(x => x.Value == startPos).Key; // 시작 방 아이콘 검색
        OpenMap(key_main); // 시작 방 열기
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
            nextPosNum = startPos; // 시작 위치로 초기화
            mapList.Clear(); // 맵 리스트 초기화
            endMapList.Clear(); // 끝 방 리스트 초기화
            mapList.Add(startPos); // 시작 방 추가

            RandomMapCreate(); // 랜덤으로 맵 생성
        } while (!CheckEndRoom()); // 끝 방이 정해진 개수만큼 나올 때까지 반복
        EndRoomSort(); // 끝 방 정렬
        AddMap(); // 맵 아이콘 추가
    }
>>>>>>> Stashed changes

    private void RandomMapCreate()
    {
        while (mapList.Count < mapLength) // 맵 길이만큼 반복
        {
            int random; // 랜덤 방향 변수
            int nextNum = 0; // 다음 방 번호

            do
            {
                random = UnityEngine.Random.Range(0, 4); // 방향 랜덤 지정

                switch (random)
                {
                    case 0:
                        nextNum = 10; // 아래
                        break;
                    case 1:
                        nextNum = -10; // 위
                        break;
                    case 2:
                        nextNum = 1; // 오른쪽
                        break;
                    case 3:
                        nextNum = -1; // 왼쪽
                        break;
                }

            } while (((nextPosNum + nextNum) / 10) < 0 || ((nextPosNum + nextNum) / 10) > maxMapSize - 1 || ((nextPosNum + nextNum) % 10) < 1 || ((nextPosNum + nextNum) % 10) > maxMapSize);

            nextPosNum += nextNum; // 다음 위치로 이동

            if (mapList.Contains(nextPosNum)) // 이미 포함된 위치면 무시
            {
                continue;
            }

            if (CheckMapList(nextPosNum)) // 이동 가능한 위치인지 확인
            {
                mapList.Add(nextPosNum); // 이동 가능하면 리스트에 추가
            }
            else
            {
                int RandomMapListNum = UnityEngine.Random.Range(0, mapList.Count);
                nextPosNum = mapList[RandomMapListNum]; // 임의의 위치로 이동
                continue;
            }
        }
    }

    private bool CheckMapList(int mapNum) // 맵의 연결 상태를 확인
    {
        List<int> compareValues = new List<int> { mapNum + 10, mapNum - 10, mapNum + 1, mapNum - 1 };

        int matchCount = 0; // 연결된 방 개수

        foreach (int value in compareValues)
        {
            if (mapList.Contains(value)) // 연결된 방이 있는지 확인
            {
                matchCount++;
            }
        }

        return matchCount > 1; // 두 개 이상의 방이 연결되어야 함
    }

    private bool CheckEndRoom() // 끝 방 개수를 확인
    {
        int count = 0;
        foreach (int map in mapList)
        {
            int connectCount = 0;

            if (mapList.Contains(map + 10)) connectCount++;
            if (mapList.Contains(map - 10)) connectCount++;
            if (mapList.Contains(map + 1)) connectCount++;
            if (mapList.Contains(map - 1)) connectCount++;

            if (connectCount == 1) count++; // 연결된 방이 하나면 끝 방
            if (count == endRoomNum) return true; // 끝 방 개수 충족 시 true 반환
        }
        return false;
    }

    private void EndRoomSort() // 끝 방을 리스트에 추가하고 정렬
    {
        foreach (int map in mapList)
        {
            int connectCount = 0;

            if (mapList.Contains(map + 10)) connectCount++;
            if (mapList.Contains(map - 10)) connectCount++;
            if (mapList.Contains(map + 1)) connectCount++;
            if (mapList.Contains(map - 1)) connectCount++;

            if (connectCount == 1) // 끝 방으로 간주
            {
                endMapList.Add(map);
            }
        }

        endMapList.Sort(); // 끝 방 리스트 정렬
    }

    private void OpenMap(GameObject openMapIcon) // 맵 아이콘 열기
    {
        openMapIcon.SetActive(true);
    }
}
