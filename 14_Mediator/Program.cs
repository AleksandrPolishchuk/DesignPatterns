﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;
            customer.Send("Делаем программу");
            programmer.Send("Тестируем");
            tester.Send("Продаём");

            Console.Read();
        }

        abstract class Mediator
        {
            public abstract void Send(string msg, Colleague colleague);
        }
        abstract class Colleague
        {
            protected Mediator mediator;

            public Colleague(Mediator mediator)
            {
                this.mediator = mediator;
            }

            public virtual void Send(string message)
            {
                mediator.Send(message, this);
            }
            public abstract void Notify(string message);
        }
        // класс заказчика
        class CustomerColleague : Colleague
        {
            public CustomerColleague(Mediator mediator)
                : base(mediator)
            { }

            public override void Notify(string message)
            {
                Console.WriteLine("Сообщение заказчику: " + message);
            }
        }
        // класс программиста
        class ProgrammerColleague : Colleague
        {
            public ProgrammerColleague(Mediator mediator)
                : base(mediator)
            { }

            public override void Notify(string message)
            {
                Console.WriteLine("Сообщение программисту: " + message);
            }
        }
        // класс тестера
        class TesterColleague : Colleague
        {
            public TesterColleague(Mediator mediator)
                : base(mediator)
            { }

            public override void Notify(string message)
            {
                Console.WriteLine("Сообщение тестеру: " + message);
            }
        }

        class ManagerMediator : Mediator
        {
            public Colleague Customer { get; set; }
            public Colleague Programmer { get; set; }
            public Colleague Tester { get; set; }
            public override void Send(string msg, Colleague colleague)
            {
                // если отправитель - заказчик, значит есть новый заказ
                // отправляем сообщение программисту - выполнить заказ
                if (Customer == colleague)
                    Programmer.Notify(msg);
                // если отправитель - программист, то можно приступать к тестированию
                // отправляем сообщение тестеру
                else if (Programmer == colleague)
                    Tester.Notify(msg);
                // если отправитель - тест, значит продукт готов
                // отправляем сообщение заказчику
                else if (Tester == colleague)
                    Customer.Notify(msg);
            }
        }
    }
}
