
using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;
internal class SpartaTGMain
{
    private static CharacterInfo player;
    private static ItemInfo equipItem;
    static void Main(string[] args)
    {
        int choiceNum = 0;
        // 스파르타 텍스트 게임 메인

        GameDataSetting();
        MainStage(choiceNum);
        StatusManagementStage(choiceNum);
        InventoryManagement(choiceNum);
    }

    // 게임 캐릭터 생성
    static void GameDataSetting()
    {
        player = new CharacterInfo("Hana", "전사", 1, 10, 5, 100, 1500);
    }

    // 장착 아이템 내역
    static void ItemDateSetting()
    {
        equipItem = new ItemInfo(5, 2);
    }
    // MainStage 묶음 메소드
    static void MainStage(int choice)
    {
        MainStarMent();
        MainMenueView();
        ChoiceMent();
        int choiceNum = MainChoice();
        MainChoiceController(choiceNum);
    }

    // 상태보기 관리 묶음 메소드
    static void StatusManagementStage(int choice)
    {
        CharacterStatusMent();
        CharacterStatusView();
        ChoiceMent();
        int choiceNum = CharacterStatusChoice();
        CharacterStatusChoiceController(choiceNum);
    }

    // 인벤토리 관련 묶음 메소드
    static void InventoryManagement(int choice)
    {
        InventoryMent();
        InventoryView();
        ChoiceMent();
        int choiceNum = InventoryChoice();
        InventoryChoiceController(choiceNum);
    }

    // Main
    // 게임 시작 안내 메소드
    static void MainStarMent()
    {
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
    }
    // MainMene 화면 메소드
    static void MainMenueView()
    {
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 인벤토리 출력");
    }

