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
        public BigInteger ID { get; } = _currentId;

        /// <summary>
        /// ���
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        public Point Location { get; private set; }

        /// <summary>
        /// ������������ �������� ����� �������� ���������
        /// </summary>
        public byte MaxHealth { get; private set; }

        /// <summary>
        /// ����� �������� ��������� �� 0 �� MaxHealth
        /// </summary>
        public byte Health
        {
            get => _health;
            private set => _health = value < 0 ? (byte)0 : value > MaxHealth ? MaxHealth : value;
        }

        /// <summary>
        /// ������� ���������, ���������� � ���������, � ��������������� �� ������������ ���������
        /// </summary>
        public Dictionary<Drop,byte> Drops { get; private set; }


        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="parName">��� ���������</param>
        /// <param name="parMaxHealth">������������ �������� ���������</param>
        /// <param name="parLocation">���������� ���������</param>
        /// <param name="parDrops">������� ���������� � ��������� ���������</param>
        public Animal( string parName, Point parLocation, Dictionary<Drop, byte> parDrops, byte parMaxHealth)
        {
            _currentId++;
            Name = parName;
            MaxHealth = (byte)Math.Abs(parMaxHealth);
            Health = MaxHealth;
            Location = parLocation;
            Drops = parDrops;
        }

    
        /// <summary>
        /// ������ ���������
        /// </summary>
        /// <returns>��������� ���������� �������</returns>
        private Drop? ToDie() 
        {
            int probability = new Random().Next(Drops.Values.Max());
            int totalProbability = 0;
            foreach (var elIDrop in Drops)
            {
                totalProbability += elIDrop.Value;
                if (probability < totalProbability)
                {
                    return elIDrop.Key;
                }
            }
            return null;
        }

        /// <summary>
        /// �������� ��������
        /// </summary>
        /// <param name="parDamage">����</param>
        /// <returns>��������� ���������� ������� � ������ ������</returns>
        public Drop? ToDamage( byte parDamage ) 
        {
            Health -= parDamage;
            return Health > 0 ? null : ToDie();
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
