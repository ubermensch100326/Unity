using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// syntax hilighting 안되면 C# 설정에서 아래 추가
//   "editor.semanticHighlighting.enabled": true,
//   "csharp.semanticHighlighting.enabled": true,

public class NewBehaviourScript : MonoBehaviour
{
    // 변수 선언 및 초기화
    int level = 5;
    float strength = 15.5f;
    string playerName = "나검사";
    bool isFulllevel = false;
    int health = 30;
    void Start()
    {
        Debug.Log("Hello Unity");
        // 그룹형 변수
        string[] monsters = { "슬라임", "사막뱀", "악마" };
        /* Debug.Log("맵에 존재하는 몬스터");
        Debug.Log(monsters[0]);
        Debug.Log(monsters[1]);
        Debug.Log(monsters[2]); */
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 6;
        monsterLevel[2] = 20;

        Debug.Log("맵에 존재하는 몬스터의 레벨");
        Debug.Log(monsterLevel[0]);
        Debug.Log(monsterLevel[1]);
        Debug.Log(monsterLevel[2]);


        List<string> items = new List<string>();
        items.Add("생명물약30");
        items.Add("마나물약30");

        Debug.Log("가지고 있는 아이템");
        Debug.Log(items[0]);
        Debug.Log(items[1]);

        // 리스트는 안에 있는 데이터를 삭제할 수 있음
        // items.RemoveAt[0]

        // 연산자
        int exp = 1500;
        exp = 1500 + 320;
        exp = exp - 10;
        level = exp / 300;
        strength = level * 3.1f;

        Debug.Log("용사의 이름은?");
        Debug.Log(playerName);
        Debug.Log("용사의 레벨은?");
        Debug.Log(level);
        Debug.Log("용사의 힘은?");
        Debug.Log(strength);
        Debug.Log("용사는 만렙인가?");
        Debug.Log(isFulllevel);

        int nextExp = 300 - (exp % 300);
        Debug.Log("다음 레벨까지 남은 경험치는?");
        Debug.Log(nextExp);

        string title = "전설의";
        Debug.Log("용사의 이름은?");
        Debug.Log(title + " " + playerName);

        int fullLevel = 99;
        isFullLevel = level == fullLevel;
        Debug.Log("용사는 만렙입니까?" + isFullLevel);

        bool isEndTutorial = level > 10;
        Debug.Log("튜토리얼이 끝난 용사입니까?" + isEndTutorial);


        int mana = 25;
        bool isBadCondition = health <= 50 || mana <= 20;

        string condition = isBandCondition ? "나쁨" : "좋음";


        // 키워드
        // int float string bool new List

        // 조건문
        if (condition == "나쁨")
        {
            Debug.Log("플레이어 상태가 나쁘니 아이템을 사용하세요.");
        }
        else
        {
            Debug.Log("플레이어 상태가 좋습니다.");
        }

        if (isBadCondition && items[0] == "생명물약30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("생명포션30을 사용하였습니다.");
        }
        else if (isBadCondition && items[0] == "마나물약30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("마나포션30을 사용하였습니다.");
        }

        switch (monsters[1])
        {
            case "슬라임":
            case "사막뱀":
                Debug.Log("소형 몬스터가 출현!");
                break;
            case "악마":
                Debug.Log("중형 몬스터가 출현!");
                break;
            case "골렘":
                Debug.Log("대형 몬스터가 출현!");
                break;
            default:
                Debug.Log("??? 몬스터가 출현!");
                break;
        }

        while (health > 0)
        {
            health--;
            if (health > 0)
            {
                Debug.Log("독 데미지를 입었습니다." + health);
            }
            else
            {
                Debug.Log("사망하였습니다.");
            }
        }

        for (int count = 0; count < 10; count++)
        {
            health;
            Debug.Log("붕대로 치료 중.." + health);
        }

        for (int index = 0; index < monsters.Length; intex++)
        {
            Debug.Log("이 지역에 있는 몬스터 : " + monsters[index]);
        }

        foreach (string monster in monsters)
        {
            Debug.Log("이 지역에 있는 몬스터 : " + monster);
        }

        Heal();

        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("용사는" + monsters[index] + "에게" + Battel(monsterLever[index]));
        }




    }

    // 함수 (메소드)
    void Heal()
    {
        health += 10;
        Debug.Log("힐을 받았습니다. " + health);
    }

    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
            result = "이겼습니다.";
        else
            result = "졌습니다.";
        return result;
    }










}


