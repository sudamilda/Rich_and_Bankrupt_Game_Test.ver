using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rich_and_Bankrupt
{
    class Program
    {
        // assets 구성 원소 <cash, materials, product, stock, realestate> <현금, 원재료, 제품, 주식, 부동산>
        public static int cash = 1000;
        public static int materials=0;
        public static int product=0;
        public static int stock=0;
        public static int realestate=0;

        static void Main(string[] args)
        {
            long totalassets = cash + materials + product + stock + realestate; // totalassets = assets의 합이고, 게임이 현금만 21억일 때, 종료되므로 더 큰 자료형 long 사용
            
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

            while (true)
            {
                Chapter(); // Chapter 불러옴

                if (cash <= 0 || totalassets < 300 || cash >= 210000)
                {
                    break; // Chapter를 반복하여 돌다가 조건이 만족하면 게임이 종료된다. 
                }
            }
            if (cash <= 0 || totalassets < 300)
            {
                Console.WriteLine(@"
EDLDEEEEEEEEEDEDEDDDDDDDDEEEDDGGDDDDfLDDEDLEEjGEEKEEEKKKKKWWKWKKEWKKKLEEDGDDjGj:D, :.   .;LfLf;fG,GD
ELDEEDEEEEDEEEEEDEEDDDDEDEEGGEGGDGLDGLEGLEtKDDEEEKWKKWWKKKKKEWWKKEKKEKGDEEDGLGLED .,:i  ,.LifLjGDDtD
DDD,GEEEDDEDEEEEEDEEDDEDDDEDEDGGDLGLLDEDGGEEDDEDKKKWKWWWKKKKKKKKKKKEEEDKEEGDLLDGD :jL.. tLGjtGLfGiGG
Ef,tEEEDDDEEEEEDDEEDDEDGEGGLEEDDfLGLGGELLLGLDEEEKKKWWWWKKKKKKKWKKKEEEKGEEKEfjtDDD. fL  .jtGjff;EDtDD
:iLEGGDGEDEDEDDGDDDEGDDGEEDDELLGfLGGGGGDfGjGEEKKKKKWWWKKKKKEKKWKKEWEEDKEGGGLftfGG::;L   ftfjGLLDD,DD
GDGDGEEDDDGLEEEGEDEDDDDDDEDGEjDGGLGGGEGGGLLEEEEEKKKKKEKKKKKKKWKKEKKKEEEDfEDGGijLG. L;. EftLfLGDDD DD
DEDGEDEEDGDLGEDGEDDEDDDDEDEGELGGLLLDfDDGGfDKKDEEEEKKEKKKKKKKKEKKKEEKEEDtiGGD,jiGG .fG  t:,GDGGGEDLfD
DDDEEEDDLDDDEDEEDDEGDDDDGLEDDDDGLGGGfDEGEDEKEEEDEKKKEEKEKKKKKKKKKEDKEDDKGDGGfffiGf iL   :;ftEfiLGftt
DDDEDLDDDfDEEGDDGDGEGDDGDDEGDDGGLDDGGEDGGGEEEEEEKKKEEEEEKKKKKKKKKDEEEDDLEEffGjjjGD LfG,   fjLt  DjLG
DDEDDEEDGfDEGEEDEKjDGGDGEEDDDDGGGDGGGEGDGDEEEKKEEEEEEKKKEKEEDEKKEEDEGEDLLDL;ffLfG. LG  .  jLt;  E :G
EGDEDDEGGEEEDDEDDDLLDDDGEDEEDDGGLEDLDEDEDEEEEKKKEEEEEKEKEEEEGEEEEDfDDEffGEfi. LtLj LL, ;. jttt . ;ED
EEEEEDEEEDDEDDDEDLGDGDDDDDGDDEGGLDDDGDDGGGDKEKKKEDEKEEEEEEDDGDEEDGfEEKDtGfjj,ijftt LL , : fitj.D LG;
EEEEDEDEEEDEDDEEDGEGGDDGGfDDDDGGLDDDEDEDDDEEKKKKEDKEDEEEDDDGfGDEDEfKEEDjtDtt,GLEi,fff i..itjjjjj;:ED
EEEEEDDEEEEEDEDDDEDDELDGGLGEGDGGLEGDDDEEGDDEKKKEDGEDEEEEDDDGjGDDEEfEGEtfjLLffLLD;tjff   i;fLLff,fDDE
EDDEGDEEGEEDDEEEGDGDDDDGDGDEDELGGDDDDEDDGGfKKKKDGDGfEKEGDLEjjDEELDGEEGGtfLffjfGD:  tL ,:: fGGEE;jDDf
EDEEGDEEGEEEEDDEDDDDDDDDDLGDfDLGLDDEEDGLLfLKKKKDGDLLKKGffjEijEEDDGLEEfDLDfifGfDEj  ffG;. ;DDEDDjit. 
DDEDDDDDDEDDEEEEDDDDEDDGDGGfjjGGGEEDEEDjLfDEKKKDGLfEKKLfjjDjjDEGfffGKGGfLjjjtfDD,.GfftiL;ffjDGf;;GLL
EDEEDDDDEEEDEEEEEDDEGDDGGEDLffLGLEDGDDDLffiLKKKGGLGKDLjjttGtjEEGjjjLEDLfftKGfiij ;LjL:.fL LGLGLif;iG
EEEEEDDEEDEEEEDEDDDDEDGDDDDDGfGGGDLLDDGGff :EKKGGDDGLfjjjjfGGGGGfjffDEjjGEKLGj;;:;GtDj;..jLLGLD::;G 
DDDEEEDDEEDGEDELDDEEEDGDDEDEGDGGLLjGDGGDLD jKKELLfjfLfffffLLffLLffjjGEffEEKGLft,;ifGLiLjjtGffff GGE.
DEEEDGDEEEDDDEDDDGDGDGDDGDDDDGGLGjLDDDGDfL:fEKDjLftjffLjffffjjfffjjjLEjELGELLft.: DGf;,G;fLLLLjtfj,i
DEEDEDDGDDGGDEDDDfGDDGGDGLEDDGGLGjDLEGGDGjLGDKDjjGEEfjLjffGjEDGfftjjfELEfLDGLfi.ji Gf,j:f;LfLL,LGt,i
EELDDLDDKEDDGDEDDDLDDGDDDGDDEDGGGGDEDDDGLDfj;EDjfjjffjfjffjfftjjjjjjfEEELGLGLft f, GL;  t LLfft,LGLt
DGDDGDLDGGDfGGEDDDEDDDDGLffDDGGLGEDEDEDEDDLjGDfffjjfjLfjjfjjttjjjjjjfDEDLLLLLf;.fL Gf     ttfL:.;DG;
DDDDGEGDGEDLGDEEEEEGEDDDfLjDGLGfLGEEEEEEEGLjDKGffffffffffffjjjjjfjjjfLELfGLLLL,:;i Gf     ittj ,.tLi
DEDEDGDGDDDGDGEEEDDLGDDDLEDDGLDLGDEEDDEDLDDGGGDfLfjjfLffffLjjjjfffjjfLEjfGLLLf,Gj  fL     jtit   GGt
DDEEEDDEGGDGGDEDEEDDELDDLDKfGfGDLLEEEDDDfEDGLGDfjjjfffffffLfjttjjfjjffGLGGGGGLfGGLfiL     iiii     L
GDLGDEDLEDDGDDEEDDEDDGDDLGGLGLGGLLGEDDDDEDDDDGGffjjjfjLfjjLfjjjjjjjfffLLGGGGGLGGGGGj:     ttti      
GDGDGGDDDDDEDDEEGEDDGDGDGDfGLLGDGfGDDDEGDDDGDGGfffjfLGfLDDLfffjjjjjfLLGGGGGGGGDLGGGGj;    iitt    :f
GLGDGGGGDEDDDDDDGDDDGDEDGGGLLGDDEfLGDLGDDfGGDDGffjjLffffjfffLfjjjjjffGLLGGGGGGGGGGGGLfi   tjGGGLLLLG
GGGGGGGEGDDDDDEKDEDGDDDDGDGLDDDGGLDGDLDfDGGGGDGffjLLffjfjfLfffjjjffLLiGGGLLGGDGGGGGGLLLt. tGDDGGLLLG
DEEGGGGDLLEDEDDEDDDDGDDDLGGLDGGLLLDGDGLDGGGDGGGGffffffjjjjjfLLfffjfGLGGGGLLGGDGGDGGGLLLLt:DDGGGLLLLL
GGGGDGGLGDGEDDEEjGDDGDDDGGLGDjDGDGLGDDLEGDGDDGGDfjfLfLLGGGGGLLjffffLjGGGGGGGDGGDGGGGLLLLLi:LLGLLGfGG
GGDDDLDGGDDDDDDEGGGEDDDDGGDEGDGLGDGDLDGEGGGDDGDDDLLLfffjfffffLffLfLiGGGGGGGGEGDDGGGGLLLLLj;.GGGGGGGG
LLDDGDGGGGGDEEEEGGDDDGDDGGDGGDLDGGGGLDGGGGDDGGGDGfLLLLLLLLLLLLfLfGjGGGGGGGGGDDDGLGLLGLLLLLj; GGGGGGG
DDDGGGDGGGDDEEDDDGDDDGDDEGGGEDEDGLLLLDGGGGDDDGGDLtLffLfffLGLffLfLGLGGGGGGGGDGGGGGLLGGLLLLLLt: GGGGGG
LGGDDGGGGGDDEEDELGEDDDDDEGGDDEGDDLGGLDDGGGGDGGGDffGLffffLffffLLLLLGGGGGGGGGDDDGGGGGGLLGGLLLj;.fGGGGG
GLffLGGDDEEDDEDDGDLLGDDDGLDGLLGDLLGGGDDGGGGDGGGDLLtDLLLfLfffLGLGffGGGGGGGGDGDGGLGGLLLGGLGLLLit GGGDG
LLtLDDDGDDGGGEDEDDLGDDDGGGDGGGGLLGGGGDDGGGGEDDGDjtfLDLLLLLLLGGGtftDGGGGGGDGDGGLGLGGGDGLGGLGLi:.GGGDG
fttLGDDGGGGDDDDEDDDDDDDGLDEDDGDLGGDGGDDDGGGDDDDDjijGfEGGGGGGGELjfDDGGGGDDGGDGGGGGGLDGLGGLLLij;..LfLf
GfjGLGGDGGGDDDEEDEDGEDDGfDEEDGLLGGGDDGGDDGDDDDDDttttGttGGEEDGLjLiDDGGGDDGGDGGGGGGGDGGGGLLLLGL,t :LGL
GjtGLfDGDDDDDDDEDGGGDDDGDDDDGGLGGGGDDGGGDGDDDDDDtttiifi;;fLLLjG;jDDDGDDGGDGGGGGGGGGGGGGLLGGLf,j..DDE
DLLDLjEDDDDDDDGDDGDDEDDGGDGGGLGGGGGDEDDGDDDDDDDDtiiiitfLi;LjLi;iDDDDGDGDDGGGGGGGGDGGGGLGGGLGLLt:.:DD
DGfLjfDDLDGGDLGGDGDDDDDGDGGGGLGGGGGGGEDDDDDDDDDDi;iiiijtttjjji,;DDDDDGDDGGGGGGGGEGGGGLGGLGGGGLt,. DD
f::G.E.GjDGLD;G.D.DfDDDfGGD: LGGGGDGGGEDDDDDDDDDt;i;;ii;ii;;i;;iDDDDDDGGGGGGGGGDGGGGGGLGGGGGGLj,:, D
;.:G L tDfffDif,DiG:EDDGGiD.jGGGGGDDDGDEDDDDDDDDt;;;;;tiit,;t;ifGDDEDDGGGGGGGGDGGGGGLGGGGGGGGGLi;;.:
LtjDjjjiGfjfGf;GDjDiDDDLfLGiLGGGDDDDDDGGDDDDDDDDj;;;;ijtfi,;;,;GDDDDDDGGGGGGGDDGGGGGGGGGGGGGGGLj;,::
EjjELtGfGjGfDG;DLfGtGGGDDfLiGGGGDDDDDDDGDDDDDDDDfi;;iijtj;;,,;tDDDDDDGGGGGGDDDGGGGGGGGGGGGGGLLft,;,;
DffDGjGfGLLLDG;GGLjLDDDDDLGfGGGGGDDDDDDDDDDEDDDDfi;;iijji;,:,ijDDDDDGGGDGGDDDGGGGGGGGGGGGLLLGGGLj;:.
GLLDDLEfGLGLDGGDEDGDGGGEEGGLGGGGGDDDDDDDDDDDEDDDji;;itji;;,,,ijDDDDGGGGDGDDDDDGGGGGGGGGLLLLLGGGGL:;.
fffDDLEjDGGLDGjGDDLGDDGEGLGLGGDDDDDDDDDDDDDDDEDDti;,itj;i;;;,ffDDDGGDDDGDDGGGGGGGGGGGGGGLGGLLGGLLL:i
GGDDDDDfDDDGDGLGtDGGDGLEGGGLGGGDDDDDDDDDDDDDDDDDji;;tji;i;;;;LDDDGGDGGGGGGGGGGGGGGGGGGGGGGLLGGGGGj.i
GGGDDDDfDDGLDLLDfLGEDGGDGDDGGGDDDDDDDDDDDDDDDDDDjii;ji;;i;;i;LDDGGGGGGGGGGGGGGGGGGGGGGGGGGLLLGGGGGj.
GGGGGGLfDDGGDGGGLGLDGDLLLLGGGDDDGEDDDDDDDDDDDDDDjii;j;;;i;i;;GDGGGGGGGGGGGGGGGGGGGGGGGGGGLLGGGGLjtt:
fffLLLLtGDfLGfLLffLDDGGLjtjGDGDDGDDDDDDDEDDDDDDDDttiti;;t;ii;EGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGL, 
당신은 돈이 없어 파산하였습니다.");
            }
            else
            {
                Console.WriteLine(@"
tttttjttjttjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjtjtjjttjjjjjtjjjjjjtjjtjjtjjjjtjjtjjjtjtjtjttjtttttttttt
jjttjttjtjjttjjjjtjjjjjjjjtjjttjtjjttjttjjtjjjjjjjjtjjtjjttjttjttjttjtjjttjtjjttjjtjjttjttjttjtjjttj
jttttjttjjjjjjjjjjjjjjjjjjjjjjjjjjjttjjtjjjtjjjjttjtjjjjjjtjjjtjjjjtjtttttjtttjjtjtjttjjtttttttjtttt
jttjttttjjtjjjjjjjjjjjjjjjjjjjjtjjjjjjjjjjjttjjjjjjjttjtjtjtjtjjjtjjtjttjjtjttjjtttttttttttttttttttt
tjttjtjjjjjjjjjjjjjjjjjjjjtjjtjjtjjttjttjjtjjttjjjjtjjtjjtjjttjtjjtjjtjtttjttjtttjtjjttjttjttjttjttj
ttttttjjjjjjjjjjjjjjjjjjjjjjjjjjtjjtjjtjtjtjtjjjtjjjtjtjjtjjtjtjtjtjjttttttttjttttjtjtttttjttttttttt
tttttjjjjjjjjjjjjjjjjjjjjjjjjjjjttjjtjjjttjtjjjttjtjtjttjjjtjjttttjttjtjttttttttjtjttttttttttttttttt
tjtjjtjjjjjjjjjjjjjjjjjjjjjjjttjttjttjttjjjjjjjjjjjtjjttjttjttjttjttjtttttttttttjjtjjttjttjttjttjttj
tttjttjjjjjjjjjjjjjjjjjjjjjjjjtjtjtttjtttjtjjjttttttjjjjjtjtttjttttttttttjtttttttttttttttttttttttttt
ttttjjjjjjjjjjjjjjjjjjjjjjjjjtjjtjttjttttjttttjtttjjtttttjttttjttttttttjtttttjttjttttttttttttttttttt
tjttjtjjjjjjjjjjjjjjjjjjjjtjjttjttttttttjjtjjttjtjjtjjttjtjjtjjttjttjttttttttttttjjtjttjttjttjttjttj
tjttttjjjjjjjjjjjjjjjjjjjjtttjtttttttttfiLttttttttttttttttttttjttttttttttttttttttttttttttttttttttttt
tttttttjjjjjjjjjjjjjjjjjjjjtttttttttttjWiDittttttttttttjtttttttjtttttttttttttttttttttttttttttttttttt
tjttjttjtjjjjjtjjjjjjjjtjjttjtttttjttjfGtGiLjttjttjttjtjjjtjttjttjttjtttttjttttttjttjttjttjttjttjttt
tttttttttjtjjjjjjjjjjtjjjttttttttttttjDWiKjGjitttttttttttttttttttttttttttttttttttttttttttttttttttttt
tttttttjtjjjjjjjjjjjjttjjttttjttttttttDGtGiitDitttjtttttttjttttttttttttttttttttttttttttttttttttttttt
tttttttttjjjtjjttjttjtjtttttjtttttttE;DKiWiGjLGDjttttjttjttttttttttttttttttttttttttttttttttttttttttt
tttttttttttttttjjttttttttttttttttttjiiGLiLit;GjLGitttttttttttttttttttttttttttttttttttttttttttttttttt
ttttttttttttttttttttjttttttttttttttDj;KGiLiLiGGDG;Gjtttttttttttttttttttttttttttttttttttttttttttttttt
ttttttttttttttttttttttttttttttttttEjtjDGiGiiiGLLGjGiittttttttttttttttttttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttttttttjDKfiEDiDiGjLjtLiL;Dttttttttttttttttttttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttttttttEffjfDGLLit;EfLGtGiLjDjtttttttttttttttttttttttttttttttttttttttttttt
ttttttttttttttttttttttttttjtttttDDDKfiGDiGiGjfiKtjt;DttG;ttttttttttttttttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttttttLGDjGLtDGfGii;GjG;LLLLiKGiGtttttttttttttttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttttttGKGDDE;GLijiGjf;WtLK;LtGDiGGitttttttttttttttttttttttttttttttttttttttt
ttttttttttttttttttttttttttttttDLDDEGLjGL;LijiGiG;tfifiKLiKLijttttttttttttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttttLGjfGDEj;DLiLiLiG;D;LDtLfGffGijGKtttttttttttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttttLEtfDKDLGfGiLjL;DtG;iifi;DttW;jKG;itttttttttttttttttttttttttttttttttttt
ttttttttttttttttttttttttttttDjjifGDDjiDDffiG;L;DiGfLLKL;iL;fGftGGttttttttttttttttttttttttttttttttttt
ttttttttttttttttttttttttttttGiiLtLDELKjDiLtf;KjG;i;GtfGiGDtGW;GEG;tttttttttttttttttttttttttttttttttt
ttttttttttttttttttttttttttttGtiiifLDtifG;GiKjGijiLifjKf;KLttfiLGjtGftttttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttitiiDijDGGttKiEjGijiG;LiGiGG;GtiLtiLt;GfGittttttttttttttttttttttttttttttt
ttttttttttttttttttttttttttti;KffiijEjttLjLiE;Gi;;Gjf;EftKjGWtjf;ifDGittttttttttttttttttttttttttttttt
ttttttttttttttttttttttttttttitiKjijGGLiiiiiLii;GDf;D;LLtG;fGitLijLi;jttttttttttttttttttttttttttttttt
ttttttttttttttttttttttttttt;;EtDti;KDtfLiLii;LGfiGDL;ELGEiGDtGEfLDfifttttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttEjDfDfijGDfiGtfiLLjiLLL;KiGijLiKjfjijiGtjLtttttttttttttttttttttttttttittt
tttttttttttttttttttttttttttffDjDLfiGLWiW;W;L;DiGjKtGiEiGWfGijG;fGL;Littttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttGDGLDDifGWffGtLiWjGiKiGtKfGitLfWiGWtGE;iiGitttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttLLGtDGj;tGtii;;iL;LiLLGjLijiGGLG;iG;iG;fGtittttttttttttttttttttitttttittt
tttttttttttttttttttttttttttLWjLDDjiLtLjL;LiiiLttjGLttGii;GEiGGfGffLKtitttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttjLGtDDf;LGGiG;LiLKLjLDiLLGiiLjfiti;Gf;Gijiitttttttttttttttttttttttttttttt
tttttttttttttttttttttttttttLWGLKDKiLGWiWiEjL;GitLLEfLLDj;GtfGjjGifGifLtttttttttttttttttittittittitti
ttttttttttttttttttttttttttifLjtDKDttELjGiG;WLGfftjLLDfjGjjiDi;GfiGEiLEittttttttttttttttttttttttttttt
ttttttttttttttttttttttttttiiLjLLDLijLtiGjfiGtftjLLifGtiLiE;GjEjiftfiiGitttttttttttttttttttttttttttti
ttttttttttttttttttttittttt;ti;jLLDEijGjGiDGLjGGfLiLLiiLLiL;KijLLfGifDLftiititttttttttttttttittiititt
ttttttttttttttttttttttttttt;iftiDfjjGGiGiLiGijGiDijiLtftjWfG;LjiDiiGj;fiiittttttttttttttttittttttiti
ttttttttttttttttttttttttttiG;iitDDLiGWitttiGjGiiGiWtL;GifGftiLLiGiDjt;jiiiittitttittttttttittttiiitt
tttttitttttttttttittittittftDi;jGDG;KGiGiGGiLjLiiiDiWiLiGijL;iiLEifLjiLiitiittiittitttttittiitiitiit
tttttttttttttttttttttttttifLiDiiDKLfLGiGiL;LKtLiLiiiGiDfLiEiiLiiGiDjiDiiiiiiiiiititiiiiiitiiiiiiiiii
titttttttttttttttttttttittLLEjjiEDE;jGitii;LLtWifiLiiiGiEjGLEtiLKtGjEfLiiiiiiiiiiiiiiiiiiiiiiiiiiiii
tttttitttttittittittiitittLtfKiEftGtfLiGiDKifiLiWjLiLEf;G;ftGLKftLfiGG;iiiiiitiittittiitiitiitiitiit
ttttttttttttttttttttittiiijGjLtijDLtjLiGiGiLEiLiLiLfL;LGjiGiiLiGifLiiGiKiiiiiiiiiiiiiiiiiiiiiiiiiiii
tiittittiiiittttittitiiiiiGtGiLtiDEiiG;tiiiGLiWitiLiKtL;LEfiGGifiGiiGGiLiiiiiiiiiiiiiiiiiiiiiiiiiiii
tttttiittttiitiitiitiitiitLLGGDjiKGLtG;GiLKijiGiW;f;LtjLL;GtjtDEjLjGiijKiiiiiiiiitiitiitiitiitiiiiii
iiittiiiiiiiiiiiiiiiiiiiiitGEGDGtDfiit;GiLiLKijiG;EitLLjDfGiGjftiKiLLiiLiiiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiitiiiiiiiiiiiiiGGEDWiDGiiG;ifiiGLiK;fiG,WifGLtGfGiGifGiKfiLDjiiiiiiiiiiiiiiiiiiiiiiiiiii
itiiiiitiitiitiitiitiiiiii;jKLtGiKGfiGtGiGDifiGiKit:GGWiGLL;iiGiKi;Giijf;iiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiiiiiiititLfDDiDtiit;DiG;GW;j;G:GiLLjGEiijLiffGitiiGDijiiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiiiiiii;E;jLDDiLDiiG;fiLiGGiW;L:GfjtfGtGtij,L;iiLLitLiDiiiiiiiiiiiiiiiiiiiiiiiiiii
itiitiitiitiitiiiiiiiiiiijifjfKDLfGjiGGEiWiLGiGiKifGiGiitGiGGtL;Li;jtGjfGiiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiiiiiiittiifDttftfit;GiG,GEit;GtfttfiGiDtLiGGijiLittiLWiiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiiiiiiiLLifiDDLtGj;D;jtf,GGiEitjjGiGjfiGiLjLiGKiLiLEiLGiiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiiiiiiiLGWitGDtiGtiGfKiWiLLiG;GifLiLiWitiLiWijfLD;tfjGitiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiiiiiiiGKffiDtDitGiGWLiL,KiLL,GGiiffiGiWitiLiWifG;DijGiGiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiiiiiiiiGfjitDEiGGfW;LiG,fLiiLfGiGiLtfiG:WitiGiWtjGiEiiLiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiiiiiiiLLGttfDtiGfiL;tijifGiL,WijGiGiKijiG;DtfiGtEiiGjjiiiiiiiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiiiiiiifGLttttEitDiGtLiGLiiiG;jGiifLiG,KijjG;GiLiLtfiiGGiiiiiiiiiiiiiiiiiiiiiiiii;
iiiiiiiiiiiiiiiiiiiiiiiifLLtGLtDEiLLit;fiLijEitijGiLiEittGGGEtjG;LfiiGGitfii;iiii;iiiiiiiiiiiiiiiii;
iiiiiiiiiiiiiiiiiiiiiiiiittGLLiDtifLGG;jLLijLiGGitiLiGiWitLfGGKitGiGtitiGii;i;;;;ii;iiiii;;i;ii;iiii
iiiiiiiiiiiiiiiiiiiiiiiiiitLtDitDijfiLiftijiGiLLiWifiGffGDijLjGiWiiGiGjijiL;;;;;ii;i;iiiiii;i;i;i;ii
iiiiiiiiiiiiiiiiiiiiii;ij;iEGDtjEfGGiDWfiLtWijjLiLiGGittGiLiEitiGtGifLiGGtji;;;;;;;;;i;;;;;i;;i;;;;;
iiiiiiiiiiiiiiiiiiiiiiiitiGLLGitDWtGtWiftGttLiittLiLiGWiLiDiLiWitiLLGjjLtLGt;;;;;;;;;;;;i;;;;;i;;;;;
i;ii;iiiii;ii;i;;iiii;;ifKijKDiiDittiLtjifttGiLLtiitjjLiGfitLiLiDtfiLGtWitGi;;;;;;;;;;;;;;;;;;;;;;;;
iiiiiii;;ii;iiiiii;ii;;;WtjtLEtiEjiGiGtGtWiitiGLiLiGiLLiLiGfifLiLiGfitLGiDij;;;;;;;;;;;;;;;;;;;;;;;;
ii;i;i;i;;i;;i;;ii;;;;;;LfWiGtfiEtiLttEjtLjtfiGjiGiLGLtjjiLiLtitfiLiGLiiiGiD;;;;;;;;;;;;;;;;;;;;;;;;
;;i;;;;;;;;i;;i;;i;;i;;;GKfitDGfWjijGGfjtfjtfiDLiGiLLiLiWiLiLiLLWiLiGiLLftiL;;;;;;;;;;;;;;;;;;;;;;;;
;;;;;;;;;;;;;;i;;;;;;;;;DLfLLEDiEfLEtLfttDttGiGGiWitiiLiLiDtttGLGLDtiiLiGLEi;;;;;;;;;;;;;;;;;;;;;;;;
.;;;;i;;;;;;;;;;;;;;;;;;LfWijtDiEtiGjttttGDtfiLGiGtGKitiLiLfLEiitGGLLLifLifLt;;;;;;;;;;;;;;;;;;;;;;;
,.,:,;;;;;;;;;;;ijtf;,;;GWGjiDEitGiGDfLttfftEjtGiGjLLiGKiGtLjLiGLijLjjLijijGi;;;;;;;;;;;;;;;;;;;;;;;
.:,,.::,;;;;;;;,,,t;;,;tLLLttEEjELiGWLLttGftfiGWttjLGiGtGDjttLiLiLLitfGiLiKit;;;;;;;;;;;;;;;;;;;;;;;
:::::::,,,:,;;;j:.tit;;tijWftDWjDLiDfGGttfttGiLLtGEitfftGLiGitijiGiLiKifftGtG;;;;;;;;;;;;;;;;;;;;;;;
;.::,,::::,::.,ji;tttttifWLLfGDLLtiLLttttKttLiLLiGLfGjtttLiGiGiKijiGiLiGfittG;;;;;;;;;;;;;;;;;;;;;;;
:i,:,::,:,;::.,:tjj,;;jjifLttjEtGGiLtWLttfftGWitffGjGiLLEtifiGiGiLGijtiGiLDjjt;;;;;;;;;;;;;;;;;;;;;;
::;:,:,,::.i;::t:;f;i::iijfGtttDjLitKfGttGftftLGEitifiGLLLiWitiLiLiLjLittGfLGD;;;;;;;;;;;;;;;;;;;;;;
.::.::;,::.;,,:::.f,;tjitjLLttDEtttGLLLfttttGtGLiLGLtitLjLtLtGKtLtjGLGtEitiGGt;;;,;;;;;;;;;;;;;;;;;,
,;i.;:,:.:,,i::;t;D:t:iLjijDKtDEtWtLLttjjWttGtLGtGLiLtWitGtGiGfLGKitiLLLtLtijt,;;;;;;;;;;;;;;;;;;;;;
.j:.L.ii.,.::.;;jtj:ijitjitKGtDttGtfGtKijGLtWttLifGtGtGGiWttffLjLtLtKtLjLGtLtK;;,;;;;;;;;;;;;;,;;;;,
.t.ii:D;:t.i;::t:tGj::t;;tiLELEDiLttWfGijGLtLjLDWttLtLGGtGtGGjtjttLiLiGKittLtLt,,;,;;,,;;;;,,;,,;,,;
j..Lf.;:;;.L:.:..t;t:jiiKttLtfDDtDjGGfKtitLtGfLLtGGLttGttGtGLLLijiLtLtLiGiDtLtt,,,,,;;;,,,;,,,,,,;;:
ii.t;.L:fi:;.:::ijt:.,tWitttDtDDiWfEKtEttttLtffGtGGtGGWiiLtLLjGiLtEtiftiGtLijti,,,,,,,,,,,,;,,,;,,,,
t::L:;i:tf.L:Lijjfit,;tifLELEjDLiELDDtWtjELjjttDtLGiGGjLtGWttftiGtLtLiWtttLi,i;,,;,,;,,;,,;,;::,,,,,
t,:;.iG.;,;i.LK,;G:;i.tftLtfDjEDtKfjEtDtjGEtfLLEttftjLtGtGLfGfitGtLjGtGtGKijiti,,,,,,,,i,t;,,,,,,,,,
::f;:ii.i.t;.DD. Liij:GfjijLjLjGtDjDDtDtjKKtfftLfLGLttfttLGtLtLtGKttLjLfGLLtEti;,,,,,;,ji,,,,,,,,,,,
::.,,:;:;:ii:DL:i;i;,tEitLtjDGtGtKELEtjtjEttLLtGfLDtLGjtttLtftLjLGLGEitjtLGL;tit,;,.:  ;,,,:,,,,,,,,
::;,::,;,::i.Kj:DEii:;ttttGtGGfjtEELGGttfDtttDtjfLGtGLtLtGEitLtfLGLGiGtWttftLtit;:.:.  . .,,,,,,,G,,
,:;,,,:,::::,DtfGj:,ijLtjjKtGjtDtELfjtEtjWWtGEjttLttLGtGtLLtLtKttGtLiGtGtLtWtitt.....    ..  :,,,,,,
,,,,,:,,:,,.GDG;j,.:;ttitELLfLtGjjjjEtDtj#EtLftGGWtttDtjffGtLtLLjKittitGiGtLtfLi.G..: .. L;. . .::,,
;:,;,,,,:,,.WDf Lt,i,tittjjDLGtGDjKtDtEtjGEtGDtLLtLtGWtttLttLjGGtftLtLtifttLt;ti..:..:......G..  ::,
,,,,,,,,::::EKK;GLi:,;iftKKtGGLjWEDtEtDtjtLftftGLtGtLLtLGLLttGtttGtGtLfLLEttfitit:::....,L;. ....,,,
Wj,,,,,,:,:.KWEfEfi::itttEEjGjGGEDDtjtjtj#KtjtjfttLtfGtGLiLtLWtttGtfLLLLLfLLWtiLtLf,:....fLff, .. ,;
DDLWW:::::,:EWDjG,,i;tDjtLfjjLtGKLftEtEtjWKtEKjWtttffttLLtLtLLtLtGDttLtjftLjLfiiD.::GDjLL,:..fj:, ,,
DDKWW:,:,,::WKD.;:.,.tiLfLjDjGjLjjjtEtKjjWKtEDtLLtG#ttttftjtLGtLtLjLGDfttLttLtiitfLDD: .,ffL;.. : ,,
KWfGE;.,.::iKWf:G;;j:tjjtGDLjLjLjGEtKtEjjGEtWGtGftLftGtEftttLttftGLfLtLtLjtttfitijj.:.,.  .jfLfi. ,L
,,::jKGEt,:KKWfL;.;;.ttGfjEGjLjLKtKtEtKtjttEtttfLtLLtLtfLtLGDjtttLttLtGtGtLtLjEti..LEEDGfLL . .ft;;;
E;,,,DiKE,:WKE.jj:;::ttfttLDt#fjKtKtEtfjf#KttttfLttLtLjfLtLLtLtLEGtttfttLjGjGtitijfLD:. .;LffL,.   ;
WfKW:,L,:::KWE,Lj:,;tttDLGjWtLLtGjLt#tEjfEEtEEtEEttttDttftLLtGtLLtLtLLDtttftffLttj::..Etf: . :LLji,;
GLLG:,;:f:.WWWGjGt:,ittttEjftLLjDtWtEtEjfWEtDEtfftLLjDtjttGttftLLtLtLtfjfLEtttLtjt:fDEE.,LffL   .t;;
,,,,fGEGL,:WWWLGfi;ititjfjjLjGEtKjKtEtWjfWKtEEtfftLftittKWGtttffttLtGffLjfjfjLLttiEGL.... .LLLff,   
D;,,;EKKE::WWKif,t:,iEjjELjLLjWjKtWtWtfGDfjjjLtLGttittjtDjLDtLGKjtttGttftGtftGtiti...:KKGGf. . :jt;;
EEWL :i,,::WWG ;:,.:,tjjLfjj#fLtGtWtjjjjjtjjtjDtttfjtKjtELjDtDDtDtEGWttttGtttLtLtitGLEK. :LLLLt...  
LWD:; :,,:tW#Etf,t:;tjLjjjtfjjLtDtDjjEWfLEKGWWDjttttfGttjGtKtKKjEtEEjDtDtKDtttfttfjG.... ..  iLLLLt 
,,:iiGDj,:KWKDL;.,t,tiGjKKjLfjLjKtfDWtEDfEKLEEGLGjLELtttjjLjjjLjEjKEtDjDtEjjjKWLttt...KKEGGL  .  ;jt
,,,,KKKf,:WWDfjj.;;.ftGGGEfLfjEjffGtEjKffWWEKKEKDLjitjDjKWLjjjjjLjjftEtDjjGDLDGiEijGLjKi..:LLLLL.   
WWW:.,,:;.WWW.Gj.,t.jjGjLDLDjjWtKtEjWjWDLGKKWWLEEGLttLDjDDjDGEKfEfjjtjGjjtLffjDt;ttG:......  .;LLffi
DKK, ..,,.WWW:f,,:;,jjDGjGfGKjfjDjWtDfjLKKKKEELDGDGKfKWjDDjEDGEjDDLDjKKttjjjLjjtjttj..DKELLfL. ..  j
LEfiDEj,,:KWELDL;,,.jjtDGWDjfjLjKjLjGfGEWDfDLfLLjEDDfffLLDjEEfEfEEjKtDEEEtWjWLttttLjfGEE: .fLffLffi 
;f,KKKE,::WKDGLL;iiiffjKfWLGffLfLKDEKEWGEWWDWWfKWEffLELKDGjffjLfEEjEjDDEWtDjGjEjKfKjt..........:;jjf
WWt,,jL,,jWEDj;:;;ttjLKDDKLLEDELLEWEWDWDEWWGWWGEDKtLfEWWDjfjjjfGfjjjfLEjKjEtLjKfKjtj..:KEEDfLf ...  
EE;:,Ki,:WKED K;f;tDDLLLfWEjGKGWDDWE#E#LDWWWWWDWWLLLEEWGEEDDKjEKGjjjjjjLLjjjLGDKftttLGLEt: .LffLjjDt
DGf:,f;t:#WED:j,i;ffLDKGKELLKjLDWGWK#D#KEEKLWWEWWWKEDKEEKKGKDjDDfEjKKDWLtjjjjjLjjtjff;.... ..  .tEDL
LiWWWK,,:#EWtj,;jt.iLEDKGWGLGLGEKLWWKDWEEKWEEED#GKDEKKKGWWLKKjKEjWjWEtKtKELLfLjKjtttj..KKWELLLL:   .
LiLGjiWf:WEWiKLifLtLDGGGDKGGDEKKWWGEDEWLDEDGGDDKGfKWWDfGGDEGEjEEjKjWKjKtWKDKtKjWj;jtjGDKWj..;LLfEEKG
WLLiWEE,,WKWfDLiGDfLWELGKWDDLDGKEGfDEW#GEWWKW#WWWGWWDKKEWEKEDfjjjjjLLjKjKEjEjDjWjtjjjDi::....  .,DDE
EEt,LfD#KWWEDfG.LjifKKjDDWLjGKKGL#WWWW#GfWWKW#GDWLKWWGEKEWWWWLLLjjjjjjGDjjjjjLfEDtjtf.,:jWKDGEj:....
LL:.#EW#KKKEEGDiDW:fDKjGLDELGDWWEKWWWE#DGWWWW#LKKWGEWfEELWWKWLKWjKWfWWGtjjjjjjjGGjttiLGGKKKLDELLjKKj
tiKKW#fEW#WKjKffjDjEEGEGGE#LGDEWDWEW#WWjG#WWW#jE##LWfLEKK#WK#KKWjKKjEjKKjKjLjEWKWLjtLLG;,,t:.t. .,Lj
WL,f#W#WWWWE,jE;jGfWGfEKD#GfLGDWKWKWDL#LEGGEGKfE#EGEDLDWfWWLWELEjWWjKLDKjKjEDGKfKffjfL,;fLKEEL,::...
j,:###WWWKKL,;KDtfLLDKGDKWLffDLWDELLKWW#LjGWDEfWWWLDLfWLLDffGGjLjEKjWKjWjWjGLjWGWfKEtGEKKWWKEKKEKjEE
i:,f##WWWWE:KEGGjfGEfKDLWffEDWDEELLfLD##L#WW##WKKKGLLjfLLGEGLjtjLDDfjjjjjjjfLjDLWGWKKEKKDDfj;, iGfKD
:ii#W#WWWWK:GKtiEE;GWGDKEELKWKEGLDE#WEWWEWKLWWWLK#LjfGKWWKWLWWDLjjjjjjjjjjjjjjGDDDLEWDi:tLfG;;jii.,.
jEE##WWWWWKfD;:GWKEWfLLLEDjD#WLGLWjKEEWDf#WfWWDGEEGtGDEKfWWGEEfKDLDjEEjELDKjKGEWEGLLKDGKKKKKKKKWKEEW
;;iWjWWWWWEEEG;KLDGWEfLG#WLfEKLDfGfWWDWDLK#GKWGLWKjjGW#WGW#fWEfKDfDGfDjEDjEjDjEEDKEWGWEKEfDi;tDWWWKW
,:,W;WWW#;LWDDLDGGL#WfDf#fjGWfjGjDLWGGWjf#GEWK#GEKftKWKLWWWfWWGLLfGLjKtDEjEjGDGLfWjWEWEKDKDDKWGEEEGD
DGLWfDGDDE;jK#fKDDLWW#DL#ffLfDfGjGGLDLGiD#WDKffLfjLjtffGKLDfffLGDffLjLjGLjLfGDjGGWDWL#G;fEWGEfEEEEDD
DGWWEDDGEKEGDKEEWDDWEEDfWELGjLfLfGEEGDLKEW#f#DLfffWLLffjWfDffjfGLfLjLfftjjfjGLfWEDGKEKDWWGDEWKDWKEKK
GL#WGDGGKLKEGWWEEK#DDWEGWGG#GGffLEKEGDLLLWWf#fE#jf#tLfffWfKWGGLjfjjffjjfffGGGjjLKWKEKWKKWWWDEWEWKWDK
LGKWGGGDGEDLLGLLGGGDL#KG#GLLfLLDDGGjEDLLDGL#EDGGW#GGDGEfWffDjfEGGfLjGLLffLfGfDLGDWEKEWWKDWDK#WWWKDDK
LGKWLLLGGKLLLGGGDDG#E#EGEL#DGGKGEEKKKEE#EKKj##WW##LEDfjGWjtttDjjftjjtfEjfLGDKKGEEWKKWWW#DKfKWW#KDKEG
DDKDDEEKKWKWEWKWWKWDWWWWLLEWWWDEWWDDWKK#EWEj##WW##KGjjGDKLDGGGjjjfjLjjGDLDLGGLEGLDWWWDKKGWGLGKKWEEE#
LDWLGDEWKDEDDKDEEGDEDK#GLDLWWGEWDKW#EWWWEKDj#W##W#GGfffLEGGEEjLffffLGLLGGGDGLGEEWEEK#W#DjfWG#DKE#WEW
L#WGLLGGGDLK##DGLLKW####ELLWKLGWEKDWEKK#EKDjW#####GDfjjfKKDfGjjfGfDDLLLEGGKGDEGGWEKKEEWDEfELWK####WW
#WWWLLLLLLL##W##LL#####E#LLW#WG#WWE#####KKDjW###W##DGjDKKKEDGffDjDD:D.:DKDKDDGWWWWEKKEGWjLjEWWWWW#WW
WWWEWDDDDDDKKWWWEEKKKW#KWWKWWWWWWKWKKKKWKKEDKKWWKKWKWDLKKWKKEDGDLDE;G :KfEEDGGf;:,fGDDGELLjWW##KWEEK
#W#WGLGGEGEWW#E#GG#W#W#EGGWK#KWWWDEWKW##KKEfW#DWW##WWjfGEW###KDW;GG.DDDDDGGGGDDfijtDEEKEWWKKWWKKDDDE
##WWGGGGKG#DKKD#GG#W#KWKGGWWWKWWWGfWKK##KKEfWWWW###KKDfjDWjfLfEGLLWEDEGW##W#W###WKKWEWWW###KWWKEDDDG
W##WKEKWKG###KWWGGW#WWWKEGWWWWDWKDfLK#WDKKELW#W##E#LGGffGLfLi,jtLLWKKWWWW##WW###WWKKEW#W##WWWWEEKEKE
WKKKWEWKKKKKKKKKKKKKKKKWGGWWWftjjLLGKKWKKKKKKKKKWKKKWWKWKWKWKKKKWWKKKKKWWWWW##WWWEDGLLGW##W##W#WWKWK
KKWW##WWWWWW#W#######WWWWWW############WWWWWW#WWWWWWWWWWWWWWWWWWWKWKKWWWWKKKWKKKKEKELt;;GKKWWKWKKKKK
KWKWWW#KWKKKWKKKKKWKKKWKKKKKKKKKKKKKKKWKKKKKKKKKKKKKKKKKKKKWKKKKKWKKKKKKKKKKWKKKWDGj;t,iDWWWWWKWKKKE
KKKKWWWKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKWKKKKKKKKKKKKKKKKKKKKWKKKKKKKKKKKKKKWW#######WLj:  ,fLLLGDDGDG
KWKKWWWWKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKWKKKKKKKWWW#######WWWWKKKKKWW#WKWKWWWWWE#WWW#KKj,..iGKEDDEDKLD
WWWWW#W##WW#WWWWWW########WWKKWKWWKWWKWKKKK#KWKWKKKKWKKKKWKWW#WWWKKKWWW###WW##W##E#WWLt:.,EEKDKKEEDD
이 빌딩은 당신의 것입니다. 축하드립니다.
투자의 고수십니다.");
            }
        }

        // 챕터 진입!
        public static void Chapter()
        {
            List<Data> datalist = new List<Data>(); // 리스트에 data 집어넣기
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
            data2.main_information = "SY전자에서 발매한 와이폰13의 겉면이 떨어지는 사례 다수 발견";
            data2.materials_information = "SY전자, 무료 수리 제공, 이로 인한 원재료 가격 상승";
            data2.materials_change = 1.5f;
            data2.product_information = "와이폰13, 소비자의 기대가 떨어져 제품 가격 하락";
            data2.product_change = 0.8f;
            data2.stock_information = "SY전자 주식 하락";
            data2.stock_change = 0.7f;
            data2.realestate_information = "변화 없음";
            data2.realestate_change = 1f;
            datalist.Add(data2);

            Console.WriteLine(@"구매 → 판매 → 가격변동이 이루어지는 한 챕터가 시작됩니다.
이번 챕터에서 정보를 구매하시겠습니까? 구매하실것이라면 'YES' 라고 입력해주십시오.
구매하지 않을 것이라면 엔터키를 입력해주십시오.
정보의 가격은 당신이 가진 현금의 5%입니다.");

            // 리스트 내 랜덤 정보 추출
            Random random = new Random();
            int i = datalist.Count; // 데이터 몇 개인지 카운트
            int rnd = random.Next(0, i); // 0번부터 데이터 갯수
            // Console.WriteLine(i); //-> datalist 몇개인지 카운트 확인
            // Console.WriteLine(rnd); //-> 0 ~ i의 값 랜덤 생성인지 확인
            var random_information = datalist[rnd]; // data1,data2...중 랜덤으로 하나를 갖고온 random_information

            string purchase_information = Console.ReadLine(); // 시간 되면 bool형으로 고쳐보자

            if (purchase_information == "YES") // 구매한다고 선택한 경우 가진 현금의 5%를 소비
            {
                double _cash = Math.Round(cash * 0.95); // 전역변수 cash를 받아와 95%값을 남긴 뒤, 반올림
                cash = (int) _cash; // double형이 되어버린 cash를 다시 int형으로 전환

                Console.WriteLine(random_information.main_information); // datalist내 main_information 불러옴
            }

            // 챕터 진입 마감

            // [A] 투자 진행
            Investment();

            // [B] 판매 진행
            Sale();

            // [C] 자본 가치 변동 진행

            Console.WriteLine("이번 챕터의 각 자산별 정보입니다.");

            Console.WriteLine(random_information.materials_information); // datalist내 materials_information 불러옴
            double _materials = Math.Round(materials * random_information.materials_change); // 전역변수 materials를 받아와 material 변화값을 곱하고 반올림
            materials = (int)_materials; // double형이 되어버린 materials를 다시 int형으로 전환

            Console.WriteLine(random_information.product_information); 
            double _product = Math.Round(product * random_information.product_change);
            product = (int)_product;

            Console.WriteLine(random_information.stock_information);
            double _stock = Math.Round(stock * random_information.stock_change);
            stock = (int)_stock;

            Console.WriteLine(random_information.realestate_information);
            double _realestate = Math.Round(realestate * random_information.realestate_change);
            realestate = (int)_realestate;

            Console.WriteLine(" ");
            Console.WriteLine("챕터를 마친 현재 당신이 보유한 각 항목별 보유가치입니다.");
            Console.Write("현금 현재 보유 금액: ");
            Console.WriteLine(cash);
            Console.Write("원재료 현재 보유 금액: ");
            Console.WriteLine(materials);
            Console.Write("제품 현재 보유 금액: ");
            Console.WriteLine(product);
            Console.Write("주식 현재 보유 금액: ");
            Console.WriteLine(stock);
            Console.Write("부동산 현재 보유 금액: ");
            Console.WriteLine(realestate);

            // [C] 자본 가치 변동 진행 마감

            // 챕터 마감
        }

        class Data // 모두 구현 후, 엑셀에서 직접 가져오는 것도 시도해보자!
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
        public static void Investment()
        {
            // 현재 각 항목 보유 가치 출력
            Console.WriteLine("현재 당신이 보유한 각 항목별 보유가치입니다.");
            Console.Write("현금 현재 보유 금액: ");
            Console.WriteLine(cash);
            Console.Write("원재료 현재 보유 금액: ");
            Console.WriteLine(materials);
            Console.Write("제품 현재 보유 금액: ");
            Console.WriteLine(product);
            Console.Write("주식 현재 보유 금액: ");
            Console.WriteLine(stock);
            Console.Write("부동산 현재 보유 금액: ");
            Console.WriteLine(realestate);
            Console.WriteLine(" ");

            // 각 항목 투자금 입력 받기
            Console.WriteLine("이제 각 항목별로 투자금을 입력해주십시오. 현금은 투자만 할 뿐 투자받지 않습니다.");

            Console.Write("원재료 투자 금액: ");
            string _investment_materials = Console.ReadLine(); // 원재료 투자 받음
            int investment_materials = int.Parse(_investment_materials); // 입력 받은 string을 int로 고침
            materials = materials + investment_materials; // 기존 원재료에 투자한 원재료의 가치가 더해져 원재료 가치가 결정

            Console.Write("제품 투자 금액: ");
            string _investment_product = Console.ReadLine(); // 제품 투자 받음 
            int investment_product = int.Parse(_investment_product);
            product = product + investment_product;

            Console.Write("주식 투자 금액: ");
            string _investment_stock = Console.ReadLine(); // 주식 투자 받음 
            int investment_stock = int.Parse(_investment_stock);
            stock = stock + investment_stock;

            Console.Write("부동산 투자 금액: ");
            string _investment_realestate = Console.ReadLine(); // 부동산 투자 받음 
            int investment_realestate = int.Parse(_investment_realestate);
            realestate = realestate + investment_realestate;

            // 투자한 금액이 cash 현금에서 빠져 나감
            cash = cash - investment_materials - investment_product - investment_stock - investment_realestate;
            Console.WriteLine("투자가 종료되었습니다.");
            Console.WriteLine(" ");

        }

        public static void Sale()
        {
            // 현재 각 항목 보유 가치 출력
            Console.WriteLine("현재 당신이 보유한 각 항목별 보유가치입니다.");
            Console.Write("현금 현재 보유 금액: ");
            Console.WriteLine(cash);
            Console.Write("원재료 현재 보유 금액: ");
            Console.WriteLine(materials);
            Console.Write("제품 현재 보유 금액: ");
            Console.WriteLine(product);
            Console.Write("주식 현재 보유 금액: ");
            Console.WriteLine(stock);
            Console.Write("부동산 현재 보유 금액: ");
            Console.WriteLine(realestate);
            Console.WriteLine(" ");


            // 각 항목 판매금 입력 받기
            Console.WriteLine(@"이제 각 항목별로 판매금을 입력해주십시오. 
현금은 판매할 수 없습니다.
각 항목별로 판매 가능한 가능성이 다릅니다.
유동자산이라면 판매할 가능성이 더 높습니다.");

            // 랜덤으로 판매 가능하도록 제작
            Random random = new Random();
            int possibility_of_sale = random.Next(1, 100); // 1~100 중 하나의 값이 랜덤 지정 -> 계속 사용 가능

            Console.Write("원재료 판매 금액: ");
            string _sale_materials = Console.ReadLine(); // 원재료 판매할 금액 받음
            int sale_materials = int.Parse(_sale_materials); // 입력 받은 string을 int로 고침
            if (possibility_of_sale <= 90) // 90%의 확률로 판매되도록 함
            {
                materials = materials - sale_materials; // 기존 원재료에 판매한 원재료의 가치가 빠져 원재료 가치가 결정
                cash = cash + sale_materials; // 확률에 따라 팔렸다면 그만큼 현금이 증가한다.
            }

            Console.Write("제품 판매 금액: ");
            string _sale_product = Console.ReadLine(); // 제품 판매할 금액 받음
            int sale_product = int.Parse(_sale_product);
            if (possibility_of_sale <= 80) // 80%의 확률로 판매되도록 함
            {
                product = product - sale_product; // 기존 원재료에 판매한 원재료의 가치가 빠져 원재료 가치가 결정
                cash = cash + sale_product; // 확률에 따라 팔렸다면 그만큼 현금이 증가한다.
            }

            Console.Write("주식 판매 금액: ");
            string _sale_stock = Console.ReadLine(); // 주식 판매할 금액 받음
            int sale_stock = int.Parse(_sale_stock);
            if (possibility_of_sale <= 40) // 40%의 확률로 판매되도록 함 (기획: 비유동이기에 유동보다 확률이 체감되도록 숫자가 적어짐)
            {
                stock = stock - sale_stock; // 기존 원재료에 판매한 원재료의 가치가 빠져 원재료 가치가 결정
                cash = cash + sale_stock; // 확률에 따라 팔렸다면 그만큼 현금이 증가한다.
            }

            Console.Write("부동산 투자 금액: ");
            string _sale_realestate = Console.ReadLine(); // 부동산 판매할 금액 받음
            int sale_realestate = int.Parse(_sale_realestate);
            if (possibility_of_sale <= 20) // 20%의 확률로 판매되도록 함
            {
                realestate = realestate - sale_realestate; // 기존 원재료에 판매한 원재료의 가치가 빠져 원재료 가치가 결정
                cash = cash + sale_realestate; // 확률에 따라 팔렸다면 그만큼 현금이 증가한다.
            }

            Console.WriteLine("판매가 종료되었습니다.");
            Console.WriteLine(" ");


            /* 현재 각 항목 보유 가치 출력 -> 현재까지 오류 없는지 확인 -> 문제 없음
            Console.WriteLine("현재 당신이 보유한 각 항목별 보유가치입니다.");
            Console.Write("현금 현재 보유 금액: ");
            Console.WriteLine(cash);
            Console.Write("원재료 현재 보유 금액: ");
            Console.WriteLine(materials);
            Console.Write("제품 현재 보유 금액: ");
            Console.WriteLine(product);
            Console.Write("주식 현재 보유 금액: ");
            Console.WriteLine(stock);
            Console.Write("부동산 현재 보유 금액: ");
            Console.WriteLine(realestate);
            */
        }

    }


}
