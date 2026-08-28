// https://github.com/swchoi-dev/mp15-kioskSystem

using KioskSystem;

class Program
{
    static void Main(string[] args)
    {
        bool isStoreOpen = true;
        while (isStoreOpen)
        {
            Console.Clear();

            int userInput = ConsoleInput.ReadIntInRange("번호 : ", 1, 4);
            switch (userInput)
            {
                case 1:
                    // 메뉴번호와 수량을 묻기
                    OrderItem();
                    break;
                case 2:
                    // 장바구니 통째로 비우기
                    ClearShoppingCart();
                    break;
                case 3:
                    // 합계 금액 출력, 받은 금액 묻기
                    PayShoppingCart();
                    break;
                case 4:
                    // 그날의 총 주문건수와 총 매출액 출력
                    isStoreOpen = false;
                    CloseStore();
                    break;
            }

            ConsoleInput.Pause();
        }
    }

    static void OrderItem()
    {
        Console.WriteLine("상품 담기");
    }

    static void ClearShoppingCart()
    {
        Console.WriteLine("장바구니 비우기");
    }

    static void PayShoppingCart()
    {
        Console.WriteLine("결제");
    }

    static void CloseStore()
    {
        Console.WriteLine("영업 종료");
    }
}