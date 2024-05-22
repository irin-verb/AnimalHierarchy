using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows;
using Vector = System.Windows.Vector;

namespace KPO
{
    /// <summary>
    /// ��������, ������������� ����������� :)
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// ������������ �������� ���������
        /// </summary>
        public const byte MAX_HEALTH = 20;


        /// <summary>
        /// ������� ��������� ������������� ��� ���������� ������������ ���������
        /// </summary>
        private static BigInteger _currentId = 0;

        /// <summary>
        /// ����� �������� ���������
        /// </summary>
        private byte _health;


        /// <summary>
        /// �������������
        /// </summary>
        public BigInteger ID { get; private set; } = _currentId;

        /// <summary>
        /// ���
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// ����������
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// ����� �������� ��������� �� 0
        /// </summary>
        public byte Health
        {
            get => _health;
            set => _health = value < 0 ? (byte)0 : value > MAX_HEALTH ? MAX_HEALTH : value;
        }

        /// <summary>
        /// �������, ������� �������� ����� �� ���
        /// </summary>
        public Drop Drop { get; set; }


        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="parName">��� ���������</param>
        /// <param name="parHealth">�������� ���������</param>
        /// <param name="parLocation">���������� ���������</param>
        /// <param name="parDrop">�������, ������� �������� ����� �� ���</param>
        public Animal( string parName, Point parLocation, byte parHealth = MAX_HEALTH, Drop parDrop = Drop.None)
        {
            _currentId++;
            Name = parName;
            Health = parHealth;
            Location = parLocation;
            Drop = parDrop;
        }

        /// <summary>
        /// ������ �����������
        /// </summary>
        public Animal()
        {
            _currentId++;
        }

        /// <summary>
        /// ����������� �����������
        /// </summary>
        /// <param name="parAnimal">��������, ������� ����������</param>
        public Animal(Animal parAnimal)
        {
            Copy(parAnimal);
        }


        /// <summary>
        /// ���������� ��������� ���������
        /// </summary>
        /// <param name="parAnimal">���������, ��������� �������� ����������</param>
        public virtual void Copy(Animal parAnimal)
        {
            ID = parAnimal.ID;
            Name = parAnimal.Name;
            Location = parAnimal.Location;
            Health = parAnimal.Health;
            Drop = parAnimal.Drop;
        }
    
        /// <summary>
        /// ������ ���������
        /// </summary>
        /// <returns>�������, ������� �������� ����� �� ���</returns>
        private Drop ToDie() 
        {
            return (new Random()).Next(2) == 0 ? Drop.None : Drop;
        }

        /// <summary>
        /// �������� ��������
        /// </summary>
        /// <param name="parDamage">����</param>
        /// <returns>�������, ������� �������� ����� �� ��� (� ������ ������)</returns>
        public Drop ToDamage( byte parDamage ) 
        {
            Health -= parDamage;
            return Health > 0 ? Drop.None : ToDie();
        }

        /// <summary>
        /// ��������� ��������
        /// </summary>
        /// <param name="parSatiety">�������� ���</param>
        public virtual void ToEat( byte parSatiety ) 
        {
            Health += parSatiety;
        }
        
        /// <summary>
        /// ����������� ��������
        /// </summary>
        /// <param name="parVector">������ �����������</param>
        public void ToMove( Vector parVector )
        {
            Location += parVector;
        }
        
        /// <summary>
        /// ����������� ��������
        /// </summary>
        /// <param name="point">�������� �����, � ������� ����������</param>
        public void ToMove( Point point )
        {
            ToMove(Location - point);
        }

    }
}
