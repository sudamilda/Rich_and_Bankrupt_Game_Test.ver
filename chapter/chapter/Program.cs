using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter
{
    class Program
    {
        static void Main(string[] args) // 한 챕터이므로 챕터 안으로 넣을 것
        {
            List<Data> datalist = new List<Data>();
            Data data1 = new Data();
            data1.main_information = "SY그룹, 신규 제품 생산을 위한 공장 건설 계획 발표";
            data1.materials_information = "공장 건설을 위한 원재료 가격 상승";
            data1.materials_change = 1.1f;
            data1.product_information = "변화 없음";
            data1.product_change = 1f;
            data1.stock_information = "신제품 기대로 인한 주식 상승";
            data1.stock_change = 1.3f;
            data1.realestate_information = "신축공장부지 가격 상승";
            data1.realestate_change = 1.3f;
            datalist.Add(data1);

            Data data2 = new Data();
            data2.main_information = "SY111그룹, 신규 제품 생산을 위한 공장 건설 계획 발표";
            data2.materials_information = "공장 건설을1111 위한 원재료 가격 상승";
            data2.materials_change = 1.1f;
            data2.product_information = "변11화 없음";
            data2.product_change = 1f;
            data2.stock_information = "신제11품 기대로 인한 주식 상승";
            data2.stock_change = 1.3f;
            data2.realestate_information = "신축공11장부지 가격 상승";
            data2.realestate_change = 1.3f;
            datalist.Add(data2);

            int cash = 1000; // 복붙할 때 버릴 것

            Console.WriteLine(@"구매 → 판매 → 가격변동이 이루어지는 한 챕터가 시작됩니다.
이번 챕터에서 정보를 구매하시겠습니까? 구매하실것이라면 'YES' 라고 입력해주십시오.
구매하지 않을 것이라면 엔터키를 입력해주십시오.
정보의 가격은 당신이 가진 현금의 5%입니다.");

            // 리스트 내 랜덤 정보 추출
            Random random = new Random();
            int i = datalist.Count;
            int rnd = random.Next(0, i-1);
            Console.WriteLine(i); //-> datalist 몇개인지 카운트 확인
            Console.WriteLine(rnd); //-> 0 ~ i-1의 값 랜덤 생성인지 확인
            var random_information = datalist[rnd];


            string purchase_information = Console.ReadLine(); // 시간 되면 bool형으로 고쳐보자

            if (purchase_information == "YES") // 구매한다고 선택한 경우 가진 현금의 5%를 소비
            {
                double _cash = Math.Round(cash * 0.95); // 전역변수 cash를 받아와 95%값을 남긴 뒤, 소숫점 절감
                cash = (int)_cash; // double형이 되어버린 cash를 다시 int형으로 전환

                Console.WriteLine(random_information.main_information); // datalist내 main_information 불러옴

            }



        }
        class Data // 복붙할 때도 메인 밖, 모두 구현 후, 엑셀에서 직접 가져오는 것도 시도해보자!
        {
            public string main_information; // 메인 정보
            public string materials_information; // 원자재 정보
            public float materials_change; // 정보에 따른 원자재 가격 변화율
            public string product_information; // 제품 정보
            public float product_change; // 정보에 따른 제품 가격 변화율
            public string stock_information; // 주식 정보
            public float stock_change; // 정보에 따른 주식 가격 변화율
            public string realestate_information; // 부동산 정보
            public float realestate_change; // 정보에 따른 부동산 가격 변화율
        }

    }
}
