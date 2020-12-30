using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12_CRPPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        

        // Герой (раса)
        abstract class HeroFactory
        {
            public abstract Weapon CreateWeapon();
            public abstract Type CreateType();
        }
        class People_Warrior_Factory : HeroFactory
        {
            public override Weapon CreateWeapon()
            {
                return new Sword();
            }
            public override Type CreateType()
            {
                return new Warrior();
            }
        }
        class People_Paladin_Factory : HeroFactory
        {
            public override Weapon CreateWeapon()
            {
                return new Hammer();
            }
            public override Type CreateType()
            {
                return new Paladin();
            }
        }

        class Elfs_Warrior_Factory : HeroFactory
        {
            public override Weapon CreateWeapon()
            {
                return new Sword();
            }
            public override Type CreateType()
            {
                return new Warrior();
            }
        }
        class Elfs_Wizard_Factory : HeroFactory
        {
            public override Weapon CreateWeapon()
            {
                return new Staff();
            }
            public override Type CreateType()
            {
                return new Wizard();
            }
        }
        class Orcs_Warrior_Factory : HeroFactory
        {
            public override Weapon CreateWeapon()
            {
                return new Sword();
            }
            public override Type CreateType()
            {
                return new Warrior();
            }
        }
        
        
        
        // Оружие
        abstract class Weapon
        {
            public string weapon;
            public abstract string ChangeWeapon();
        }
        class Sword : Weapon
        {
            public override string ChangeWeapon()
            {
                weapon = "меч";
                return weapon;
            }
        }
        class Staff : Weapon
        {
            public override string ChangeWeapon()
            {
                weapon = "посох";
                return weapon;
            }
        }
        class Hammer : Weapon
        {
            public override string ChangeWeapon()
            {
                weapon = "молот";
                return weapon;
            }
        }
        // класс
        abstract class Type
        {
            public string type;
            public abstract string ChangeType();
        }
        class Warrior : Type
        {
            public override string ChangeType()
            {
                type = "воин";
                return type;
            }
        }
        class Wizard : Type
        {
            public override string ChangeType()
            {
                type = "маг";
                return type;
            }
        }
        class Paladin : Type
        {
            public override string ChangeType()
            {
                type = "паладин";
                return type;
            }
        }
        // клиент
        class Hero 
        {
            public Weapon weapon;
            public Type type;

            public Hero(HeroFactory factory)
            {
                weapon = factory.CreateWeapon();
                type = factory.CreateType();
            }
            public string GetWeapon()
            {
                weapon.ChangeWeapon();
                return weapon.weapon;
            }
            public string Gtype()
            {
                type.ChangeType();
                return type.type;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioPeople.Checked && radioVoin.Checked && radioSword.Checked)
                {
                    Hero people_voin = new Hero(new People_Warrior_Factory());
                    MessageBox.Show("Создан человек-" + people_voin.Gtype() + "\nОружие: " + people_voin.GetWeapon());
                    pictureBox1.Load(@"C:\Users\Алексей\source\repos\lab12_CRPPC\lab12_CRPPC\images\people.png");
                }
                else if (radioPeople.Checked && radioPaladin.Checked && radioHammer.Checked)
                {
                    Hero people_paladin = new Hero(new People_Paladin_Factory());
                    MessageBox.Show("Создан человек-" + people_paladin.Gtype() + "\nОружие: " + people_paladin.GetWeapon());
                    pictureBox1.Load(@"C:\Users\Алексей\source\repos\lab12_CRPPC\lab12_CRPPC\images\people.png");
                }
                else if (radioElf.Checked && radioVoin.Checked && radioSword.Checked)
                {
                    Hero elf_voin = new Hero(new Elfs_Warrior_Factory());
                    MessageBox.Show("Создан эльф-" + elf_voin.Gtype() + "\nОружие: " + elf_voin.GetWeapon());
                    pictureBox1.Load(@"C:\Users\Алексей\source\repos\lab12_CRPPC\lab12_CRPPC\images\elf.png");
                }
                else if (radioElf.Checked && radioMag.Checked && radioStaff.Checked)
                {
                    Hero elf_wiz = new Hero(new Elfs_Wizard_Factory());
                    MessageBox.Show("Создан эльф-" + elf_wiz.Gtype() + "\nОружие: " + elf_wiz.GetWeapon());
                    pictureBox1.Load(@"C:\Users\Алексей\source\repos\lab12_CRPPC\lab12_CRPPC\images\elf.png");
                }
                else if(radioOrk.Checked && radioVoin.Checked && radioSword.Checked)
                {
                    Hero ork_voin = new Hero(new Orcs_Warrior_Factory());
                    MessageBox.Show("Создан орк-" + ork_voin.Gtype() + "\nОружие: " + ork_voin.GetWeapon());
                    pictureBox1.Load(@"C:\Users\Алексей\source\repos\lab12_CRPPC\lab12_CRPPC\images\ork.png");
                }
                else
                {
                    MessageBox.Show("Ошибка!\nНевозможно создать персонажа");
                    pictureBox1.Load(@"C:\Users\Алексей\source\repos\lab12_CRPPC\lab12_CRPPC\images\ER.png");
                }
            }
            catch
            {
                MessageBox.Show("ERROR!!!");
            }
        }
    }
}
