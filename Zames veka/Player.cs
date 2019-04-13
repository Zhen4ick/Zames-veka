using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Zames_veka
{
     
    public class Player
    {
        
        //Имя  
        public string name;
        //Здоровье 
        public int HP = 100;
        
        //Максимальный урон от атак
        public int maxatatckDamage;
        //Мана
        public int mana = 0;
        //На сколько будет прибавляться мана после каждого хода
        public int manaAddition;        
        //Рандом определяющий урон по врагу
        public Random atackRnd = new Random();
        //Ход игрока
        public bool move = true;
        //Атака       
        public void Atack(Enemy enemy)
        {
            enemy.HP -= atackRnd.Next(0, maxatatckDamage);
            
        }

    }
}