    // 선택지 입력 안내 공용 메소드
    static void ChoiceMent()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
    }

    // MainMene 선택지 입력 메소드
    static int MainChoice()
    {
        while (true)
        {
            Console.Write(">> ");
            int choiceNum = int.Parse(Console.ReadLine());
            if (choiceNum == 1)
            {
                Console.WriteLine("상태보기로 이동합니다.");
                MainChoiceController(choiceNum);
                // 리턴이 비효율적이면 여기서 바로 상태보기화면 함수 호출로 변경.
                return choiceNum;
                break;
            }
            else if (choiceNum == 2)
            {
                Console.WriteLine("인벤토리로 이동합니다.");
                MainChoiceController(choiceNum);
                return choiceNum;
                break;
            }
            else
            {
                Console.WriteLine("다시 입력해주세요.");
            }
        }
    }

    // MainMenu 선택지 이동 메소드
    static void MainChoiceController(int choice)
    {
        int choiceNum = choice;
        if (choiceNum == 1) // 상태보기 이동
        {
            StatusManagementStage(choiceNum);
        }
        else if
        {   
            // 인벤토리 이동
            InventoryManagement(choiceNum);
        }

    }

    //Status
    // 상태보기 화면 소개 메소드
    static void CharacterStatusMent()
    {
        Console.Clear();
        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();
    }

    // 상태보기 화면 메뉴 메소드
    static void CharacterStatusView()
    {
        Console.WriteLine($"LV. {player.Level}");
        Console.WriteLine($"Chad. {player.Job}");
        Console.WriteLine($"공격력 : {player.Atk}");
        Console.WriteLine($"방어력 : {player.Def}");
        Console.WriteLine($"체  력 : {player.Hp}");
        Console.WriteLine($"Gold :  {player.Gold}");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
    }


    // 상태보기 선택 입력 메소드
    static int CharacterStatusChoice()
    {
        while (true)
        {
            Console.Write(">> ");
            int choiceNum = int.Parse(Console.ReadLine());
            if (choiceNum == 0)
            {
                Console.WriteLine("MainMene로 이동합니다.");
                CharacterStatusChoiceController(choiceNum);
                // 리턴이 비효율적이면 여기서 바로 상태보기화면 함수 호출로 변경.
                return choiceNum;
                break;
            }
            else
            {
                Console.WriteLine("다시 입력해주세요.");
            }
        }
    }

    //  CharacterStatus 선택지 이동 메소드
    static void CharacterStatusChoiceController(int choice)
    {
        int choiceNum = choice;
        if (choiceNum == 0)
        {
            MainStage(choiceNum);
        }
    }

    // Inventory
    // 인벤토리 안내 메소드
    static void InventoryMent()
    {
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
    }

    // 인벤토리 정보 화면 메뉴 메소드
    static void InventoryView()
    {
        // 장착표시, 능력치 출력 변수 연결 수정할 것 
        // 장착표시, 방어력 해당 변수 통해서 호출하고 출력 할 것
        Console.WriteLine($"-[E]무쇠갑옷        | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.");
        Console.WriteLine($"-낡은 검)           | 공격력 +2 | 쉽게 볼 수 있는 낡은 검입니다.");
        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");
    }

    // 인벤토리 선택지 입력 메소드
    static int InventoryChoice()
    {
        Console.Clear();
        while (true)
        {
            Console.Write(">> ");
            int choiceNum = int.Parse(Console.ReadLine());
            if (choiceNum == 1)
            {
                Console.WriteLine("장착관리로 이동합니다.");
                InventoryChoiceController(choiceNum);
                // 리턴이 비효율적이면 여기서 바로 상태보기화면 함수 호출로 변경.
                return choiceNum;
                break;
            }
            else if (choiceNum == 0)
            {
                Console.WriteLine("MainMene로 이동합니다.");
                InventoryChoiceController(choiceNum);
                return choiceNum;
                break;
            }
            else
            {
                Console.WriteLine("다시 입력해주세요.");
            }
        }
    }

    // 인벤토리 선택지 이동 메소드
    static void InventoryChoiceController(int choice)
    {
        int choiceNum = choice;

        if (choiceNum == 1)
        {
            EquipManageMent(choiceNum);//장착 관리 묶음 메소드
        }
        else if (choiceNum == 0)
        {
            MainStage(choiceNum); //MainMenu 화면 메뉴 메소드 
        }
    }

    // 장착관리 묶음 메소드
    static void EquipManageMent(int choice)
    {
        EquipManagementMent();
        // if 조건문으로 최초 게임화면일 경우
        EquipManagementFirstView();
        // 최초 이후 게임화면일 경우 보여질 장착관리 메뉴 화면 메소드 구분 할 것 
        // EquipManagementView();
        ChoiceMent();
        int choiceNum = EquipManagementChoice();

    }


    // EquipManagement
    // 장착관리 화면 소개 메소드
    static void EquipManagementMent()
    {
        Console.WriteLine("인벤토리 - 장착관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

    }

    // 장착 아이템 최초 화면 매뉴 메소드
    static void EquipManagementFirstView()
    {
        // 장착표시, 능력치 출력 변수 연결 수정할 것 
        // 장착표시, 방어력 해당 변수 통해서 호출하고 출력 할 것
        // item소개 메세지도 문자열 변수 또는 메서드로 출력 할 것
        Console.WriteLine($"- 1 [E]무쇠갑옷         | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.");
        Console.WriteLine($"- 2 낡은 검             | 공격력 +2 | 쉽게 볼 수 있는 낡은 검입니다.");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
    }

    // 장착 관리 화면 선택지 입력 메소드
    static int EquipManagementChoice()
    {
        Console.Clear();
        while (true)
        {
            Console.Write(">> ");
            int choiceNum = int.Parse(Console.ReadLine());
            if (choiceNum == 0) // 나가기 선택시
            {
                // 이동 멘트를 Controller에서 출력할지 여기서 할지 선택 할 것
                Console.WriteLine("MainMene로 이동합니다.");
                InventoryChoiceController(choiceNum);
                return choiceNum;
                break;

            }
            else if (choiceNum == 1) // 무쇠갑옷 선택시
            {
                // EquipManagementChoiceController에서 장착 함수 호출
                EquipManagementChoiceController(choiceNum);
                // 리턴이 비효율적이면 여기서 바로 상태보기화면 함수 호출로 변경.
                return choiceNum;
                break;
            }
            else if (choiceNum == 2) // 낡은 검 선택시
            {
                // EquipManagementChoiceController에서 장착 함수 호출
                EquipManagementChoiceController(choiceNum);
                return choiceNum;
                break;
            }
            else
            {
                Console.WriteLine("다시 입력해주세요.");
            }
        }
    }

    // 장비 관리 선택지 이동 메소드
    static void EquipManagementChoiceController(int choice)
    {
        int choiceNum = choice;

        if (choiceNum == 0) //나가기 선택시 
        {
            InventoryManageMent(choiceNum);
        }
        else if (choiceNum == 1)
        {

            // 장비 장착 탈착 변경 메소드 호출
        }
    }
    // 캐릭터 정보 클래스
    public class CharacterInfo
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public CharacterInfo(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }

    public class ItemInfo
    {

        int IronArmor { get; set; }
        int OldSword { get; set; }


        public ItemInfo(int ironArmor, int oldSword)
        {
            IronArmor = ironArmor;
            OldSword = oldSword;
        }


    }
}