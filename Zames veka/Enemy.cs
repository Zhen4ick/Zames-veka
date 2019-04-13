using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zames_veka
{
    public class Enemy:Player
    {
        //Bool нужный для определения смерти врага
        public bool defeated = false;
        //Константа hp, котора меняется только один раз при выборе сложности.
        //При смерти игрока восстанавливает hp врага
        public int constHp;
        //Атака
        public void Atack(Player player)
        {
            player.HP -= atackRnd.Next(0, maxatatckDamage);
        }
    }
}
