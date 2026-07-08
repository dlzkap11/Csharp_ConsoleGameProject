namespace ConsoleGameFramework.Contents;

public class Trainer : Character
{
    /*
    -트레이너
    - 이름, 포켓몬 리스트, 레벨스케일링?
    */
    public List<Poketmon> Poketmons = new List<Poketmon>(6);


    public Trainer(string name) : base(name)
    {
        // 포켓몬리스트에 포켓몬 추가
        Poketmons.Add(new Poketmon("이상해씨"));
    }


}
/*
 * 전투시스템 및 전투 발생시 들어갈 씬 구현
 * 인벤토리 및 아이템 상호작용 구현 뭐 상처약을 쓰면 해당 포켓몬의 체력이 회복
 * 몬스터볼 관련 시스템 구현 
 * 말고 큰부분들이 더 있나?
 * 레벨업관련 스탯 오르기 + 기술을 언제 어떻게 배우게 할 것인가
 * 진화가 가능한가?
 * 
 */
