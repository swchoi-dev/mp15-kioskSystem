// https://github.com/swchoi-dev/mp15-kioskSystem

using KioskSystem;

class Program
{
    private const string STORE_NAME = "올리브영 천호점";
    private const int MAX_MENU_COUNT = 5;

    static private int totalCartPrice = 0;
    static private int totalOderCount = 0;
    static private int totalProfit = 0;
    
    static void Main(string[] args)
    {
        BasicPromotion basicPromotion = new BasicPromotion();
        
        MaskPack maskPack = new MaskPack(1, "메디힐", 1000, ItemCategory.마스크팩, basicPromotion);
        MaskPack maskPack2 = new MaskPack(2, "메디힐 풀에너지 10개 입", 10000, ItemCategory.마스크팩, basicPromotion);
        BodyLotion bodyLotion = new BodyLotion(3, "밀크바디", 3500, ItemCategory.바디케어, basicPromotion);
        SunCream sunCream = new SunCream(4, "셀퓨전씨 선크림 SPF+++", 13000, ItemCategory.스킨케어, basicPromotion);
        Shampoo shampoo = new Shampoo(5, "탈모 방지 남성용 헤어샴푸", 30000, ItemCategory.헤어케어, basicPromotion);
        
        
        List<Item> itemList = new List<Item>();
        
        itemList.Add(maskPack);
        itemList.Add(maskPack2);
        itemList.Add(bodyLotion);
        itemList.Add(sunCream);
        itemList.Add(shampoo);
        
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
                    ClearShoppingCart(itemList);
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
        int picked = ConsoleInput.ReadIntInRange("담을 번호 : ", 1, MAX_MENU_COUNT);
        int amount = ConsoleInput.ReadIntInRange("개수 : ", 1, 10);

        items[picked-1].Count += amount;
    }

    static void ClearShoppingCart(List<Item> items)
    {
        foreach (Item item in items)
        {
            item.Count = 0;
        }

        totalCartPrice = 0;
    }

    static void PayShoppingCart()
    {
        if (totalCartPrice == 0)
        {
            Console.WriteLine($"결제할 항목이 없습니다.");
            return;
        }
        Console.WriteLine($"합계 금액 :  {totalCartPrice}");
        int inputMoney = ConsoleInput.ReadIntInRange("받은 금액 : ", totalCartPrice, Int32.MaxValue);
        int returnMoney = inputMoney - totalCartPrice;
        Console.WriteLine($"반환 금액 :  {returnMoney}");

        totalOderCount++;
        totalProfit += totalCartPrice;
    }

    static void CloseStore()
    {
        Console.WriteLine("====================================");
        Console.WriteLine("영업 종료");
        Console.WriteLine($"총 주문 :  {totalOderCount}건");
        Console.WriteLine($"총 매출 :  {totalProfit}원");
        Console.WriteLine("====================================");
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
        totalCartPrice = 0;
        foreach (Item item in items)
        {
            if (item.Count != 0)
            {
                hasItem = true;
                Console.WriteLine($"{item.Name} x{item.Count}  {item.GetPromotionPrice()}");
                totalCartPrice += item.GetPromotionPrice();
            }
        }

        if (hasItem)
        {
            Console.WriteLine($"합계 :  {totalCartPrice}원");
        }
    }
}