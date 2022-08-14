using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rich_and_Bankrupt
{
    class Program
    {
        static int cash = 1000;
        static int materials = 0;
        static int product = 0;
        static int stock = 0;
        static int realestate = 0;
        static void Main(string[] args)
        {
            // List assets 구성 원소 <cash, materials, product, stock, realestate> <현금, 원재료, 제품, 주식, 부동산>

            List<int> assets = new List<int>();
            assets.Add(cash); // 현금, 천만원이나 일단 구현이 되는지 확인을 위해 만원 단위를 생략하여 작성함
            assets.Add(materials); // 원재료
            assets.Add(product); // 제품
            assets.Add(stock); ; // 주식
            assets.Add(realestate); // 부동산

            long totalassets = assets.Sum(); // totalassets = assets list내 모든 원소의 합, 현금만 21억일 때, 종료되므로 더 큰 자료형 long 사용
            
            Console.WriteLine(@"안녕하십니까. 부자와 파산게임에 오신 것을 환영합니다. 게임 규칙을 설명드리겠습니다.
유동자산은 현금화할 가능성이 높다는 의미, 반대로 비유동자산은 현금화할 가능성이 낮다는 의미를 가집니다.
따라서 현금은 매각 가능성 즉, 현금화할 가능성은 100이나, 게임 내에서 의미가 없을 뿐더러, 현금은 재화로만 쓰입니다.
본 게임 내에서 유동자산은 현금, 원재료, 제품이며, 비유동자산은 주식, 부동산입니다.
투자는 원재료, 제품, 주식, 부동산에 할 수 있으며, 유동자산과 비유동자산에 따라 판매하여 현금화할 가능성이 나눠집니다.
즉, 원재료, 제품은 현금화하기 쉽다는 것이고, 주식, 부동산은 현금화하기 어렵다는 것입니다.
당신이 현재 보유한 자산은 오직 현금 1000만원 뿐입니다.
각 챕터는 “구매 → 판매 → 가격변동”으로 이루어지며,
각 챕터마다 정보를 구매할 수 있고, 정보의 가격은 현재 가진 현금의 5%입니다.
당신이 이기려면 현금으로만 21억원을 보유하는 것입니다. 
당신의 현금이 0원이거나 총 자산의 가치가 300만원이하가 된다면, 파산하여 게임에서 지게 됩니다.
21억을 보유하여 게임에서 승리하면 30층 빌딩을 구매하여 부자가 됩니다.
꿈의 빌딩, 30층 빌딩을 자신의 자산으로 만드십시오!
");

            /*foreach (int i in assets)
            {
                Console.WriteLine(i); // assets 출력되는지 확인->완료
            }
            */


            while (true)
            {
                Chapter(); // Chapter class 사용하기 위해 new 연산자로 메모리 할당

                if (assets[0] <= 0 || totalassets < 300 || assets[0] >= 21000)
                {
                    break; // chapter를 반복하여 돌다가 조건이 만족하면 게임이 종료된다. 
                }
            }
            if (assets[0] <= 0 || totalassets < 300)
            {
                Console.WriteLine(@"!파산파산파산파산!
당신은 돈이 없어 파산하였습니다.");
            }
            else
            {
                Console.WriteLine(@"*****************************************
빌딩 모양 출력하고
이 빌딩은 당신의 것이 되엇습니다. 축하드립니다.
투자의 고수십니다.");
            }
        }

        public static void Chapter()
        {

            Console.WriteLine("구매 → 판매 → 가격변동이 이루어지는 한 챕터가 시작됩니다.");
            Console.WriteLine("이번 챕터에서 정보를 구매하시겠습니까? 구매하실것이라면 'YES' 라고 입력해주세요");
            Console.WriteLine("정보의 가격은 당신이 가진 현금의 5%입니다.");
            string purchase_information = Console.ReadLine();

            if(purchase_information=="YES") // 구매한다고 선택한 경우
            {
                double _cash = Math.Round(cash * 0.95); // 전역변수 cash를 받아와 95%값을 남긴 뒤, 소숫점 절감
                cash = (int)_cash; // double형이 되어버린 cash를 다시 int형으로 전환
                Console.WriteLine("main_information");

            }

        }
    }
}
