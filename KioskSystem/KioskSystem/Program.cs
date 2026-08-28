// https://github.com/swchoi-dev/mp15-kioskSystem

using KioskSystem;

class Program
{
    private const string STORE_NAME = "올리브영 천호점";
    private const int MAX_MENU_COUNT = 2;
    
    static void Main(string[] args)
    {
        BasicPromotion basicPromotion = new BasicPromotion("기본할인", "3개 이상 10% 할인");
        
        MaskPack maskPack = new MaskPack(1, "메디힐", 10000, ItemCategory.마스크팩, basicPromotion);
        MaskPack maskPack2 = new MaskPack(2, "메디힐 풀에너지", 20000, ItemCategory.마스크팩, basicPromotion);
        
        List<Item> itemList = new List<Item>();
        
        itemList.Add(maskPack);
        itemList.Add(maskPack2);
        
        bool isStoreOpen = true;
        
        while (isStoreOpen)
        {
            Console.Clear();
            PrintKioskMain(itemList);
            
            KioskMenu picked = (KioskMenu)ConsoleInput.ReadIntInRange("번호 : ", 1, 4);
            switch (picked)
            {
                case KioskMenu.담기:
                    // 메뉴번호와 수량을 묻기
                    OrderItem(itemList);
                    break;
                case KioskMenu.전체비우기:
                    // 장바구니 통째로 비우기
                    ClearShoppingCart(itemList);
                    break;
                case KioskMenu.결제:
                    // 합계 금액 출력, 받은 금액 묻기
                    PayShoppingCart();
                    break;
                case KioskMenu.영업종료:
                    // 그날의 총 주문건수와 총 매출액 출력
                    isStoreOpen = false;
                    CloseStore();
                    break;
            }

            ConsoleInput.Pause();
        }
    }

    static void OrderItem(List<Item> items)
    {
        int picked = ConsoleInput.ReadIntInRange("담을 번호 : ", 1, 4);
        int amount = ConsoleInput.ReadIntInRange("개수 : ", 1, 10);

        items[picked-1].Count += amount;
    }

    static void ClearShoppingCart(List<Item> items)
    {
        foreach (Item item in items)
        {
            item.Count = 0;
        }
    }

    static void PayShoppingCart()
    {
        Console.WriteLine("결제");
    }

    static void CloseStore()
    {
        Console.WriteLine("영업 종료");
    }

    static void PrintKioskMain(List<Item> items)
    {
        Console.WriteLine("====================================");
        Console.WriteLine($"         {STORE_NAME}        ");
        Console.WriteLine("====================================");
        Console.WriteLine("[상품목록]");
        PrintItemList(items);
        Console.WriteLine("------------------------------------");
        Console.WriteLine("[장바구니]");
        PrintShoppingCart(items);
        Console.WriteLine("------------------------------------");
        Console.WriteLine("1. 담기   2. 전체 비우기   3. 결제   4. 영업 종료");
    }

    static void PrintItemList(List<Item> items)
    {
        int index = 1;
        foreach (Item item in items)
        {
            Console.WriteLine($"{index}. {item.Name} ({item.ItemCategory})  {item.Price}원  [{item.Promotion.Description}]");
            index++;
        }
    }
    static void PrintShoppingCart(List<Item> items)
    {
        bool hasItem = false;
        int totalPrice = 0;
        foreach (Item item in items)
        {
            if (item.Count != 0)
            {
                hasItem = true;
                totalPrice += item.Count * item.Price;
                Console.WriteLine($"{item.Name} x{item.Count}  {totalPrice}");
            }
        }

        if (hasItem)
        {
            Console.WriteLine($"합계 :  {totalPrice}원");
        }
    }
}