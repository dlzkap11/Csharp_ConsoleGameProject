
using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;

namespace ConsoleGameFramework.Contents;

public class Character
{
    public string Name { get; set; }
   
    private int hp { get; set; }
    public int Hp 
    { 
        get => hp;
        private set
        {
            int oldHp = hp;

            hp = Math.Clamp(value, 0, MaxHp);
            if (oldHp != hp)
            {
                OnHpChanged?.Invoke(oldHp, hp);
            }
            if (hp <= 0)
            {
                OnDied?.Invoke();
            }
        }
    }
    public int MaxHp { get; set; }
    public int Attack { get; set; }
    public bool IsAlive => Hp > 0;


    public event Action<int, int> OnHpChanged;
    public event Action OnDied;

    public Character(string name, int maxHp, int attack)
    {
        Name = name;
        MaxHp = maxHp;
        Hp = MaxHp;
        Attack = attack;
    }


    public void TakeDamage(int damage) => Hp -= damage;
    public void Heal(int amount) => Hp += amount;

    class UIElement : IDisposable
    {
        private Player player;
        private Action<int, int> hpChangedHandler;

        public UIElement(Player player)
        {
            this.player = player;
            hpChangedHandler = OnHpChanged;
            player.OnHpChanged += hpChangedHandler;
            Console.WriteLine("구독 시작");
        }

        private void OnHpChanged(int old, int hp)
        {
            Console.WriteLine($"[UI] HP : {hp} / {player.MaxHp}");
        }

        public void Dispose()
        {
            if (player != null)
            {
                player.OnHpChanged -= hpChangedHandler;
                Console.WriteLine("구독 해제");
                player = null;
            }
        }
    }
}


class UISystem
{
    public void Subscribe(Character player)
    {
        player.OnHpChanged += (old, hp) =>
        {
            int percent = hp * 100 / player.MaxHp;
            string bar = new string('|', percent / 10) + new string('.', 10 - percent / 10);
            ConsoleUI.WriteLine($"[UI] [{bar}] {hp} / {player.MaxHp} HP");
            ConsoleUI.WriteStatusBar(player.Name, hp, player.MaxHp);
            Thread.Sleep(1000);
        };


        player.OnDied += () => { ConsoleUI.WriteLine($"[UI] {player.Name} 사망"); };
    }
}

class SoundSystem
{

}
