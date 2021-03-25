using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _11
{
    class Bot
    {
        string message;
       internal bool flag = true;

        public void Read() 
        {
               message =  Console.ReadLine();
        }


        public async Task StartMainLoopAsync()

        {

            if (message == Hello.FirstOrDefault(s => s == message))
            { await Task.Run(async () =>
                {
                    Thread.Sleep(10000);
                    Console.WriteLine(Answer(0));
                
                });
            }
            else if (message == "Сколько времени" || message == "Который час")
            {
                await Task.Run(async () =>
                {
                    Console.WriteLine(DateTime.Now);
                });
            }
                
            else if (message == "Как тебя зовут?")
            {
                await Task.Run(async () =>
                {
                    Console.WriteLine("Шарпик");
                });
            }
                
            else if (message.Contains("Анекдот"))
            {
                await Task.Run(async () =>
                {
                    Console.WriteLine(Answer(2));
                });
            }
                
            else if (message == "Пока" || message == "До свидания")
            {
                await Task.Run(async () =>
                {
                    Console.WriteLine(Answer(1));
                flag = false;
                });
            }
            else
            {
                await Task.Run(async () =>
                {
                    Console.WriteLine(Answer(3));
                });
            }
                
        }      


            
           
        
  

        List<string> Hello = new List<string>()
        {
             "Привет",
             "Здравствуй",
             "Здравствуйте",
             "Добрый день",
             "Добрый вечер",
             "Добрый ночи"
        };

    string Answer(int i)
        {
            List<List<string>> reply = new List<List<string>>();
            
            List<string> greetings = new List<string>()
            {
               "Здравствуй! Здравствуйте!",
               "Приветствую вас!",
               "Привет!",
               "Хэлло!"
            };
            List<string> goodbyes = new List<string>()
            {
               "До свидания!",
               "До встречи!",
               "До скорого!"
            };
            List<string> anecdotes = new List<string>()
            {
               "А вы поститесь? А как же! С утра уже 3 поста выложил.",
               "Если в лесу вы встретили медведя, клещей уже не стоит бояться.",
               "Нормальному человеку, чтобы выспаться, нужно всего лишь ещё 5 минут."
            };
            List<string> aphorisms = new List<string>()
            {
               "Самая нужная наука - это наука забывать ненужное. (Антисфен)",
               "Лучшее - враг хорошего. (Вольтер)",
               "Есть три способа отвечать на вопросы: сказать необходимое, отвечать с приветливостью и наговорить лишнего. (Плутарх)"
            };
            reply.Add(greetings);
            reply.Add(goodbyes);
            reply.Add(anecdotes);
            reply.Add(aphorisms);

            FileStream fsout = new FileStream("peop.dat",
                FileMode.Create, FileAccess.Write);
            XmlSerializer serializerout = new XmlSerializer(typeof(List<List<string>>),
                new Type[] { typeof(string) });
            serializerout.Serialize(fsout, reply);
            fsout.Close();

            List<List<string>> Lines1 = new List<List<string>>();
            FileStream fsin = new FileStream("peop.dat", FileMode.Open,
                FileAccess.Read);
            XmlSerializer serializerin = new XmlSerializer(typeof(List<List<string>>),
                new Type[] { typeof(string) });
            Lines1 = (List<List<string>>)serializerin.Deserialize(fsin);
            fsin.Close();
            Random r = new Random();
            return Lines1[i][r.Next(0, Lines1[i].Count)];
        }
    }
}
