using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBrien_Final
{
    public class Villian : Character
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="characterType"></param>
        /// <param name="level"></param>
        /// <param name="intel"></param>
        /// <param name="strength"></param>
        /// <param name="defent"></param>
        /// <param name="speed"></param>
        public Villian(string characterType, int level, int intel, int strength, int defent, int speed)
        {
            CharacterType = characterType;
            Level = level;
            Intelligence = intel;
            Strength = strength;
            Defense = defent;
            Speed = speed;
            IsHero = false;
            SetAttack();
            SetHP();
            StatLogic();
        }
        public Villian() { }

        /// <summary>
        /// Programiticly adjust chacters stats by their character type accordingly
        /// </summary>
        private void StatLogic()
        {
            switch (CharacterType)
            {
                case "bandit":
                    if (Defense > 4)
                        Defense = 4;
                    if (Strength > 4)
                        Strength = 4;
                    Hp = Hp / 2;
                    MaxHp = Hp;
                    break;
                case "ogre":
                    Defense += 1;
                    Attack = Attack + (Attack / 4);
                    if (Speed > 3)
                        Speed = 3;
                    break;
                case "dragon":
                    Attack = Attack + (Attack / 4);
                    if (Speed > 4)
                        Speed = 4;
                    Hp = Hp + (Hp / 2);
                    MaxHp = Hp;
                    break;
            }
        }

        /// <summary>
        /// Override method
        /// Applies damage logic to character depending on
        /// Character type, Then administers damage using
        /// DoDamage()
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="magic"></param>
        public override void Hurt(int amount, bool magic)
        {
            switch (CharacterType)
            {
                case "ogre":
                    if (magic)
                        DoDamage(amount);
                    else
                        DoDamage(amount - Defense);
                    break;

                default:
                    DoDamage(amount - Defense);
                    break;
            }
        }

        /// <summary>
        /// Wrapper method to attack a Hero
        /// </summary>
        /// <param name="e"></param>
        public void AttackHero(Hero e)
        {
            e.Hurt(Attack, IsAttackMagic);
        }
    }
}
