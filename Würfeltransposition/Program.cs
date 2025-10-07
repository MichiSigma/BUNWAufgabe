using System.Text;

namespace Würfeltransposition
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Program program = new Program();
            Console.WriteLine("Verschlüsselungs- /Entschlüsselungprogramm");
            string answer = Console.ReadLine();
            if (answer == "v")
            {
                Console.WriteLine(program.Verschlüsseln());
            }
            else if (answer == "e")
            {
                program.Entschlüsseln();
            }
            else 
            {
                Console.WriteLine("Falsche Eingabe!");
            }  
        }


        public string Verschlüsseln()
        {
            Random random = new Random();
            Console.WriteLine("Nachricht eingeben:");
            string message = Console.ReadLine();
            message = String.Concat(message.Where(c => !Char.IsWhiteSpace(c)));
            message = message.ToUpper();

            int messagelenght = message.Length;
            Console.WriteLine("Blocklänge?");
            int blocklength = Convert.ToInt32(Console.ReadLine());

            int rest = messagelenght % blocklength;
            if (rest > 0)
            {
                int add = blocklength - rest;
                for (int i = 0; i < add; i++)
                {
                    string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    int randnum = random.Next(letters.Length);
                    message = message + letters[randnum];
                }
            }
            int zahl = 0;
            int runden = 1;
            string verschlüsselt = null;
            for (int i = 0; i < message.Length; i++)
            {
                verschlüsselt = verschlüsselt + message[zahl];
                zahl = zahl + blocklength;
                if (zahl >= message.Length)
                {
                    zahl = message.Length - (message.Length - runden);
                    runden++;
                }
            }
            return verschlüsselt;
        }
        public void Entschlüsseln()
        {
            Console.WriteLine("Verschlüsselte Nachricht eingeben");
            string verschlüsselt = Console.ReadLine();

            int x = 0;
            int[] lenght = {0,0,0,0,0,0,0,0,0};
            for (int i = 2; i < 10; i++)
            {
                int ergebnis = verschlüsselt.Length % i;
                if (ergebnis == 0)
                {
                    lenght[x] =+ i;
                    x++;
                }
            }
            int numberToRemove = 0;
            lenght = lenght.Where(val => val != numberToRemove).ToArray();

            for (int h = 0; h < lenght.Length; h++)
            {
                char[] entschlüsselt = verschlüsselt.ToCharArray();
                int zahl = 0;
                int runden = 1;
                for (int i = 0; i < verschlüsselt.Length; i++)
                {
                    entschlüsselt[zahl] = verschlüsselt[i];
                    zahl = zahl + lenght[h];
                    if (zahl >= verschlüsselt.Length)
                    {
                        zahl = verschlüsselt.Length - (verschlüsselt.Length - runden);
                        runden++;
                    }
                }
                foreach (var item in entschlüsselt)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
            
            //IREUFZECSDNGUNHUIWALRVCEABÖLEHBUESM
        }
        
    }
    //https://www.tradingcode.net/csharp/strings/remove-whitespace/
    //https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
    //https://www.reddit.com/r/Unity3D/comments/yus6h9/how_do_you_remove_an_element_from_an_array/
}
