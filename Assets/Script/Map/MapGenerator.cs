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

    int startPos;//센터 위치 번호(시작)
    int nextPosNum;//다음 목표의 번호
    int maxMapSize;//맵의 최대 사이즈 ? * ? 지정
    int mapLength;//맵의 최대 길이 지정

    int endRoomNum;//끝 방의 개수

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        maxMapSize = 7;
        mapLength = 10;
        endRoomNum = 3;
        startPos = ((maxMapSize / 2) * 10) + ((maxMapSize / 2) + 1);//아마 34임
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
        } while (!CheckEndRoom());//true면 endRoom이 정해진 개수 만큼 나옴

        AddMap();
    } 
    private void RandomMapCreate()
    {
        while(mapList.Count < mapLength)//원하는 맵 개수 나올 때 까지
        {
            int random;//랜덤 방향 지정
            int nextNum = 0;
            do
            {
                random = UnityEngine.Random.Range(0, 4);

                switch (random)
                {
                    case 0:
                        nextNum = 10;//아래
                        break;
                    case 1:
                        nextNum = -10;//위
                        break;
                    case 2:
                        nextNum = 1;//오른쪽
                        break;
                    case 3:
                        nextNum = -1;//왼쪽
                        break;
                }

            } while (((nextPosNum + nextNum) / 10) < 0 || ((nextPosNum + nextNum) / 10) > maxMapSize - 1 || ((nextPosNum + nextNum) % 10) < 1 || ((nextPosNum + nextNum) % 10) > maxMapSize);

            nextPosNum += nextNum;//다음으로 이동할 위치를 지정

            if (mapList.Contains(nextPosNum))//이미 있는 번호라면 무시하고 다시
            {
                continue;
            }

            if (CheckMapList(nextPosNum))//false면 이동 불가능한 위치임, true면 이동 가능
            {
                mapList.Add(nextPosNum);
            }
            else
            {
                int RandomMapListNum = UnityEngine.Random.Range(0, mapList.Count);
                nextPosNum = mapList[RandomMapListNum];//임의의 위치로 이동시켜버림
                continue;
            }

        }
    }

    private bool CheckMapList(int mapNum)//맵이 정상적으로 펼쳐지는지 확인
    {
        List<int> compareValues = new List<int> { mapNum + 10, mapNum - 10, mapNum + 1, mapNum - 1 };

        // mapList에서 compareValues의 값이 몇 개 있는지 카운트
        int matchCount = 0;

        foreach (int value in compareValues)
        {
            // mapList에 있는 값과 비교해 해당 값이 존재하면 matchCount 증가
            if (mapList.Contains(value))
            {
                matchCount++;
            }
        }

        // matchCount가 2개 이상이면 false, 그렇지 않으면 true 반환
        return matchCount < 2;
    }
    private bool CheckEndRoom()
    {
        int endCount = 0;

        for (int i = 0; i < mapList.Count; i++)
        {
            List<int> compareValues = new List<int> { mapList[i] + 10, mapList[i] - 10, mapList[i] + 1, mapList[i] - 1 };

            int matchCount = 0;

            // compareValues 값이 mapList에 몇 개 존재하는지 확인
            foreach (int value in compareValues)
            {
                if (mapList.Contains(value))
                {
                    matchCount++;
                }
            }

            // 인접한 방이 1개인 경우만 끝방으로 간주
            if (matchCount == 1)
            {
                endCount++;
            }
        }

        Debug.Log("EndCount : " + endCount);
        return endCount == endRoomNum; // 끝방이 3개인 경우 true 반환
    }
}
